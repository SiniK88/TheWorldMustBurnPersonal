using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{
    public float fallMultiplayer = 2.5f;
    public float lowJumpMultiplayer = 2f;

    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;
    public float moveSpeed = 6;
    public float gravity = -10;
    public float jumpVelocity = 8;
    public float accelerationTimeGrounded = 0.1f;
    public float accelerationTimeAirborne = 0.2f;

    float velocityXSmoothing;
    [SerializeField] int maxJumps = 2;
    [SerializeField] int jumps = 0;
    Vector3 velocity;

    [SerializeField]
    [Range(1f, 60f)] float dashSpeed;
    [SerializeField]
    [Range(0f, 2f)] float dashTime;
    [SerializeField] float dashTimer = 0.5f;
    float timer = 0;
    bool canDash = true;

    public float startDashTime;
    public int direction;
    public bool isDashButtonDown;
    public bool dash = false;
    GameManager gm;

    RayCast2DController controller;
    

    public ParticleSystem kipin�;
    public ParticleSystem dashKipin�;
    Animator animator;
    private string currentState;
    public GameObject dashBlock;
    PlayerHealth playerHealth;
    GameStart gameStart;

    float moveInput;
    float moveInputY;
    // animation states
    const string PLAYER_BIRTH_RED = "PlayerBirthRed";
    const string PLAYER_IDLE_RED = "PlayerIdleRed";
    const string PLAYER_JUMP_RED = "PlayerJumpRed";
    const string PLAYER_IDLE_BLUE = "PlayerIdleBlue";
    const string PLAYER_JUMP_BLUE = "PlayerJumpBlue";
    const string PLAYER_IDLE_PURPLE = "PlayerIdlePurple";
    const string PLAYER_JUMP_PURPLE = "PlayerJumpPurple";
    const string PLAYER_DEATH_PURPLE = "PlayerDeathPurple";
    const string PLAYER_DEATH_RED = "PlayerDeathRed";
    const string PLAYER_DEATH_BLUE = "PlayerDeathBlue";



    private void Start() {
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();

        controller = GetComponent<RayCast2DController>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        print(" gravity " + gravity + " jump velocity " + jumpVelocity);

        dashTime = startDashTime;
        playerHealth = FindObjectOfType<PlayerHealth>();
        gameStart = FindObjectOfType<GameStart>();
    }

    private void Update() {


        moveInput = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");

        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;

        if (velocity.y > 0) {
            if (gm.State == PowerupType.None) {
                ChangeAnimationState(PLAYER_JUMP_RED);
            } else if (gm.State == PowerupType.Projectile) {
                ChangeAnimationState(PLAYER_JUMP_BLUE);
            } else if(gm.State == PowerupType.NoFire) {
                ChangeAnimationState(PLAYER_JUMP_PURPLE);
            }
        }

        if (velocity.y < 0) {
            if (gm.State == PowerupType.None) {
                ChangeAnimationState(PLAYER_IDLE_RED);
            } else if (gm.State == PowerupType.Projectile) {
                ChangeAnimationState(PLAYER_IDLE_BLUE);
            } else if (gm.State == PowerupType.NoFire) {
                ChangeAnimationState(PLAYER_IDLE_PURPLE);
            }
        }

        if (controller.collisions.above || controller.collisions.below) {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
 
        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below) {
            CreateKipin�();
            velocity.y = jumpVelocity;
        }

        if (controller.collisions.below == true) {
            jumps = 0;
        }

        if (Input.GetButtonDown("Jump") && jumps < maxJumps) {
            
            jumps++;
            velocity = Vector2.zero;
            velocity.y = jumpVelocity;
            //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            CreateKipin�();
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (velocity.y < 0) {
            velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplayer - 1) * Time.deltaTime;
        } else if (velocity.y > 0 && !Input.GetButton("Jump")) {
            velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplayer - 1) * Time.deltaTime;
        }

           Dash();
    }
    void CreateKipin�() {
        kipin�.Play();
    }
    void CreateDashKipin�() {
        dashKipin�.Play();
    }

    void JumpAnimation() {
        if (Input.GetAxis("Vertical") > 0) {
            animator.Play("PlayerJumpRed");
        } else if (Input.GetAxis("Vertical") < 0) {
            animator.Play("PlayerIdleRed");
        }
    }
    public void StartAnim() {
        ChangeAnimationState(PLAYER_BIRTH_RED);
    }

    void ChangeAnimationState (string newState) {
        if (currentState == newState) return;

        animator.Play(newState);
        currentState = newState;
    }


    public void DeathAnim() {
        if (gm.State == PowerupType.None) {
            ChangeAnimationState(PLAYER_DEATH_RED);
        } else if (gm.State == PowerupType.Projectile) {
            ChangeAnimationState(PLAYER_DEATH_BLUE);
        } else if (gm.State == PowerupType.NoFire) {
            ChangeAnimationState(PLAYER_DEATH_PURPLE);
        }
    }

    void Dash() {
        if (direction == 0) {

            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButton("Dash")) && canDash == true) {
               
                if (moveInput < 0) {
                    CreateDashKipin�();
                    direction = 1;
                    dash = true;
                    //dashBlock.SetActive(true);
                } else if (moveInput > 0) {
                    CreateDashKipin�();
                    direction = 2;
                    dash = true;
                    //dashBlock.SetActive(true);
                }  /*if (moveInputY > 0 || Input.GetKey(KeyCode.W)) {
                    //CreateDashKipin�();
                    dash = true;
                    direction = 3;
                }  if (moveInputY < 0 || Input.GetKey(KeyCode.S)) {
                    //CreateDashKipin�();
                    dash = true;
                    direction = 4;
                }*/
                canDash = false;
                StartCoroutine(DashTimer());
            }
        } else {
            if (dashTime <= 0) {
                dash = false;
                direction = 0;
                dashTime = startDashTime;
                velocity = Vector2.zero;
                dashBlock.SetActive(false);
            } else {
                dashTime -= Time.deltaTime;

                if (direction == 1) {
                    dashBlock.SetActive(true);
                    velocity = Vector2.left * dashSpeed;
                } else if (direction == 2) {
                    dashBlock.SetActive(true);
                    velocity = Vector2.right * dashSpeed;
                }/* else if (direction == 3) {
                    velocity = Vector2.up * dashSpeed;                  
                } else if (direction == 4) {
                    velocity = Vector2.down * dashSpeed;
                }*/
            }
        }
    }

    private IEnumerator DashTimer() {
        yield return new WaitForSeconds(1f);
        canDash = true;
    }

} // class