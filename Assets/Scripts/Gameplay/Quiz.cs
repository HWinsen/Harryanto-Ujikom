using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriviaGame.Database;
using Agate.MVC.Core;
using TriviaGame.PubSub;
using UnityEngine.Events;

namespace TriviaGame.Gameplay
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private Text questionText;
        [SerializeField] private Image hintImage;
        [SerializeField] private Button[] answerButtons;
        private UnityAction actionClick;

        // Start is called before the first frame update
        void Start()
        {
            InitQuiz(DatabaseController.Instance.level);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void InitQuiz(LevelStruct level)
        {
            questionText.text = level.Question;

            hintImage.sprite = Resources.Load<Sprite>(@"Sprites/Level Pack A/" + level.Hint);

            answerButtons = GetComponentsInChildren<Button>();
            
            for (int i = 0; i < answerButtons.Length; i++)
            {
                int x = i+1;
                answerButtons[i].GetComponentInChildren<Text>().text = level.Choice[i];
                
                answerButtons[i].onClick.RemoveAllListeners();
                
                answerButtons[i].onClick.AddListener(() =>
                {
                    PublishSubscribe.Instance.Publish<MessageStopCountdown>(new MessageStopCountdown());

                    PublishSubscribe.Instance.Publish<MessageAnswerQuestion>(new MessageAnswerQuestion(x));
                });
                answerButtons[i].transform.SetParent(gameObject.transform);
                
            }
        }
    }
}