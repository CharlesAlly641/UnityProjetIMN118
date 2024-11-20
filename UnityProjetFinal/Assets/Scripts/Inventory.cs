using UnityEngine;

public class TriggerImageUI : MonoBehaviour
{
    [SerializeField] private GameObject imageUI; // Associez l'image UI via l'inspecteur

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PickUp")) // Vérifie si le tag de l'objet contacté est "L"
        {
            if (imageUI != null) // Vérifie que l'image est assignée
            {
                imageUI.SetActive(true); // Affiche l'image
            }
            else
            {
                Debug.LogWarning("Aucune image UI assignée dans l'inspecteur !");
            }
        }
    }
}

