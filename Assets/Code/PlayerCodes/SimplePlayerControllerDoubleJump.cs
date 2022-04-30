using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerControllerDoubleJump : MonoBehaviour
{
    Rigidbody2D rb;
    [Range(1f, 10f)] public float jumpForce = 5f;
    [Range(1f, 30f)] public float horizontal = 5f;
    [Range(1f, 30f)] public float horizontalMaxSpeed = 5f;

    [SerializeField] int maxJumps = 2;
    [SerializeField] int jumps = 0;

    [SerializeField]
    [Range(1f, 60f)] float dashSpeed;

    [SerializeField]
    [Range(0f, 2f)] float dashTime;

    public float startDashTime;
    private int direction;
    public bool isDashButtonDown;
    public bool dash = false;

    float moveInput;
    float moveInputY;
    Vector2 dashDir;

    public bool grounded;

    public Camera mainCamera;
    Vector3 cameraPos;
    public ParticleSystem kipinä; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (mainCamera) {
            cameraPos = mainCamera.transform.position;
        }
        dashTime = startDashTime; 
    }

    void Update()
    {

        // flip character
        Vector3 characterScale = transform.localScale;
        if(Input.GetAxis("Horizontal") < 0) {
            characterScale.x = -1;
        }
        if( Input.GetAxis("Horizontal") > 0) {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;



        if(grounded == true) {
            jumps = 0;
        }

        if(Input.GetButtonDown("Jump") && jumps < maxJumps) {
            
            grounded = false;
            jumps++;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            CreateKipinä();
        } //else if(Input.GetButtonDown("Jump") && maxJumps == 0 && grounded == true) {
            //rb.velocity = Vector2.up * jumpForce;
        //}

        if (mainCamera) {
            mainCamera.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y, cameraPos.z);
        }

        /*if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isDashButtonDown = true;
        }*/

        //dashDir.x = Input.GetAxisRaw("Horizontal");
        //dashDir.y = Input.GetAxisRaw("Vertical");
        moveInput = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInput * horizontal, rb.velocity.y);
        if (moveInput > 0f) {
            gameObject.transform.localScale = new Vector2(1, gameObject.transform.localScale.y);
        } else if (moveInput < 0f) {
            gameObject.transform.localScale = new Vector2(-1, gameObject.transform.localScale.y);
        }


        if (direction == 0) {
            
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                if(moveInput < 0) {
                    direction = 1;
                    dash = true;
                } else if(moveInput > 0) {
                    direction = 2;
                    dash = true;
                } else if(moveInputY > 0) {
                    dash = true;
                    direction = 3;
                } else if( moveInputY < 0) {
                    dash = true;
                    direction = 4;
                }
            }
        } else {
            if(dashTime <= 0) {
                dash = false;
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            } else {
                dashTime -= Time.deltaTime;

                if(direction == 1) {
                    
                    rb.velocity = Vector2.left * dashSpeed;
                } else if( direction == 2) {
                   
                    rb.velocity = Vector2.right * dashSpeed;
                } else if(direction == 3) {
                    rb.velocity = Vector2.up * dashSpeed;
                } else if(direction == 4) {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
        
    }

    private void FixedUpdate() {



        /*if(isDashButtonDown == true) {
            rb.MovePosition(rb.position + dashDir * dashSpeed  );
            
            isDashButtonDown = false;
        }*/
    }

    void CreateKipinä() {
        kipinä.Play();
    }
}
