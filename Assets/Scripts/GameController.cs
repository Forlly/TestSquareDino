using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CameraMovement camera;
    public WayPoit[] WayPoits;
    [SerializeField] private Camera _camera;
    
    [SerializeField] private Animator textAnimator;
    [SerializeField] private GameObject textStartGame;
    
    public WeaponController weaponController;
    public bool gameStarting = false;

    public static GameController Instans;

    private void Awake()
    {
        Instans = this;
        camera.Active = true;
        textAnimator.CrossFade("StartGame", 0f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!gameStarting)
            {
                PlayerControls.Instans.MoveToNextWayPoint();
                gameStarting = true;
                textStartGame.SetActive(false);
                return;
            }

            if (!weaponController.weapon.readyToShot)
                return;
            

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
                            () => { weaponController.MakeDamage(raycastHit.collider.GetComponent<EnemyControls>()); });
                    }

                }
                else if (raycastHit.collider.CompareTag("Environment"))
                {
                    weaponController.Fire(raycastHit.point,
                        () =>
                        {
                            Rigidbody rb = raycastHit.collider.gameObject.GetComponent<Rigidbody>();
                            rb.AddForce(1, 1, 200);
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
