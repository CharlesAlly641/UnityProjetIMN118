using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour gérer les scènes

public class EndGameOnConditions : MonoBehaviour
{
    private GameObject mustObject;
    private GameObject endObject;

    void Start()
    {
        mustObject = GameObject.FindWithTag("MustObject");
        endObject = GameObject.FindWithTag("End");

        if (mustObject == null)
        {
            Debug.LogError("L'objet avec le tag 'MustObject' est introuvable dans la scène !");
        }

        if (endObject == null)
        {
            Debug.LogError("L'objet avec le tag 'End' est introuvable dans la scène !");
        }
    }

    void Update()
    {
        // Vérifier si l'objet "MustObject" est détruit
        if (mustObject == null)
        {
            // Vérifier si la position du joueur est proche de "End"
            if ((endObject != null) && Vector2.Distance(transform.position, endObject.transform.position) < 1.0f)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        Debug.Log("Chargement du niveau suivant...");
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Vérifier si un niveau suivant existe
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Charger la prochaine scène
        }
        else
        {
            Debug.Log("Vous avez terminé tous les niveaux !");
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Partie terminée !");
        Time.timeScale = 0; // Mettre le jeu en pause ou afficher un écran de fin
    }
}
