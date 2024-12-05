using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryButtons : MonoBehaviour
{
    
    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Relance le temps
        SceneManager.LoadScene("MainMenu"); // Charge la scène du menu principal
    }
}
