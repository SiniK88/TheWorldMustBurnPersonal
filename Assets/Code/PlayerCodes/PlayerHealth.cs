using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    public Tilemap map;

    public GameObject player;
    public int health = 1;
    public float timer = 1f;

    public MenuNavigation menuNav;
    RayCastPlayer playerController;
    public Transform DeathParticle;

    public Image fadeIm;
    public Animator anim;
    bool fadebool = false;
    PlayLoops playLoops;
    void Start() {
        //DeathUI = GameObject.Find("Menu");
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        menuNav = FindObjectOfType<MenuNavigation>();
        playerController = FindObjectOfType<RayCastPlayer>();
        playLoops = FindObjectOfType<PlayLoops>();

        //fade = FindObjectOfType<FadePanel>();
    }

    // Update is called once per frame
    void Update()
    {
        TouchWaterY(1);
        if(health == 0) {
            if (timer > 0) {
                timer -= Time.deltaTime;
                if (timer <= 0) {
                    timer = 0;
                    menuNav.FadeDeathPanel();
                }
            }
        }
    }
    public void Damaged(int damage) {
        
        health -= damage;
        playLoops.StopLevelMusic();
        if (health <= 0) {
            health = 0;
            // kuolema animaatio
            if (fadebool == false) {
                DestroySpark();
                fadebool = true;
                AudioFW.Play("Death");
            }
            player.GetComponent<RayCastPlayer>().enabled = false;
            //playerController.DeathAnim();
            //anim.Play("FadeIn");
            anim.Play("FadeOut");
            Destroy(transform.parent.gameObject, 3f);
            menuNav.OpenDeathMenu();

        }
    }

    // damege tarvii myös timerin jos voi ottaa enemmän kuin yhden damagen
    void TouchWaterY(int damage) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.y -= 1;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.waterTile == true) {
            Damaged(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Water")){
            Damaged(1);
        }
    }
    void DestroySpark() {
        var projectileEndParticleclone = Instantiate(DeathParticle, transform.position, transform.rotation);
        Destroy(projectileEndParticleclone.gameObject, 1);
        //Destroy(projectileEndParticleclone);
    }


    IEnumerator FadingImage() {
        yield return null;

    }


    public void FadeInanim() {
            anim.Play("FadeIn");

    }
    public void FadeOut() {
        anim.Play("FadeOut");

    }
}
