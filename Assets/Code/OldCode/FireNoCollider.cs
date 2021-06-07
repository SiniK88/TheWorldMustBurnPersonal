using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNoCollider : MonoBehaviour
{
    private Vector3Int position;
    TileData data;
    FireManager fireManager;

    private float burnTimeCounter, spreadInterwallCounter;

    /*public void StartBurningNoCol(Vector3Int position, TileData data, FireManager fm) {
        this.position = position;
        this.data = data;
        fireManager = fm;

        burnTimeCounter = data.burnTime;
        spreadInterwallCounter = data.spreadInterwall;
    }

    private void Update() {
        burnTimeCounter -= Time.deltaTime;
        if (burnTimeCounter <= 0) {
            fireManager.FinishedBurningNoCol(position);
            Destroy(gameObject);
        }

        spreadInterwallCounter -= Time.deltaTime;
        if (spreadInterwallCounter <= 0) {
            spreadInterwallCounter = data.spreadInterwall;
            fireManager.TryToSpreadNoCol(position, data.spreadChange);
            fireManager.TryToSpread(position, data.spreadChange);
        }

    }*/
}
