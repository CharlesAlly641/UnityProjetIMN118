using UnityEngine;
using Cinemachine;

public class SetCameraStartPosition : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        // Définit la position initiale de la caméra à (0, 0, -10)
        virtualCamera.transform.position = new Vector3(-17, -1, 0);
    }
}

