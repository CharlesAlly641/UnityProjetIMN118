using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartLevel()
    {
        // Charger la dernière scène sauvegardée
        string lastScene = PlayerPrefs.GetString("LastScene", "DefaultSceneName");
        SceneManager.LoadScene(lastScene);
    }
}
