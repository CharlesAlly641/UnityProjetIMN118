using UnityEngine;

public class Lantern : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerControllerlvl1.instance.CollectLantern();
            Destroy(gameObject); // Supprime l'objet lanterne après l'avoir ramassé
        }
    }
}
