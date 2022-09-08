using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.Database
{
    public class DatabaseController : MonoBehaviour
    {
        public static DatabaseController Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(base.gameObject);
            }
            else
            {
                Destroy(base.gameObject);
            }
        }

        public LevelStruct level;

        // Start is called before the first frame update
        void Start()
        {
            //level = new();
            //level.LevelID = "1";
            //level.PackID = "1";
            //level.Question = "contoh pertanyaan";
            //level.Hint = "gambar";
            //level.Choice[0] = "tes1";
            //Debug.Log(level.Choice[0]);
            //level.Choice[1] = "tes2";
            //level.Choice[2] = "tes3";
            //level.Choice[3] = "tes4";
            //level.answer = 1;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public string[] GetPackList()
        {
            return null;
        }

        public string[] GetLevelList(string packID)
        {
            return null;
        }

        //public LevelStruct GetLevelData(string levelID)
        //{
            
        //}
    }

    [System.Serializable]
    public struct LevelStruct
    {
        public string LevelID;
        public string PackID;
        public string Question;
        public string Hint;
        public string[] Choice;
        public int answer;

        public LevelStruct(string levelID, string packID, string question, string hint, string[] choice, int answer)
        {
            LevelID = levelID;
            PackID = packID;
            Question = question;
            Hint = hint;
            Choice = choice;
            this.answer = answer;
        }
    }
}