using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BGCore
{
    public class Menu : MonoBehaviour
    {
        public void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
