using UnityEngine;
using Cinemachine;

public class SetCameraStartPosition : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        // D�finit la position initiale de la cam�ra � (0, 0, -10)
        virtualCamera.transform.position = new Vector3(-17, -1, 0);
    }
}

