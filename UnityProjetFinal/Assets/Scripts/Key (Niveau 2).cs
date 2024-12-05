using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController.instance.CollectKey();
            Destroy(gameObject); // Supprime l'objet cl� apr�s l'avoir ramass�
        }
    }
}