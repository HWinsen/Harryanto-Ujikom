using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriviaGame.ModuleCurrency
{
    public class CurrencyModel
    {
        public int Coin { private set; get; }
    }

    public class Currency : MonoBehaviour
    {
        public static Currency Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(base.gameObject);
            }
            else
            {
                Destroy(base.gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public int GetCoin()
        {
            return 0;
        }

        public void AddCoin(int amount)
        {

        }

        public bool SpendCoin(int amount)
        {
            return true;
        }
    }
}