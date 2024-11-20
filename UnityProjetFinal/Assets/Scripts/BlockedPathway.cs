using UnityEngine;

public class BlockedPathway : MonoBehaviour
{
    private GameObject mustObject;
    private BoxCollider2D boxCollider;

    void Start()
    {
        // Trouver l'objet avec le tag "MustObject"
        mustObject = GameObject.FindWithTag("MustObject");

        // Récupérer le BoxCollider2D attaché à cet objet
        boxCollider = GetComponent<BoxCollider2D>();

        if (boxCollider == null)
        {
            Debug.LogError("Aucun BoxCollider2D trouvé sur l'objet bloquant !");
        }

        if (mustObject == null)
        {
            Debug.LogError("Objet avec le tag 'MustObject' introuvable !");
        }

        // Désactiver le trigger tant que "MustObject" existe
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false;
        }
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
            Debug.Log("Le joueur a débloqué le chemin !");
            Destroy(gameObject);
        }
    }
}
