using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.PubSub;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TriviaGame.Gameplay
{
    public class GameFlow : MonoBehaviour
    {
        public static GameFlow Instance;

        private void Awake()
        {
            //if (Instance == null)
            //{
            //    Instance = this;
            //    DontDestroyOnLoad(base.gameObject);
            //}
            //else
            //{
            //    Destroy(base.gameObject);
            //}
            Instance = this;
        }

        

        // Start is called before the first frame update
        void Start()
        {
            PublishSubscribe.Instance.Subscribe<MessageTimeOut>(Timeout);
        }

        private void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<MessageTimeOut>(Timeout);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AnswerQuestion(int answer)
        {

        }

        public void Timeout(MessageTimeOut message)
        {
            Debug.Log("Timeout");
            SceneManager.LoadScene("Level");
        }
    }
}