using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector2 respawnPosition;

    public AudioClip respawnSFX; // Son jou� lors du respawn
    private AudioSource audioSource; // Composant AudioSource pour jouer le son

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

        // Ajouter ou r�cup�rer un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false; // Ne pas jouer de son automatiquement
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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

        // Jouer le son de respawn
        if (respawnSFX != null)
        {
            audioSource.PlayOneShot(respawnSFX);
        }
    }
}

