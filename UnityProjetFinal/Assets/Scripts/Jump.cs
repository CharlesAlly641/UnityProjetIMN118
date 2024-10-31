using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;   // Force du saut
    private bool isGrounded = true;       // Vérifie si le joueur est au sol
    private Rigidbody2D rb;
    private Animator anim;
    private bool chute = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalSpeed = rb.velocity.y;
        // Détecter l'appui sur la touche de saut (espace)
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }
        if(verticalSpeed > 0.01f)
            chute = false;
        else if (verticalSpeed < -0.01f)
            chute = true;

        anim.SetBool("sol", isGrounded);
        anim.SetBool("fall", chute);
    }

    void Jump()
    {
        // Appliquer la force vers le haut pour le saut
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("saut");
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

