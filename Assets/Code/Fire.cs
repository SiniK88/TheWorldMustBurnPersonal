using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector3Int position;
    TileData data;
    FireManager fireManager;

    private float burnTimeCounter, spreadInterwallCounter;
        
    public void StartBurning(Vector3Int position, TileData data, FireManager fm) {
        this.position = position;
        this.data = data;
        fireManager = fm;

        burnTimeCounter = data.burnTime;
        spreadInterwallCounter = data.spreadInterwall;
    }

    private void Update() {
        burnTimeCounter -= Time.deltaTime;
        if(burnTimeCounter <= 0) {
            fireManager.FinishedBurning(position);
            Destroy(gameObject);
        }

        spreadInterwallCounter -= Time.deltaTime;
        if(spreadInterwallCounter <= 0) {
            spreadInterwallCounter = data.spreadInterwall;
            fireManager.TryToSpread(position, data.spreadChange);
            //fireManager.TryToSpreadNoCol(position, data.spreadChange);
        }

    }

}
