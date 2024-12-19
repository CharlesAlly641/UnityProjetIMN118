using UnityEngine;
using TMPro;

public class StoreButtonHandler : MonoBehaviour
{
    public GameObject storeMessagePanel; // Panneau du message
    public TextMeshProUGUI storeMessageText; // Texte du message

    public void OpenStore()
    {
        if (storeMessagePanel == null || storeMessageText == null)
        {
            Debug.LogWarning("StoreMessagePanel ou StoreMessageText n'est pas assigné !");
            return;
        }

        // Affiche le message "à venir"
        storeMessagePanel.SetActive(true);
        storeMessageText.text = "Le magasin est à venir bientôt.";
        Debug.Log("Magasin non disponible pour le moment.");
    }
}
