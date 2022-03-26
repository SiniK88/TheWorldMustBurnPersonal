using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SetTilesOnFireCollision : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Tilemap map;
    public FireManager fireManager;
    //public SimplePlayerControllerDoubleJump playercontroller;
    public Vector3 hitPosition;
    public Transform player;

    void Start() {
        map = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            print("detects palo collider");
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts) {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                if (hitPosition.y < 0) {
                    hitPosition.y = hit.point.y - 1f;
                }
                if (hitPosition.x < 0) {
                    hitPosition.x = hit.point.x - 1f;
                }

                if (player.transform.localScale.x == -1) {
                    print(" scale -1");
                    if (hitPosition.x < 0) {
                        hitPosition.x = hit.point.x - 1f;
                    }
                }

                print(hitPosition);
                var hitPosInt = ToInt3(hitPosition);
                print(hitPosInt);
                TileData data = mapManager.GetTileData(hitPosInt);

                if (map.HasTile(hitPosInt) && data.canBurn == true) {
                    if (fireManager.activeFires.Contains(hitPosInt)) return; // ei sytytetä palavaa uudestaan
                    fireManager.SetTileOnFire(hitPosInt, data);
                }
            }
        }
    }
    public Vector3Int ToInt3(Vector3 v) {
        return new Vector3Int((int)v.x, (int)v.y, (int)v.z);
    }

}
