using System.Collections;
using System.Collections.Generic;
using System.IO;
using TriviaGame.ModuleCurrency;
using UnityEngine;

namespace TriviaGame.ModuleSaveData
{
    [System.Serializable]
    public class SaveDataModel
    {
        public int Coin;
        public string[] UnlockedPack;
        public string[] CompletedPack;
        public string[] CompletedLevel;
    }

    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Load();
                DontDestroyOnLoad(base.gameObject);
            }
            else
            {
                Destroy(base.gameObject);
            }
        }

        SaveDataModel savedData;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Save()
        {
            string data = JsonUtility.ToJson(savedData);
            PlayerPrefs.SetString("SaveData", data);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (!PlayerPrefs.HasKey("SaveData"))
            {
                Debug.Log("NotDetected");
                savedData = new();
                string data = JsonUtility.ToJson(savedData);
                PlayerPrefs.SetString("SaveData", data);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("Detected");
                savedData = JsonUtility.FromJson<SaveDataModel>(PlayerPrefs.GetString("SaveData"));
            }
        }
    }
}