using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger la sc�ne de Game Over

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header ("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (currentHealth > 0){
            StartCoroutine(Invulnerability());
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth == 0)
        {
            GameOver();
        }
    }

    public void GainHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifiez que l'objet en collision a le tag "Enemy" (ou un autre tag)
        if (collision.gameObject.CompareTag("Ennemis"))
        {
            TakeDamage(1); // Par exemple, le joueur perd 1 point de vie
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            GainHealth(1); // Le joueur gagne 1 point de vie
            Destroy(collision.gameObject); // Supprime l'objet de la sc�ne
        }
    }

    private void GameOver()
    {
        // D�sactive le personnage
        gameObject.SetActive(false);
        // Charge la sc�ne de Game Over
        SceneManager.LoadScene("GameOverScene"); // Assurez-vous que vous avez une sc�ne nomm�e "GameOverScene"
    }

    //Permet d'avoir un temps d'invuln�rabilit� apr�s avoir pris un d�gat
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
        }
        Physics2D.IgnoreLayerCollision(7,8,false);
    }

}
