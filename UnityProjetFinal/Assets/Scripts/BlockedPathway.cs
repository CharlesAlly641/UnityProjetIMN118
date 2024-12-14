using UnityEngine;

public class BlockedPathway : MonoBehaviour
{
    private GameObject mustObject;
    private BoxCollider2D boxCollider;

    public AudioClip unlockSFX; // Son de déverrouillage
    private AudioSource audioSource;

    void Start()
    {
        // Trouver l'objet avec le tag "MustObject"
        mustObject = GameObject.FindWithTag("MustObject");

        boxCollider = GetComponent<BoxCollider2D>();

        // Désactiver le trigger tant que "MustObject" existe
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }

        // Ajouter ou récupérer un composant AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;        // Ne pas jouer automatiquement

    }

    void Update()
    {
        // Activer le trigger si "MustObject" est détruit
        if (mustObject == null && boxCollider != null)
        {
            boxCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Détruire l'objet bloquant si le joueur entre en contact
        if (collision.CompareTag("Player"))
        {
         

            // Jouer le son de déverrouillage
            if (unlockSFX != null)
            {
                audioSource.PlayOneShot(unlockSFX);
            }

            // Détruire l'objet bloquant après la durée du son 
            Destroy(gameObject, unlockSFX != null ? unlockSFX.length : 0f);
        }
    }
}
