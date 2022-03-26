using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine.SceneManagement;
public class SaveUI : MonoBehaviour
{
public static SaveUI instance;
    public SavesInfo activeInfo;
    public GameObject SavesMenu, alreadyExists;

    public TMP_Text Save1;
    public TMP_Text Save1x;
    public TMP_Text Save2;
    public TMP_Text Save2x;
    public TMP_Text Save3;
    public TMP_Text Save3x;
    public Button saveButton1;
    public Button saveButton2;
    public Button saveButton3;

    private string save1;
    private string save2;
    private string save3;
    int saveNumber;

    void Start()
    {
        LoadBinInfo();
        UpdateSaveText();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)){
        DeleteInfoBin();
        }
    }
   public void UpdateSaveText(){
       if(activeInfo.testbool1 == true){
           Save1.text = "Save1";
           Save1x.text = "Save1";
           saveButton1.interactable = true;
       }
        if(activeInfo.testbool2 == true){
           Save2.text = "Save2";
           Save2x.text = "Save2";
           saveButton2.interactable = true;
       }
        if(activeInfo.testbool3 == true){
           Save3.text = "Save3";
           Save3x.text = "Save3";
           saveButton3.interactable = true;
       }

   }
   public void LoadSave(string saveName){
       SaveManager.instance.activeSave.saveName = saveName;
        
        SaveManager.instance.LoadBin();
        if(saveName == "save1"){
            activeInfo.lastSaveNumb = 1;
        }
        if(saveName == "save2"){
            activeInfo.lastSaveNumb = 2;
        }
        if(saveName == "save3"){
            activeInfo.lastSaveNumb = 3;
        }
   }

    public void SaveBinInfo(){
    if(!Directory.Exists("FireSaves"))
        Directory.CreateDirectory("FireSaves");

    BinaryFormatter formatter = new BinaryFormatter();
    string dataPath = Application.persistentDataPath + "/fire" + SceneManager.GetActiveScene().buildIndex;

    FileStream stream = File.Create("FireSaves/" + activeInfo.saveNameInfo + ".bin");
    formatter.Serialize(stream, activeInfo);
    stream.Close();

}

public void LoadBinInfo(){

    BinaryFormatter formatter = new BinaryFormatter();

    FileStream stream = File.Open("FireSaves/" + activeInfo.saveNameInfo + ".bin", FileMode.Open);
    SavesInfo loadData = (SavesInfo) formatter.Deserialize(stream);
    activeInfo = loadData;
    stream.Close();

}

public void DeleteInfoBin(){
    if(System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeInfo.saveNameInfo + ".bin")){
        File.Delete(Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeInfo.saveNameInfo + ".bin");
    }
}


    public void CloseSavesMenu() {

        SavesMenu.SetActive(false);
    }

    public void OpenAlreadyExists() {

        alreadyExists.SetActive(true);
    }

    public void CloseAlreadyExists() {

        alreadyExists.SetActive(false);
    }

    public void CreateNewSave(int number){
        if(number == 1){
        if(activeInfo.testbool1 == false) {
        SaveManager.instance.activeSave.saveName = "save1";
        activeInfo.testbool1 = true;
        activeInfo.lastSaveNumb = 1;
        SaveBinInfo();
            } else {
                saveNumber = 1;
                OpenAlreadyExists();
                CloseSavesMenu();
                // jos on jo olemassa, kysy tuhontaanko vanha, tuhoa ja tee uusi save tämän tilalle
            }
        }

        if(number == 2){
        if(activeInfo.testbool2 == false) {
        SaveManager.instance.activeSave.saveName = "save2";
        activeInfo.testbool2 = true;
        activeInfo.lastSaveNumb = 2;
        SaveBinInfo();
            } else {
                saveNumber = 2;
                OpenAlreadyExists();
                CloseSavesMenu();
                // jos on jo olemassa, kysy tuhontaanko vanha, tuhoa ja tee uusi save tämän tilalle
            }
        }

        if(number == 3){
        if(activeInfo.testbool3 == false) {
        SaveManager.instance.activeSave.saveName = "save3";
        activeInfo.testbool3 = true;
        activeInfo.lastSaveNumb = 3;
        SaveBinInfo();
            }else {
                saveNumber = 3;
                OpenAlreadyExists();
                CloseSavesMenu();
                // jos on jo olemassa, kysy tuhontaanko vanha, tuhoa ja tee uusi save tämän tilalle
            }
        }
    }

    public void SaveOver1(){
        if(saveNumber == 1) {
        SaveManager.instance.activeSave.saveName = "save1";
        activeInfo.lastSaveNumb = 1;
        }
        if(saveNumber == 2) {
        SaveManager.instance.activeSave.saveName = "save2";
        activeInfo.lastSaveNumb = 2;
        }
        if(saveNumber == 3) {
        SaveManager.instance.activeSave.saveName = "save3";
        activeInfo.lastSaveNumb = 3;
        }
    }


} // class


[System.Serializable]
public class SavesInfo {


    public string saveNameInfo;
    public int lastSaveNumb;
    public bool testbool1;
    public bool testbool2;
    public bool testbool3;

}