using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SparksMoving : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float lifeTime;
    Vector3 lastVelocity;
    public bool goingUp = true;
    public Vector3 launchDirection;

    public GameObject player;
    public Transform projectileEndParticle;


    public Tilemap map;

    [SerializeField]
    private MapManager mapManager;

    public FireManager fireManager;

    [SerializeField]
    private GameObject explosionPre, explosionPreSmall, explosionPreSmallest;

    public Vector3 hitPosition;

    public float burnRadius = 1.5f;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        var scalepar = player.transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();

        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Tilemap>();
        mapManager = GameObject.FindGameObjectWithTag("MapManager").GetComponent<MapManager>();
        fireManager = GameObject.FindGameObjectWithTag("FireManager").GetComponent<FireManager>();
        //rb.velocity = launchDirection.normalized * speed;
        /*
        if(scalepar == -1) {
            launchDirection.x = -20f;
            rb.velocity = launchDirection.normalized * speed;
        }
        else rb.velocity = launchDirection.normalized * speed;
        */
        Invoke("DestroySpark", lifeTime);
    }
    void Update()
    {
        BurnFromObjectPosition();
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    void DestroySpark() {
        var projectileEndParticleclone = Instantiate(projectileEndParticle, transform.position, transform.rotation);
        Destroy(projectileEndParticleclone.gameObject,1);
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
    print("osui johonkin");

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
        DestroySpark();
    }

    void BurnFromObjectPosition() {
        Vector2 playerPosition = transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);

        int gr = Mathf.FloorToInt(burnRadius + 0.5f);
        var bounds = new BoundsInt(playergridPos.x - gr, playergridPos.y - gr, 0, gr * 2 + 1, gr * 2 + 1, 1);
        var rsq = burnRadius * burnRadius;

        foreach (var gpos in bounds.allPositionsWithin) {
            var pos = (Vector2)map.CellToWorld(gpos) + Vector2.one * 0.5f;
            TileData data = mapManager.GetTileData(gpos);
            if (rsq >= (playerPosition - pos).sqrMagnitude) {

                Debug.DrawLine(playerPosition, pos, Color.white);
                if (map.HasTile(gpos) && data.canBurn == true) {
                    if (fireManager.activeFires.Contains(gpos)) return; // ei sytytetä palavaa uudestaan
                    fireManager.SetTileOnFire(gpos, data);
                }
            } else Debug.DrawLine(playerPosition, pos, Color.red);
        }
    }
}
