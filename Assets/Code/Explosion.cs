using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Explosion : MonoBehaviour
{
    public Tilemap map;

    [SerializeField]
    private MapManager mapManager;

    [SerializeField]
    private Fire firePrefab;
    public FireManager fireManager;
    List<Vector3Int> trackedCells;
    public Vector3 hitPosition;
    public Transform player;

    void Start()
    {
        trackedCells = new List<Vector3Int>();
        map = GetComponent<Tilemap>();

    }

    // pit�isi saada kaikki ne tilet joihin explosion koskee ja sytytt�� kaikki ne tulee. Ei vain yksi piste.
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Explosion")) {


            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in collision.contacts) {
                // t�h�n ehk� jotain huomiota mist� suunnasta isku tulee. V�lill� tekee v��r�n muutoksen
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                //map.SetTile(map.WorldToCell(hitPosition), null);

                if (hitPosition.y < 0) {
                    hitPosition.y = hit.point.y - 1f;
                }
                if (hitPosition.x < 0) {
                    hitPosition.x = hit.point.x - 0f;
                }

                if (player.localScale.x == -1) {
                    //print(" scale -1");
                    if (hitPosition.x < 0) {
                        hitPosition.x = hit.point.x - 1f;
                    }
                }

                print(" explo  " + hitPosition);
                var hitPosInt = ToInt3(hitPosition);
                print(" explo  " + hitPosInt);
                TileData data = mapManager.GetTileData(hitPosInt);

                if (map.HasTile(hitPosInt) && data.canBurn == true) {
                    if (fireManager.activeFires.Contains(hitPosInt)) return; // ei sytytet� palavaa uudestaan
                    fireManager.SetTileOnFire(hitPosInt, data);
                }
            }
        }
    }



    public Vector3Int ToInt3(Vector3 v) {
        return new Vector3Int((int)v.x, (int)v.y, (int)v.z);
    }
}
