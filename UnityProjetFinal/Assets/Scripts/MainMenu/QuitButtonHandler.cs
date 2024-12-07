using UnityEngine;

public class QuitButtonHandler : MonoBehaviour
{
    // Fonction appel�e lorsque le bouton Quitter est cliqu�
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Si on est dans l'�diteur, ferme l'application Unity
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Si on est en mode jeu, quitte compl�tement le jeu
        Application.Quit();
#endif
    }
}
