using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public AudioClip pickupSFX; // Son sp�cifique pour cet objet
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

            // D�truire l'objet ramass�
            Destroy(gameObject);
        }
    }

    private void PlaySound()
    {
        if (soundPlayerPrefab != null)
        {
            // Cr�er un objet pour jouer le son
            GameObject soundPlayer = Instantiate(soundPlayerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = soundPlayer.GetComponent<AudioSource>();

            if (audioSource != null)
            {
                audioSource.clip = pickupSFX;
                audioSource.Play();

                // D�truire le GameObject apr�s la fin du son
                Destroy(soundPlayer, pickupSFX.length);
            }
        }
        else
        {
            Debug.LogWarning("Aucun prefab pour le son n'a �t� assign� !");
        }
    }
}
