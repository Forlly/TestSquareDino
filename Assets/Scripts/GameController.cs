using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraMovement camera;
    [SerializeField] private Camera _camera;
    [SerializeField] public WeaponController weaponController;
    private bool gameStarting = false;
    private Vector3 endPoint = Vector3.zero;

    public static GameController Instans;

    private void Start()
    {
        Instans = this;
        camera.Active = true;
        _camera = camera.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!gameStarting)
                {
                    PlayerControls.Instans.MoveToNextWayPoint();
                    gameStarting = true;
                }
                else
                {
                    Vector3 positionTouch = Input.mousePosition;

                    Ray ray = _camera.ScreenPointToRay(positionTouch);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.collider.CompareTag("Enemy"))
                        {
                            weaponController.Fire(raycastHit.point,
                                () =>
                                {
                                    weaponController.MakeDamage(raycastHit.collider.GetComponent<EnemyMovement>());
                                });
                        }
                        else
                        {
                            weaponController.Fire(raycastHit.point);
                        }
                    }
                }
            }
        }
        else if (Application.isMobilePlatform )
        {
            if (Input.touchCount > 0 )
            {
                if (!gameStarting)
                {
                    PlayerControls.Instans.MoveToNextWayPoint();
                    gameStarting = true;
                }
                else
                {
                    Touch touch = Input.GetTouch(0);

                    Vector3 positionTouch = touch.position;

                    Ray ray = _camera.ScreenPointToRay(positionTouch);
                    if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    {
                        if (raycastHit.collider.CompareTag("Enemy"))
                        {
                            weaponController.Fire(raycastHit.point,
                                () =>
                                {
                                    weaponController.MakeDamage(raycastHit.collider.GetComponent<EnemyMovement>());
                                });
                        }
                        else
                        {
                            weaponController.Fire(raycastHit.point);
                        }
                    }
                }
                    
                
            }
        }
    }
    
}
