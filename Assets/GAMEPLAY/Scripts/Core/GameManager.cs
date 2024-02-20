using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

namespace BGCore
{
    public class GameManager : MonoBehaviour
    {

        
        

        [SerializeField] GameObject[] characterPrefabs;
        [SerializeField] GameObject boss;
        Health health;
        GameObject prefab;

        public GameObject Prefab
        {
            get => prefab;
        }
        private void Awake()
        {
            health = boss.GetComponent<Health>();
            int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
            prefab = characterPrefabs[selectedCharacter];
            prefab.SetActive(true);
        }


        private void Update()
        {
            if (health.CurrentHealth == 0)
            {
                StartCoroutine(EndGame());
            }
        }

        IEnumerator EndGame()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
