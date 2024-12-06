using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public AudioClip pickupSFX; // Son spécifique pour cet objet
    public GameObject soundPlayerPrefab; // Prefab pour jouer le son

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Jouer le son avec un objet temporaire
            if (pickupSFX != null)
            {
                PlaySound();
            }

            // Détruire l'objet ramassé
            Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        if (soundPlayerPrefab != null)
        {
            // Créer un objet pour jouer le son
            GameObject soundPlayer = Instantiate(soundPlayerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.clip = pickupSFX;
                audioSource.Play();

                // Détruire le GameObject après la fin du son
                Destroy(soundPlayer, pickupSFX.length);
            }
        }
        else
        {
            Debug.LogWarning("Aucun prefab pour le son n'a été assigné !");
        }
    }
}
