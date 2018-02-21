using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject ultiPrefab;
    public float cadency;
    public float bulletForce;
    public int movementSpeed;
    public float lateralReduction;
    public float jump;
    public Vector2 DirectionJoyL = Vector2.zero;
    public float maxCharge;
    public float shotCharge = 0;
    public int ultCharge = 0;
    private float timer = 0;
    private bool joyStick;



    void Start()
    {

    }

    void Update()
    {
        //with this two lines the code sets DirectionJoyL to the vector that comes up from the Left joystik of the Xbox One controller
        DirectionJoyL.x = Input.GetAxis("LeftJoyX");
        DirectionJoyL.y = Input.GetAxis("LeftJoyY");
        DirectionJoyL.Normalize();

        if (Input.GetAxis("RT") != 0)
        {
            if (shotCharge < maxCharge)
                shotCharge += Time.deltaTime;
        }

        if (timer > cadency && Input.GetAxis("RT") == 0 && shotCharge != 0)
        {
            if (DirectionJoyL == new Vector2(0, 0))
                DirectionJoyL = new Vector2(1*GameObject.Find("ThePlayer").GetComponent<Movement>().side, 0); // multiplicat that for 1 or -1 depending on were are you facing!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            SpawnBullet();
            timer = 0;

            // add force to the oposite direction where you are shoting to create this "jetpack" effect.
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -DirectionJoyL.y * bulletForce * shotCharge * 2);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * -DirectionJoyL.x * (bulletForce * shotCharge) / lateralReduction);

            shotCharge = 0;
        }

        if (Input.GetAxis("LT") != 0 && ultCharge == 100)
        {
            if (DirectionJoyL == new Vector2(0, 0))
                DirectionJoyL = new Vector2(1, 0);

            SpawnUlt();
            ultCharge = 0;
        }

        timer += Time.deltaTime;
        if (ultCharge > 100)
            ultCharge = 100;
    }

    //this function spawns bullets and destroys them after 3 seconds
    void SpawnBullet()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(10.7f, 0.5f, 0), transform.rotation);
        Destroy(bullet, 3);//Cambiar on collision con los bordes del mapa

    }

    void SpawnUlt()
    {
        GameObject ulti = (GameObject)Instantiate(ultiPrefab, GetComponent<Rigidbody2D>().transform.position, transform.rotation);
    }


} 
