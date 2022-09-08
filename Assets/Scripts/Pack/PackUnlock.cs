using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using TriviaGame.PubSub;
using UnityEngine;

namespace TriviaGame.Pack
{
    public class PackUnlock : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            PublishSubscribe.Instance.Subscribe<MessageUnlockPack>(UnlockPack);
        }

        private void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<MessageUnlockPack>(UnlockPack);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void UnlockPack(MessageUnlockPack message)
        {
            Debug.Log("packID " + message.packID + " unlocked");
        }
    }
}