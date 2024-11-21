using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public Vector3 RotationPerSecond;

    // Paramètres pour le mouvement flottant
    public float floatHeight = 0.5f; // Hauteur de déplacement
    public float floatSpeed = 2f; // Vitesse de fluctuation

    private Vector3 initialPosition;

    // Rotation cumulative
    void Start()
    {
        // Enregistrer la position initiale pour le mouvement flottant
        initialPosition = transform.position;
    }

    void Update()
    {
        // Rotation
        transform.Rotate(RotationPerSecond * Time.deltaTime, Space.Self);

        // Mouvement flottant (haut et bas)
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

    // Inverse la valeur de RotationPerSecond
    public void Reverse()
    {
        RotationPerSecond = -RotationPerSecond;
    }
}
