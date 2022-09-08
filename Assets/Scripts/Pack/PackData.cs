using System.Collections;
using System.Collections.Generic;
using TMPro;
using TriviaGame.Database;
using UnityEngine;
using UnityEngine.UI;

namespace TriviaGame.Pack
{
    [System.Serializable]
    public class PackDataModel
    {
        public string PackID;
        public string PackName;
        public bool IsCompleted;
        public bool IsUnlocked;
        public int UnlockCost;

        public PackDataModel(string packID, string packName, bool isCompleted, bool isUnlocked, int unlockCost)
        {
            PackID = packID;
            PackName = packName;
            IsCompleted = isCompleted;
            IsUnlocked = isUnlocked;
            UnlockCost = unlockCost;
        }
    }

    public class PackData : MonoBehaviour
    {
        [SerializeField] private TMP_Text packNameLabel;
        [SerializeField] private TMP_Text unlockCostLabel;
        [SerializeField] private Button selectionButton;
        [SerializeField] private Button unlockButton;
        [SerializeField] private Image completeImage;
        [SerializeField] private PackDataModel[] packDataModels;

        // Start is called before the first frame update
        void Start()
        {
            InitPackList(packDataModels);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadPackList()
        {
            packDataModels = GetPackList();
        }

        public PackDataModel[] GetPackList()
        {
            // ambil data dari json
            return null;
        }

        public void InitPackList(PackDataModel[] packs)
        {
            Debug.Log("test");
            for (int i = 0; i < packs.Length; i++)
            {
                Button tempButton = Instantiate(selectionButton, transform.position, Quaternion.identity);
                tempButton.transform.SetParent(gameObject.transform);

                tempButton.onClick.RemoveAllListeners();
                tempButton.onClick.AddListener(() =>
                {
                    DatabaseController.Instance.GetLevelList(i.ToString());
                });

                TMP_Text tempPackLabel = Instantiate(packNameLabel, transform.position, Quaternion.identity);
                tempPackLabel.SetText(packs[i].PackName);
                tempPackLabel.transform.SetParent(tempButton.transform);
                if (packs[i].IsUnlocked == false)
                {
                    tempButton.interactable = false;
                    //tempButton.GetComponent<Image>().color = Color.grey;
                    Button tempUnlockButton = Instantiate(unlockButton, transform.position, Quaternion.identity);
                    tempUnlockButton.transform.SetParent(tempButton.transform);
                    TMP_Text tempUnlockCostLabel = Instantiate(unlockCostLabel, transform.position, Quaternion.identity);
                    tempUnlockCostLabel.SetText($"{packs[i].UnlockCost}");
                    tempUnlockCostLabel.transform.SetParent(tempUnlockButton.transform);
                }
                else if (packs[i].IsCompleted)
                {
                    Image tempImage = Instantiate(completeImage, transform.position, Quaternion.identity);
                    tempImage.transform.SetParent(tempButton.transform);
                }
            }
        }
    }
}