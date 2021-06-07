using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class AshTilesBehaviour : MonoBehaviour
{
    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Tilemap map;

    public SimplePlayerControllerDoubleJump playercontroller;
    public GameObject player;
    private void Start() {
        playercontroller = player.GetComponent<SimplePlayerControllerDoubleJump>();
        map = GetComponent<Tilemap>();
    }

    void Update()
    {
        /*Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.y -= 1;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.ashTile == true) {
            print(" tässä pitäisi olla ash tile");
            print(playergridPos);
            map.SetTile(map.WorldToCell(playergridPos), null);
            
        }*/

        DifferentDirectionAshX(-1);
        DifferentDirectionAshX(1);
        DifferentDirectionAshY(-1);
        DifferentDirectionAshY(1);
        //  print(playercontroller.dash);
    }

    void DifferentDirectionAshX(int added) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.x -= added;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.ashTile == true && playercontroller.dash == true) {
            map.SetTile(map.WorldToCell(playergridPos), null);
        }
    }

    void DifferentDirectionAshY(int added) {
        Vector2 playerPosition = player.transform.position;
        Vector3Int playergridPos = map.WorldToCell(playerPosition);
        playergridPos.y -= added;

        TileData data = mapManager.GetTileData(playergridPos);
        if (map.HasTile(playergridPos) && data.ashTile == true && playercontroller.dash == true) {
            map.SetTile(map.WorldToCell(playergridPos), null);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts) {
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                if (hitPosition.y < 0) {
                    hitPosition.y = hit.point.y - 1f;
                }
                if (hitPosition.x < 0) {
                    hitPosition.x = hit.point.x - 0f;
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

                if (map.HasTile(hitPosInt) && data.ashTile == true) {
                    map.SetTile(map.WorldToCell(hitPosInt), null);
                }
            }
        }
    }*/

    public Vector3Int ToInt3(Vector3 v) {
        return new Vector3Int((int)v.x, (int)v.y, (int)v.z);
    }



}
