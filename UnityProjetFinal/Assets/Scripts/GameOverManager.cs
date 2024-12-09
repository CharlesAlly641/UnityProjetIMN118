using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        /*
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;

        if(sceneName == "Niveau1")
            SceneManager.LoadScene("Niveau1"); 
        if(sceneName == "Niveau2")
            SceneManager.LoadScene("Niveau2");
        if(sceneName == "Niveau3")
            SceneManager.LoadScene("Niveau3");
        */
        SceneManager.LoadScene("MainMenu");
    }
}
