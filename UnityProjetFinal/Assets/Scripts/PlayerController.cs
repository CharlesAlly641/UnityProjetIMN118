using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public bool HasKey { get; private set; } = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectKey()
    {
        HasKey = true;
        Debug.Log("Clé ramassée !");
    }
}
