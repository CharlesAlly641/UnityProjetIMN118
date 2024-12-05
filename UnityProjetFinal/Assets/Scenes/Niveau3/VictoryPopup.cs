using UnityEngine;

public class VictoryPopup : MonoBehaviour
{
    public GameObject victoryCanvas; // R�f�rence au Canvas de victoire

    public void ShowVictoryPopup()
    {
        Time.timeScale = 0f; // Pause le jeu
        victoryCanvas.SetActive(true); // Affiche le canvas
    }
}
