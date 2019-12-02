using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighscoreManager : Momo.PersistantMonoBehaviourSingleton<HighscoreManager>
{
    public GameObject highscoreLinePrefab = null;

    SpriteRenderer playerColor;

    [Serializable]
    struct HighscoreObj
    {
        public float height;
        public Color color;
        public HighscoreObj(float h, Color col)
        {
            height = h;
            color = col;
        }
    }
    
    [Serializable]
    class SaveCollection
    {
        public List<HighscoreObj> highscores = new List<HighscoreObj>();
    };
    SaveCollection saveCollection;

    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        EventManager.I.Events.StartListening("player_died", PlayerDied);
        EventManager.I.Events.StartListening("game_restart", ClearScores);

        playerColor = GameObject.Find("Player").GetComponent<SpriteRenderer>();

        Load();
        GenerateHighscoreLines();
    }

    private void PlayerDied(object obj)
    {
        saveCollection.highscores.Add(
                new HighscoreObj(
                    (int)Camera.main.transform.position.y,
                    playerColor.color
                )
            );

        Save();
    }

    private string GetSaveFilePath()
    {
        return Application.persistentDataPath + "/save.json";
    }

    private void Load()
    {
        if (!File.Exists(GetSaveFilePath()))
            return;
        using (StreamReader sr = new StreamReader(GetSaveFilePath()))
        {
            
            string json = sr.ReadToEnd();
            saveCollection = JsonUtility.FromJson<SaveCollection>(json);
        }

        if ( saveCollection == null)
            saveCollection = new SaveCollection();


    }

    private void GenerateHighscoreLines()
    {
        if (saveCollection == null || saveCollection.highscores == null)
            return;

        foreach (HighscoreObj i in saveCollection.highscores)
        {
            GameObject obj = Instantiate(highscoreLinePrefab);
            obj.transform.position = new Vector3(
                Camera.main.transform.position.x, 
                (float)i.height, 
                2);
            var sr = obj.GetComponent<SpriteRenderer>();
            if (sr)
                sr.color = i.color;


        }
    }

    private void Save()
    {
        if (!File.Exists(GetSaveFilePath())) 
            File.Create(GetSaveFilePath());

        using (StreamWriter sw = new StreamWriter(GetSaveFilePath()))
        {
            string json = JsonUtility.ToJson(saveCollection);
            sw.Write(json);
        }
    }

    public void ClearScores(object o)
    {
        saveCollection.highscores.Clear();
        Save();
    }
}
