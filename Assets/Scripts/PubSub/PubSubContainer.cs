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

    public struct MessageUnlockPack
    {
        public int packID;

        public MessageUnlockPack(int packID)
        {
            this.packID = packID;
        }
    }
}