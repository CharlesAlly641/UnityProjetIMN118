using UnityEngine;
using UnityEngine.UI; // Pour Text

public class StoreButtonHandler : MonoBehaviour
{
    private Text buttonText;

    void Start()
    {
        buttonText = GetComponentInChildren<Text>(); // Rechercher le texte du bouton
        if (buttonText != null)
        {
            buttonText.text = "Magasin (� venir bient�t)"; // Modifier le texte pour indiquer que c'est � venir
        }
    }

    // Fonction appel�e lorsque le bouton Magasin est cliqu�
    public void OpenStore()
    {
        // Si le magasin est pas encore disponible
        Debug.Log("Magasin non disponible pour le moment.");
        // Affiche un message ou une interface indiquant que le magasin est � venir

       
        UnityEditor.EditorUtility.DisplayDialog("Magasin", "Le magasin est � venir bient�t.", "OK");
    }
}
