using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour g�rer les sc�nes

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
            Debug.LogError("L'objet avec le tag 'MustObject' est introuvable dans la sc�ne !");
        }

        if (endObject == null)
        {
            Debug.LogError("L'objet avec le tag 'End' est introuvable dans la sc�ne !");
        }
    }

    void Update()
    {
        // V�rifier si l'objet "MustObject" est d�truit
        if (mustObject == null)
        {
            // V�rifier si la position du joueur est proche de "End"
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

        // V�rifier si un niveau suivant existe
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Charger la prochaine sc�ne
        }
        else
        {
            Debug.Log("Vous avez termin� tous les niveaux !");
            EndGame();
        }
    }

    private void EndGame()
    {
        Debug.Log("Partie termin�e !");
        Time.timeScale = 0; // Mettre le jeu en pause ou afficher un �cran de fin
    }
}
