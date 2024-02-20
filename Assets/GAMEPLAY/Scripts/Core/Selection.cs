using BG.Core;
using RPGCharacterAnims.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BGCore
{
    public class Selection : MonoBehaviour
    {
        public GameObject[] characters;
        public int selectedCharacter = 0;
        [SerializeField] Light mageSpot;
        [SerializeField] Light warriorSpot;
        [SerializeField] Sprite warrior;
        [SerializeField] Sprite mage;

        [SerializeField] Button buttonPlay;
        private void Start()
        {
            mageSpot.enabled = false;
            warriorSpot.enabled = false;
            buttonPlay.gameObject.active = false;
        }
        private void Update()
        {
            Debug.Log(selectedCharacter);
        }
        public void MageSelected()
        {
            buttonPlay.gameObject.active = true;
            buttonPlay.image.sprite = mage;
            warriorSpot.enabled = false;
            mageSpot.enabled = true;
            selectedCharacter = 0;
        }

        public void WarriorSelected()
        {
            buttonPlay.gameObject.active = true;
            buttonPlay.image.sprite = warrior;
            mageSpot.enabled = false;
            warriorSpot.enabled = true;           
            selectedCharacter = 1;
        }

        public void StartGame()
        {
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
