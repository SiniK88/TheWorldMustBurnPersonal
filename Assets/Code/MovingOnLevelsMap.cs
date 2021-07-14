using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingOnLevelsMap : MonoBehaviour
{

    [Header("Destinations")]
    public GameObject upDestination;
    public GameObject downDestination;
    public GameObject leftDestination;
    public GameObject rightDestination;


    [Header("Stuff")]
    public GameObject player;
    private bool canMove;
    public bool locked;

    [SerializeField] public bool currentLevel;

    public string levelName;
    public int levelNumber;
    public string levelCode;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position == transform.position) {
            currentLevel = true;
        }

        if(currentLevel == true && locked == false) {
            // press something and level loads
        }

        if((Input.GetAxis("Vertical") > 0)) {
            if(upDestination != null && upDestination.activeInHierarchy) {
                currentLevel = false;
                StartCoroutine( Move( upDestination));
            }
        }

        else if(Input.GetAxis("Vertical") < 0) {
            if(downDestination != null && downDestination.activeInHierarchy) {
                currentLevel = false;
                StartCoroutine(Move( downDestination));
            }
        }

        else if(Input.GetAxis("Horizontal") > 0) {
            if(rightDestination != null && rightDestination.activeInHierarchy) {
                currentLevel = false;
                StartCoroutine(Move(rightDestination));
            }
        }else if(Input.GetAxis("Horizontal") < 0) {
            if(leftDestination != null && leftDestination.activeInHierarchy) {
                currentLevel = false;
                StartCoroutine( Move(leftDestination));
            }
        }
    }

    IEnumerator Move( GameObject direction ) {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != direction.transform.position) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, direction.transform.position, 3f * Time.deltaTime);
            yield return null;
        }
    }

  
} // class
