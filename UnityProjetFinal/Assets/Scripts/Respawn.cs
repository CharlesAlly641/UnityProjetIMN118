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
            Debug.LogError("Aucun objet avec le tag 'debut' trouvé dans la scène.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet avec lequel il y a collision a le tag "Ennemis"
        if (collision.gameObject.CompareTag("Ennemis"))
        {
            RespawnAtRespawnPosition();
        }
    }

    void RespawnAtRespawnPosition()
    {
        // Replace le personnage à la position de respawn
        transform.position = respawnPosition;

        // Réinitialise la vitesse du Rigidbody pour éviter tout mouvement résiduel
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}

