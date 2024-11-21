using UnityEngine;

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
    }

    

    void Update()
    {
        // Vérifier si l'objet "MustObject" est détruit
        if (mustObject == null)
        {
            // Vérifier si la position du personnage est la même que celle de "End"
            if ((endObject == null) || (endObject != null && Vector2.Distance(transform.position, endObject.transform.position) < 0.5f))
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("Partie terminée !");
        // Vous pouvez ajouter une logique supplémentaire pour la fin de la partie (menu, redirection, etc.)
        Time.timeScale = 0; // Mettre le jeu en pause
    }
}

