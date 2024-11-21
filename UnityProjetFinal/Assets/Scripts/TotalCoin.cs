using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoin : MonoBehaviour
{
    // Compteur pour le nombre de pièces
    private int coinCount = 0;

    // Affichage du compteur dans la console pour débogage
    void Update()
    {
        Debug.Log("Coins collected: " + coinCount);
    }

    // Détection des objets avec le tag "coin"
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet a le tag "coin"
        if (other.CompareTag("coin"))
        {
            // Incrémente le compteur de pièces
            coinCount++;

            // Détruire l'objet "coin" après avoir été collecté
            Destroy(other.gameObject);
        }
    }

    // Fonction pour récupérer le nombre de pièces collectées
    public int GetCoinCount()
    {
        return coinCount;
    }
}
