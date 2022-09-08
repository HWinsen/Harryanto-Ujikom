using Agate.MVC.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.PubSub;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Gameplay
{
    public class Countdown : MonoBehaviour
    {
        private float Remaining;
        private Text countdownText;
        private Slider countdownSlider;

        // Start is called before the first frame update
        void Start()
        {
            Remaining = 30;

            //countdownText = GetComponent<Text>();
            countdownText = GetComponentInChildren<Text>();
            countdownText.text = Remaining.ToString();

            countdownSlider = GetComponentInChildren<Slider>();
            countdownSlider.maxValue = Remaining;
            countdownSlider.value = Remaining;

            this.enabled = true;

            PublishSubscribe.Instance.Subscribe<MessageStopCountdown>(StopCountdown);
        }

        private void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<MessageStopCountdown>(StopCountdown);
        }

        // Update is called once per frame
        void Update()
        {
            if (Remaining > 0)
            {
                StartCountdown();
            }
            else
            {
                FinishCountdown();
            }
        }

        public void StartCountdown()
        {
            //Debug.Log(Convert.ToInt64(Time.deltaTime));

            //string timeString = string.Format("{0:0.0000}", Time.deltaTime);
            //Remaining -= long.Parse(timeString.Replace(".", ""));

            //Remaining -= Convert.ToInt64(Time.deltaTime);
            //Remaining -= Time.deltaTime;

            //float tempSec = 0;
            //tempSec += Time.deltaTime;
            //Remaining -= Convert.ToInt64(MathF.Round(tempSec));
            //if (tempSec > 1) tempSec = 0;
            //Debug.Log(tempSec);

            Remaining -= Time.deltaTime;
            countdownText.text = Remaining.ToString();
            countdownSlider.value = Remaining;
        }

        public void StopCountdown(MessageStopCountdown message)
        {
            this.enabled = false;
        }

        public void FinishCountdown()
        {
            countdownText.text = "0";
            this.enabled = false;
            PublishSubscribe.Instance.Publish<MessageTimeOut>(new MessageTimeOut());
        }
    }
}