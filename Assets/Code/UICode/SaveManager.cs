using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData activeSave;
    public bool hasLoaded;
    StoreScores storeScores;
    private void Awake() {
        storeScores = FindObjectOfType<StoreScores>();
        var level = storeScores.levels;
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            //Save();
            SaveBin();
        }

        if(Input.GetKeyDown(KeyCode.L)){
        //Load();
        LoadBin();
        }

        if(Input.GetKeyDown(KeyCode.H)){
        DeleteSavedDataBin();
        }
    }

public void Save(){
    string dataPath = Application.persistentDataPath;

    var serializer = new XmlSerializer(typeof(SaveData));
    var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
    serializer.Serialize(stream, activeSave);
    stream.Close();

    Debug.Log("saved");
}

public void SaveBin(){
    if(!Directory.Exists("FireSaves"))
        Directory.CreateDirectory("FireSaves");

    BinaryFormatter formatter = new BinaryFormatter();
    string dataPath = Application.persistentDataPath + "/fire" + SceneManager.GetActiveScene().buildIndex;

    FileStream stream = File.Create("FireSaves/" + activeSave.saveName + ".bin");
    formatter.Serialize(stream, activeSave);
    stream.Close();

    Debug.Log("saved to " + Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeSave.saveName + " .bin");
}


public void Load(){
    string dataPath = Application.persistentDataPath;

    if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save")){
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("loaded");
            hasLoaded = true;
    }
}

public void LoadBin(){

    BinaryFormatter formatter = new BinaryFormatter();

    FileStream stream = File.Open("FireSaves/" + activeSave.saveName + ".bin", FileMode.Open);
    SaveData loadData = (SaveData) formatter.Deserialize(stream);
    activeSave = loadData;
    stream.Close();

    Debug.Log("loaded " + Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeSave.saveName + " .bin");
    hasLoaded = true;
}



public void DeleteSavedData(){
    string dataPath = Application.persistentDataPath;
    if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save")){
        File.Delete(dataPath + "/" + activeSave.saveName + ".save");
    }
}



public void DeleteSavedDataBin(){
    if(System.IO.File.Exists(Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeSave.saveName + ".bin")){
        File.Delete(Directory.GetCurrentDirectory().ToString() + "FireSaves/" + activeSave.saveName + ".bin");
    }
}

    
} // class



[System.Serializable]
public class SaveData {


    public string saveName;
    public float[] respawnPosition = new float[3];
    public int test;
    public float[] bronceHighScoresSave = new float[20];
    public float[] silverHighScoresSave = new float[20];
    public float[] goldHighScoresSave = new float[20];

    public float[] bronceHighSecondsSave = new float[20];
    public float[] silverHighSecondsSave = new float[20];
    public float[] goldHighSecondsSave = new float[20];


}