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
            buttonText.text = "Magasin (À venir bientôt)"; // Modifier le texte pour indiquer que c'est à venir
        }
    }

    // Fonction appelée lorsque le bouton Magasin est cliqué
    public void OpenStore()
    {
        // Si le magasin est pas encore disponible
        Debug.Log("Magasin non disponible pour le moment.");
        // Affiche un message ou une interface indiquant que le magasin est à venir

       
        UnityEditor.EditorUtility.DisplayDialog("Magasin", "Le magasin est à venir bientôt.", "OK");
    }
}
