using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishElevatorPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // V�rifiez si le joueur a ramass� la cl�
            if (PlayerController.instance.HasKey)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                Debug.Log("Vous avez besoin de la cl� pour continuer !");
            }
        }
    }
}
