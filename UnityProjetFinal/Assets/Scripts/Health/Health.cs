using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger la sc�ne de Game Over

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Audio")]
    [SerializeField] private GameObject soundPlayerPrefab; // Prefab pour jouer les sons
    [SerializeField] private AudioClip damageSFX;          // Son pour les d�g�ts

    private void Awake()
    {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth > 0)
        {
            StartCoroutine(Invulnerability()); // Active les iFrames
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

            // Jouer le son de d�g�ts
            PlaySound(damageSFX);

            if (currentHealth == 0)
            {
                GameOver();
            }
        }
    }

    public void GainHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // V�rifie si l'objet en collision a le tag "Enemy" (ou un autre tag)
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

    // Permet d'avoir un temps d'invuln�rabilit� apr�s avoir pris un d�g�t
    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    private void PlaySound(AudioClip clip)
    {
        if (soundPlayerPrefab != null && clip != null)
        {
            // Instancie le prefab pour jouer le son
            GameObject soundPlayer = Instantiate(soundPlayerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("Le prefab Sound Player n'a pas de composant AudioSource !");
            }

            Destroy(soundPlayer, 2f); // D�truit le prefab apr�s 2 secondes
        }
        else
        {
            Debug.LogWarning("Prefab Sound Player ou AudioClip non assign� !");
        }
    }
}
