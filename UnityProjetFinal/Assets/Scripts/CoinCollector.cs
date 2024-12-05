using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int totalCoinsCollected = 0; // Compteur de pièces collectées

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet en collision a le tag "coin"
        if (collision.CompareTag("coin"))
        {
            totalCoinsCollected++; // Incrémente le compteur
            Debug.Log("Total coins collected: " + totalCoinsCollected);

            // Optionnel : Détruire l'objet "coin" après collecte
            Destroy(collision.gameObject);
        }
    }
}
