using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriviaGame.Database;

namespace TriviaGame.Gameplay
{
    public class Quiz : MonoBehaviour
    {
        [SerializeField] private Text questionText;
        [SerializeField] private Image hintImage;
        [SerializeField] private Button[] answerButtons;

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
            //foreach (Theme theme in DatabaseController.Instance.level)
            //{
            //    var tempButton = Instantiate(_themeButton, transform.position, Quaternion.identity);
            //    tempButton.name = theme.themeName;
            //    TMP_Text buttonText = tempButton.GetComponentInChildren<TMP_Text>();
            //    if (theme.isUnlocked)
            //    {
            //        buttonText.SetText($"{tempButton.name}");
            //    }
            //    else
            //    {
            //        buttonText.SetText($"Buy {tempButton.name} {theme.price}g");
            //    }
            //    tempButton.onClick.RemoveAllListeners();
            //    tempButton.onClick.AddListener(() =>
            //    {
            //        if (theme.isUnlocked)
            //        {
            //            ChangeTheme(tempButton.name);
            //        }
            //        else
            //        {
            //            UnlockTheme(tempButton.name, buttonText);
            //        }
            //    });
            //    tempButton.transform.SetParent(gameObject.transform);
            //}

            questionText.text = level.Question;
            answerButtons = new Button[level.Choice.Length];
            for (int i = 0; i < level.Choice.Length; i++)
            {
                Debug.Log("masuk");
                answerButtons[i] = Instantiate(Resources.Load<Button>(@"Prefabs/AnswerButton"), transform.position, Quaternion.identity);
                answerButtons[i].GetComponentInChildren<Text>().text = level.Choice[i];
                answerButtons[i].onClick.RemoveAllListeners();
                //temp.onClick.AddListener();
                answerButtons[i].transform.SetParent(gameObject.transform);
            }
        }
    }
}