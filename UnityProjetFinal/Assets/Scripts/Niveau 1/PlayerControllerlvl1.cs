using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerlvl1 : MonoBehaviour
{
    public static PlayerControllerlvl1 instance;

    public bool HasLantern { get; private set; } = false;

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

    public void CollectLantern()
    {
        HasLantern = true;
        Debug.Log("Lanterne ramassée !");
    }
}
