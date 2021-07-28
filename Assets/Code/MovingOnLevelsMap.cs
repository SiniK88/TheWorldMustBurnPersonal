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

    [Header("Final Destinations")]
    public GameObject upDestinationFinal;
    public GameObject downDestinationFinal;
    public GameObject leftDestinationFinal;
    public GameObject rightDestinationFinal;


    [Header("Stuff")]
    public GameObject player;
    private bool canMove;
    public bool locked;

    [SerializeField] public bool currentLevel;

    public string levelName;
    public int levelNumber;
    public string levelCode;

    public LevelSelector levelSelector;
    public MenuNavigation menuNav;
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
            if(upDestination != null && upDestination.activeInHierarchy && upDestinationFinal.GetComponent<MovingOnLevelsMap>().locked == false) {
                currentLevel = false;
                StartCoroutine( Move( upDestination));
            }
        }

        else if(Input.GetAxis("Vertical") < 0) {
            if(downDestination != null && downDestinationFinal.GetComponent<MovingOnLevelsMap>().locked == false) {
                currentLevel = false;
                StartCoroutine(Move( downDestination));
            }
        }

        else if(Input.GetAxis("Horizontal") > 0) {
            if(rightDestination != null &&  rightDestinationFinal.GetComponent<MovingOnLevelsMap>().locked == false) {
                currentLevel = false;
                StartCoroutine(Move(rightDestination));
            }
        }else if(Input.GetAxis("Horizontal") < 0) {
            if(leftDestination != null &&  leftDestinationFinal.GetComponent<MovingOnLevelsMap>().locked == false) {
                currentLevel = false;
                StartCoroutine( Move(leftDestination));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            SelectLevel(1);
            SelectLevel(2);
            SelectLevel(3);


            //if (currentLevel == true && levelNumber == 1) {
            //    levelSelector.LoadLevel1();
            //}
            //if (currentLevel == true && levelNumber == 2) {
            //    levelSelector.LoadLevel2();
            //}
            //if (currentLevel == true && levelNumber == 3) {
            //    levelSelector.LoadLevel3();
            //}
        }
    }

    IEnumerator Move( GameObject direction ) {
        yield return new WaitForSeconds(1 / 60);
        while (player.transform.position != direction.transform.position) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, direction.transform.position, 3f * Time.deltaTime);
            yield return null;
        }
    }

    private void SelectLevel(int i) {
        if(currentLevel == true && levelNumber == i && locked == false) {
            menuNav.CloseLevelMenu();
            menuNav.CloseMixedMenuStuff();
            if(i == 1) {
                levelSelector.LoadLevel1();
            }
            if(i == 2) {
                levelSelector.LoadLevel2();
            }
            if(i == 3) {
                levelSelector.LoadLevel3();
            }
        }
    }

  
} // class
