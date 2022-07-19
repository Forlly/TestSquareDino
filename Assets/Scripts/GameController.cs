using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraMovement camera;
    private bool gameStarting = false;

    private void Start()
    {
        camera.Active = true;
        
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButton(0) && !gameStarting)
            {
                Debug.Log("hi");
                Debug.Log(PlayerControls.Instans);
                PlayerControls.Instans.MoveToNextWayPoint(PlayerControls.Instans.transform.position);
                gameStarting = true;
            }
        }
        else if (Application.isMobilePlatform && !gameStarting)
        {
            if (Input.touchCount > 0)
            {
                PlayerControls.Instans.MoveToNextWayPoint(PlayerControls.Instans.transform.position);
                gameStarting = true;
            }
        }
    }
    
}
