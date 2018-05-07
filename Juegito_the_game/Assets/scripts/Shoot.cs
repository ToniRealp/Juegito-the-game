using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject ultiPrefab;
    public Transform SpawnPoint;
    public Vector2 DirectionJoyL = Vector2.zero;
    public float cadency;
    public float bulletForce;
    public float lateralReduction;
    public float maxCharge;
    public float shotCharge = 0;
    public float ltDown = 0;
    public float ultChargeTime;
    public int ultCharge = 0;
    public string player;
    public bool venom = false;

    private float timer = 0;

    private void Start()
    {
        SpawnPoint = transform.GetChild(0).GetChild(0).GetChild(0).transform;
        ultChargeTime = 1.5f;
    }

    void Update(){
        
        //with these two lines the code sets DirectionJoyL to the vector that comes up from the Left joystik of the Xbox One controller
        DirectionJoyL.x = GetComponent<InputManger>().leftJoystickX;
        DirectionJoyL.y = GetComponent<InputManger>().leftJoystickY;
        DirectionJoyL.Normalize();

        if (GetComponent<InputManger>().rt != 0){

            if (shotCharge < maxCharge)
                shotCharge += Time.deltaTime;

        }

        if (timer > cadency && GetComponent<InputManger>().rt == 0 && shotCharge != 0){

            if (DirectionJoyL == new Vector2(0, 0))
                DirectionJoyL = new Vector2(GameObject.Find(player).GetComponent<Movement>().side, 0); // multiplicate that for 1 or -1 depending on were are you facing

            SpawnBullet();

            venom = false;

            timer = 0;

            // add force to the oposite direction where you are shoting to create this "jetpack" effect.
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * -DirectionJoyL.y * bulletForce * shotCharge * 2);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * -DirectionJoyL.x * (bulletForce * shotCharge) / lateralReduction);
            shotCharge = 0;

        }

        if (GetComponent<InputManger>().lt > 0.8 && ultCharge == 100)
        {
            if (ltDown < ultChargeTime)
                ltDown += Time.deltaTime;
        }

        if (GetComponent<InputManger>().lt == 0){

            if (ultCharge == 100 && ltDown > ultChargeTime) {

                if (DirectionJoyL == new Vector2(0, 0))
                    DirectionJoyL = new Vector2(GameObject.Find(player).GetComponent<Movement>().side, 0);

                SpawnUlt();
                ultCharge = 0;
                ltDown = 0;
            }
            else
                ltDown = 0;

        }

        timer += Time.deltaTime;

        if (ultCharge > 100)
            ultCharge = 100;

    }

    //this function spawns bullets and destroys them after 3 seconds
    void SpawnBullet(){

        float angle = gameObject.GetComponentInChildren<WeaponDirection>().direction;

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, SpawnPoint.position , Quaternion.Euler(0,0,angle) );
        Destroy(bullet, 3);//Cambiar on collision con los bordes del mapa

    }

    void SpawnUlt(){

        GameObject ulti = (GameObject)Instantiate(ultiPrefab, GetComponent<Rigidbody2D>().transform.position, transform.rotation);

    }

} 
