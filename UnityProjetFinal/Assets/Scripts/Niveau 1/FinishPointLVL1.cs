using UnityEngine;

public class FinishPointlvl1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // V�rifiez si le joueur a ramass� la lanterne
            if (PlayerControllerlvl1.instance.HasLantern)
            {
                SceneController1.instance.NextLevel();
            }
            else
            {
                Debug.Log("Vous devez ramasser la lanterne avant de continuer !");
            }
        }
    }
}
