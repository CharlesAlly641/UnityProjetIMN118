using UnityEngine;

public class BlockedPathway : MonoBehaviour
{
    private GameObject mustObject;
    private BoxCollider2D boxCollider;

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
            Destroy(gameObject);
        }
    }
}
