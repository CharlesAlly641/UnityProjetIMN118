using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishElevatorPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Vérifiez si le joueur a ramassé la clé
            if (PlayerController.instance.HasKey)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                Debug.Log("Vous avez besoin de la clé pour continuer !");
            }
        }
    }
}
