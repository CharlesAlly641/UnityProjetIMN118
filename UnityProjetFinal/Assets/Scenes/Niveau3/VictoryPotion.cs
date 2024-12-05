using UnityEngine;

public class VictoryPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // V�rifie si c'est le joueur
        {
            // Trouve le script de gestion de la victoire et affiche le pop-up
            FindObjectOfType<VictoryPopup>().ShowVictoryPopup();

            Destroy(gameObject); // Supprime la potion apr�s l'avoir ramass�e
        }
    }
}
