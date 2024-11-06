using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger la scène de Game Over

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


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifiez que l'objet en collision a le tag "Enemy" (ou un autre tag)
        if (collision.gameObject.CompareTag("Ennemis"))
        {
            TakeDamage(1); // Par exemple, le joueur perd 1 point de vie
        }
    }

    private void GameOver()
    {
        // Désactive le personnage
        gameObject.SetActive(false);
        // Charge la scène de Game Over
        SceneManager.LoadScene("GameOverScene"); // Assurez-vous que vous avez une scène nommée "GameOverScene"
    }

}
