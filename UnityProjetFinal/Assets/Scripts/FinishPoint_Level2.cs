using UnityEngine;

public class FinishPoint_Level2 : MonoBehaviour
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
