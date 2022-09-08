using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.PubSub
{
    public class PubSubContainer
    {

    }

    public struct MessageTimeOut { }
    public struct MessageStopCountdown { }

    public struct MessageAnswerQuestion
    {
        public int answer;

        public MessageAnswerQuestion(int answer)
        {
            this.answer = answer;
        }
    }

    public struct MessageUnlockPack
    {
        public int packID;

        public MessageUnlockPack(int packID)
        {
            this.packID = packID;
        }
    }

    public struct MessageGameplayToLevel { }
    public struct MessageGameplayToPack { }
}