using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int totalCoinsCollected = 0; // Compteur de pi�ces collect�es

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // V�rifie si l'objet en collision a le tag "coin"
        if (collision.CompareTag("coin"))
        {
            totalCoinsCollected++; // Incr�mente le compteur
            Debug.Log("Total coins collected: " + totalCoinsCollected);

            // Optionnel : D�truire l'objet "coin" apr�s collecte
            Destroy(collision.gameObject);
        }
    }
}
