using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TriviaGame.Pack
{
    public class PackScene : MonoBehaviour
    {
        [SerializeField] private Button backButton;

        // Start is called before the first frame update
        void Start()
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(GoBack);
        }


        // Update is called once per frame
        void Update()
        {

        }

        public void GoBack()
        {
            SceneManager.LoadScene("Home");
        }

        public void SelectPack(string packID)
        {

        }
    }
}