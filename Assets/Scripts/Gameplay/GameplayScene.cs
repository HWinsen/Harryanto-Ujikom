using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.PubSub;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        // Start is called before the first frame update
        void Start()
        {
            PublishSubscribe.Instance.Subscribe<MessageGameplayToLevel>(GoToLevelScene);
            PublishSubscribe.Instance.Subscribe<MessageGameplayToPack>(GoToPackScene);

            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() => GoToLevelScene(new MessageGameplayToLevel()));
        }

        private void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<MessageGameplayToLevel>(GoToLevelScene);
            PublishSubscribe.Instance.Unsubscribe<MessageGameplayToPack>(GoToPackScene);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void GoToLevelScene(MessageGameplayToLevel message)
        {
            SceneManager.LoadScene("Level");
        }

        public void GoToPackScene(MessageGameplayToPack message)
        {
            SceneManager.LoadScene("Pack");
        }
    }
}