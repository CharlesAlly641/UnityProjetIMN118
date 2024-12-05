using UnityEngine;

public class VictoryPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Vérifie si c'est le joueur
        {
            // Trouve le script de gestion de la victoire et affiche le pop-up
            FindObjectOfType<VictoryPopup>().ShowVictoryPopup();

            Destroy(gameObject); // Supprime la potion après l'avoir ramassée
        }
    }
}
