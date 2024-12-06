using UnityEngine;

public class BlockedPathway : MonoBehaviour
{
    private GameObject mustObject;
    private BoxCollider2D boxCollider;

    public AudioClip unlockSFX; // Son de d�verrouillage
    private AudioSource audioSource;

    void Start()
    {
        // Trouver l'objet avec le tag "MustObject"
        mustObject = GameObject.FindWithTag("MustObject");

        // R�cup�rer le BoxCollider2D attach� � cet objet
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider == null)
        {
            Debug.LogError("Aucun BoxCollider2D trouv� sur l'objet bloquant !");
        }

        if (mustObject == null)
        {
            Debug.LogError("Objet avec le tag 'MustObject' introuvable !");
        }

        // D�sactiver le trigger tant que "MustObject" existe
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }

        // Ajouter ou r�cup�rer un composant AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.playOnAwake = false;        // Ne pas jouer automatiquement

    }

    void Update()
    {
        // Activer le trigger si "MustObject" est d�truit
        if (mustObject == null && boxCollider != null)
        {
            boxCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // D�truire l'objet bloquant si le joueur entre en contact
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Le joueur a d�bloqu� le chemin !");

            // Jouer le son de d�verrouillage
            if (unlockSFX != null)
            {
                audioSource.PlayOneShot(unlockSFX);
            }

            // D�truire l'objet bloquant apr�s la dur�e du son 
            Destroy(gameObject, unlockSFX != null ? unlockSFX.length : 0f);
        }
    }
}
