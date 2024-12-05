using UnityEngine;

public class VictoryPopup : MonoBehaviour
{
    public GameObject victoryCanvas; // Référence au Canvas de victoire
    public AudioSource backgroundMusic; // Référence à l'AudioSource de la musique de fond
    public AudioSource victorySFX; // Référence à l'AudioSource du SFX de victoire


    public void ShowVictoryPopup()
    {
        // Arrêter la musique de fond
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }

        // Jouer le SFX de victoire
        if (victorySFX != null)
        {
            victorySFX.Play();
        }

        // Afficher le Canvas de victoire et mettre le jeu en pause

        Time.timeScale = 0f; // Pause le jeu
        victoryCanvas.SetActive(true); // Affiche le canvas
    }
}
