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
            Debug.LogError("L'objet avec le tag 'MustObject' est introuvable dans la sc�ne !");
        }
    }

    

    void Update()
    {
        // V�rifier si l'objet "MustObject" est d�truit
        if (mustObject == null)
        {
            // V�rifier si la position du personnage est la m�me que celle de "End"
            if ((endObject == null) || (endObject != null && Vector2.Distance(transform.position, endObject.transform.position) < 0.5f))
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("Partie termin�e !");
        // Vous pouvez ajouter une logique suppl�mentaire pour la fin de la partie (menu, redirection, etc.)
        Time.timeScale = 0; // Mettre le jeu en pause
    }
}

