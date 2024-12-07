using UnityEngine;

public class QuitButtonHandler : MonoBehaviour
{
    // Fonction appelée lorsque le bouton Quitter est cliqué
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Si on est dans l'éditeur, ferme l'application Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si on est en mode jeu, quitte complètement le jeu
        Application.Quit();
#endif
    }
}
