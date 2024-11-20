using UnityEngine;

public class TriggerImageUI : MonoBehaviour
{
    [SerializeField] private GameObject imageUI; // Associez l'image UI via l'inspecteur

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp")) // V�rifie si le tag de l'objet contact� est "L"
        {
            if (imageUI != null) // V�rifie que l'image est assign�e
            {
                imageUI.SetActive(true); // Affiche l'image
            }
            else
            {
                Debug.LogWarning("Aucune image UI assign�e dans l'inspecteur !");
            }
        }
    }
}

