using UnityEngine;

public class VictoryPopup : MonoBehaviour
{
    public GameObject victoryCanvas; // Référence au Canvas de victoire

    public void ShowVictoryPopup()
    {
        Time.timeScale = 0f; // Pause le jeu
        victoryCanvas.SetActive(true); // Affiche le canvas
    }
}
