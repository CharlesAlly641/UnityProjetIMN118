using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector2 respawnPosition;

    void Start()
    {
        // Trouve l'objet avec le tag "debut" et utilise sa position comme position de respawn
        GameObject debutObject = GameObject.FindWithTag("debut");
        if (debutObject != null)
        {
            respawnPosition = debutObject.transform.position;
        }
        else
        {
            Debug.LogError("Aucun objet avec le tag 'debut' trouv� dans la sc�ne.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifie si l'objet avec lequel il y a collision a le tag "Ennemis"
        if (collision.gameObject.CompareTag("Ennemis"))
        {
            RespawnAtRespawnPosition();
        }
    }

    void RespawnAtRespawnPosition()
    {
        // Replace le personnage � la position de respawn
        transform.position = respawnPosition;

        // R�initialise la vitesse du Rigidbody pour �viter tout mouvement r�siduel
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

