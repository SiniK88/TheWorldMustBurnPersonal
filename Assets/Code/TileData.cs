using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;
    //public TileBase[] burnedTiles; ideana että jokaisella tilellä olisi data burnedtiles. Tässä esim gameobject johon prafab.
    public GameObject burned;
    
    public float spreadChange = 100; 
    public float spreadInterwall, burnTime;
    public bool canBurn, ashTile, groudTile, waterTile, leavesTile, secret;


}
