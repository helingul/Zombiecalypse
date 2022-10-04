using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{

    private Rigidbody2D myBody;
    public float speed;
    private Vector2 moveVelocity;

    public GameObject bullet;
    public weapon currentWeapon;
    private float nextTimeOfFire = 0;

    public Joystick moveJoystick;
    public Joystick shootJoystick;
    [HideInInspector]
    public bool canShoot;

    void Movement()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       if(moveJoystick.inputDir != Vector3.zero)
        {
            moveInput = moveJoystick.inputDir;
        }
        moveVelocity = moveInput.normalized * speed;
        
        myBody.MovePosition(myBody.position + moveVelocity * Time.fixedDeltaTime);

    }

    void Rotation()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
        if(shootJoystick.inputDir != Vector3.zero)
        {
            angle = Mathf.Atan2(shootJoystick.inputDir.y, shootJoystick.inputDir.x) * Mathf.Rad2Deg + 90;
        }
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

    }

    void Update()
    {
        
        //shooting
        if (Input.GetMouseButton(0) && canShoot)
        {
            if(Time.time >= nextTimeOfFire)
            {
                currentWeapon.Shoot();
                nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
            }
           // Instantiate(bullet, transform.position, Quaternion.identity);
        }
        Rotation();

        // ground bounds
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,
            -46f, 10), Mathf.Clamp(transform.position.y,
            -25f, 8f));


    }
    // Start is called before the first frame update
    void Awake()
    {
        canShoot = false;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }
}
