using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public GameObject levelMenu, deathMenu, levelEndMenu, pauseMenu, mixMenuStuff;
    public GameObject levelFirstButton, levelEndFirstButton, DeathFirstButton, PauseFirstButton;

    public GameObject lv1Score, lv2Score, lv3Score;

    public CanvasGroup closeLevelC, deathC;
    public float fadingSpeed = 0.5f;
    public bool fadeboolLevel, fadeboolDeath = false;

    public GameObject player;

    public GameObject[] levels;
    public GameObject[] locks;

    private void Start() {
        levels = GameObject.FindGameObjectsWithTag("Level");
        locks = GameObject.FindGameObjectsWithTag("Locks");
    }

    private void Update() {

        /*if(player.transform.position == levels[0].transform.position) {
            lv1Score.SetActive(true);
            lv2Score.SetActive(false);
            lv3Score.SetActive(false);
        } else if(player.transform.position == levels[1].transform.position) {
            lv1Score.SetActive(false);
            lv2Score.SetActive(true);
            lv3Score.SetActive(false);
        } else if (player.transform.position == levels[2].transform.position) {
            lv1Score.SetActive(false);
            lv2Score.SetActive(false);
            lv3Score.SetActive(true);
        }*/

        if (Input.GetKeyDown(KeyCode.U)) {
            UnlockAllLevels();
        }
            /*if (EventSystem.current.currentSelectedGameObject != null) {
            if(EventSystem.current.currentSelectedGameObject.name == "Level1Button") {
                lv1Score.SetActive(true);
                lv2Score.SetActive(false);
                lv3Score.SetActive(false);
            } else if (EventSystem.current.currentSelectedGameObject.name == "Level2Button") {
                lv1Score.SetActive(false);
                lv2Score.SetActive(true);
                lv3Score.SetActive(false);
            } else if (EventSystem.current.currentSelectedGameObject.name == "Level3Button") {
                lv1Score.SetActive(false);
                lv2Score.SetActive(false);
                lv3Score.SetActive(true);
            }
            //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }*/
    }


    public void OpenLevelMenu() {
            levelMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(levelFirstButton);
    }

    public void CloseLevelMenu() {
        levelMenu.SetActive(false);
    }

    public void OpenLevelEndMenu() {
            levelEndMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(levelEndFirstButton);
    }

    public void CloseLevelEndMenu() {
        levelEndMenu.SetActive(false);
    }

    public void OpenDeathMenu() {
        deathMenu.SetActive(true);
        
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(DeathFirstButton);
        
    }
    public void CloseDeathMenu() {
        deathMenu.SetActive(false);
    }

    public void OpenPauseMenu() {
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(levelEndFirstButton);
    }

    public void ClosePauseMenu() {
        pauseMenu.SetActive(false);
    }


    public void FadeDeathPanel() {
        //var CanvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(deathC, deathC.alpha, fadeboolDeath ? 1 : 0));
        fadeboolDeath = !fadeboolDeath;

    }

    public void FadeLevelEnd() {
        StartCoroutine(DoFade(closeLevelC, closeLevelC.alpha, fadeboolLevel ? 1 : 0));
        fadeboolLevel = !fadeboolLevel;

    }

    public void CloseMixedMenuStuff() {
        mixMenuStuff.SetActive(false);
    }

    public void OpenMixedMenuStuff() {
        mixMenuStuff.SetActive(true);
    }



    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end) {
        float counter = 0f;

        while(counter < fadingSpeed) {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / fadingSpeed);

            yield return null;
        }
    }

    public void UnlockAllLevels() {
        for (int j = 0; j < locks.Length; j++) {
            locks[j].SetActive(false);
        }

        for (int i= 0; i < levels.Length; i++) {
            levels[i].GetComponent<MovingOnLevelsMap>().locked = false;

        }
    }

} // class
