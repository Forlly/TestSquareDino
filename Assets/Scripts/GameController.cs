using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraMovement camera;
    public WayPoit[] WayPoits;
    [SerializeField] private Camera _camera;
    [SerializeField] public WeaponController weaponController;
    private bool gameStarting = false;

    public static GameController Instans;

    private void Awake()
    {
        Instans = this;
        camera.Active = true;
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
                            if (raycastHit.collider.name == "Head")
                            {
                                weaponController.Fire(raycastHit.point,
                                    () =>
                                    {
                                        weaponController.HeadShot(raycastHit.collider
                                            .GetComponentInParent<EnemyControls>());
                                    });
                            }
                            else
                            {
                                weaponController.Fire(raycastHit.point,
                                    () =>
                                    {
                                        weaponController.MakeDamage(raycastHit.collider.GetComponent<EnemyControls>());
                                    });
                            }
                            
                        }
                        else if (raycastHit.collider.CompareTag("Environment"))
                        {
                            weaponController.Fire(raycastHit.point,
                                () =>
                                {
                                    Rigidbody rb = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                                    rb.AddForce(1,1,200);
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
                            if (raycastHit.collider.name == "Head")
                            {
                                weaponController.Fire(raycastHit.point,
                                    () =>
                                    {
                                        weaponController.HeadShot(raycastHit.collider
                                            .GetComponentInParent<EnemyControls>());
                                    });
                            }
                            else
                            {
                                weaponController.Fire(raycastHit.point,
                                    () =>
                                    {
                                        weaponController.MakeDamage(raycastHit.collider.GetComponent<EnemyControls>());
                                    });
                            }
                        }
                        else if (raycastHit.collider.CompareTag("Environment"))
                        {
                            weaponController.Fire(raycastHit.point,
                                () =>
                                {
                                    Rigidbody rb = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                                    rb.AddForce(1,1,200);
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
