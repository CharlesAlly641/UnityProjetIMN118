using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger la sc�ne de Game Over

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
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

}
