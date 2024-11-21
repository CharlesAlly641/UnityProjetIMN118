using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalCoin : MonoBehaviour
{
    // Compteur pour le nombre de pi�ces
    private int coinCount = 0;

    // Affichage du compteur dans la console pour d�bogage
    void Update()
    {
        Debug.Log("Coins collected: " + coinCount);
    }

    // D�tection des objets avec le tag "coin"
    void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si l'objet a le tag "coin"
        if (other.CompareTag("coin"))
        {
            // Incr�mente le compteur de pi�ces
            coinCount++;

            // D�truire l'objet "coin" apr�s avoir �t� collect�
            Destroy(other.gameObject);
        }
    }

    // Fonction pour r�cup�rer le nombre de pi�ces collect�es
    public int GetCoinCount()
    {
        return coinCount;
    }
}
