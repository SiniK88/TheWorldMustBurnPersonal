using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOnLevelsCorner : MonoBehaviour
{
    public GameObject destination;
    //public GameObject reverseDestination;
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if(transform.position == player.transform.position) {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move() {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != destination.transform.position) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, destination.transform.position, 5f * Time.deltaTime);
            yield return null;
        }
    }
}
