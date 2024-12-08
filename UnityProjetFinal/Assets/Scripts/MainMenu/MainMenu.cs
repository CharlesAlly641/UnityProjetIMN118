using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        // Cela load la prochaine scene lister apres celle-ci dans le build settings

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
