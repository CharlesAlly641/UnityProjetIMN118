using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;   // Force du saut
    private bool isGrounded = true;       // Vérifie si le joueur est au sol
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Détecter l'appui sur la touche de saut (espace)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Appliquer la force vers le haut pour le saut
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false;  // Le joueur n'est plus au sol
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Détecte si le joueur touche le sol
        if (collision.contacts.Length > 0 && collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

