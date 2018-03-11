using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Parry : MonoBehaviour {

    public GameObject bulletPrefab;
    public string playerNumber;
    public string player;
    public Vector2 vec2;

    void SpawnBullet()
    {

        GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position + new Vector3(0.4f * GameObject.Find(player).GetComponent<Movement>().side, 0, 0), transform.rotation);
        Destroy(bullet, 3);//Cambiar on collision con los bordes del mapa

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown(playerNumber + "XboxX"))
        {
            if (other.tag == "Bullet")
            {
                Destroy(other);
                SpawnBullet();
            }
        }

    }

}
