using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Home
{
    public class HomeScene : MonoBehaviour
    {
        [SerializeField] Button playButton;

        // Start is called before the first frame update
        void Start()
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(StartPlay);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void StartPlay()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}