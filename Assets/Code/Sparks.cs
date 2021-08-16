using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public Transform player;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public float speed = 4f;

    //public GameObject shot;
    public Camera cam;

    public string horizontalAxis2 = "Horizontal2";
    public string verticalAxis2 = "Vertical2";
    private bool canShoot = true;

    public float lookAngle;
    private void Start() {
        //transform.rotation = Quaternion.Euler(0f, 0f, -45f);
        
    }

    void Update()
    {

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // normalize so going diagonally doesn't speed things up
        //Vector3 direction = new Vector3(h, v, 0f).normalized;

        //var dir = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")).normalized;

        //ProjectileKeys();
        ProjectileMouse();
    }

    private void ProjectileMouse() {
        if (timeBtwShots <= 0) {

            Vector3 shootDirection = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            //var difference = shootDirection - transform.position;
            
            lookAngle = (Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg) ;
            transform.rotation = Quaternion.Euler(0, 0, (lookAngle - 90) );
            if (Input.GetMouseButtonDown(0)) {
                AudioFW.Play("Spark1");
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, (lookAngle-90)/2  ));
                timeBtwShots = startTimeBtwShots;
            }

            } else {
            timeBtwShots -= Time.deltaTime;
        }
    }



    void ProjectileKeys() {
        if (timeBtwShots <= 0) {
            /*if (Input.GetKeyDown(KeyCode.X)) {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                //Instantiate(projectile,shotPoint.position,)
                timeBtwShots = startTimeBtwShots;
            }*/
            /*if (dir.magnitude > 0) {
                transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                Instantiate(projectile, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            } else {
                transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                Instantiate(projectile, transform.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }*/

            Vector2 shootDirection = Vector2.right * Input.GetAxis(horizontalAxis2) + Vector2.up * Input.GetAxis(verticalAxis2);
            if (shootDirection.sqrMagnitude > 0.0f) {
                AudioFW.Play("Spark1");
                transform.rotation = Quaternion.Euler(0, 0, shootDirection.x);
                float angle = Mathf.Atan2(Input.GetAxis(verticalAxis2), Input.GetAxis(horizontalAxis2)) * Mathf.Rad2Deg;
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0, 0, angle));
                timeBtwShots = startTimeBtwShots;

            }

            // this should be done again/ fixed
            if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 23f));
                timeBtwShots = startTimeBtwShots;
            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 23f));
                timeBtwShots = startTimeBtwShots;

            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, -23f));
                timeBtwShots = startTimeBtwShots;

            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, -23f));
                timeBtwShots = startTimeBtwShots;

            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 45f));
                timeBtwShots = startTimeBtwShots;
            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, -45f));
                timeBtwShots = startTimeBtwShots;
            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, -90f));
                timeBtwShots = startTimeBtwShots;
            } else if ((Input.GetKeyDown(KeyCode.X) || Input.GetButton("Fire")) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 0f));
                timeBtwShots = startTimeBtwShots;
            }


            /*if (Input.GetKeyDown(KeyCode.X) && Input.GetKey(KeyCode.W)) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 0f));
                timeBtwShots = startTimeBtwShots;
            } else


            if (Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X)) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 25f));
                timeBtwShots = startTimeBtwShots;
            } else

            if (Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.W) && player.localScale.x == 1) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, -45f));
                timeBtwShots = startTimeBtwShots;
            } else

            if (Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.W) && player.localScale.x == -1) {
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0f, 0f, 45f));
                timeBtwShots = startTimeBtwShots;
            }*/

        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
