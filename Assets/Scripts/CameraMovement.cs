using Cinemachine;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private Transform playerTransform;

    private bool active;
    public bool Active
    {
        set
        {
            active = value;
            FollowPlayer();

        }
        get => active;
    }

    private bool FollowPlayer()
    {
        cinemachineVirtualCamera.Follow = playerTransform;

        return playerTransform != null;
    }
}
