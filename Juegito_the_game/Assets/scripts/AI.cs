using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public InputManger input;
    public Vector3 pos;
    public Vector3 vel;
    public bool imSafe;
    public bool onPlat;
    public LayerMask lm;
    private int side;
    public int movX = 1;
    private float delay = 0.5f;
    GameObject[] players;
    GameObject targget;

    void Start () {
        pos = GetComponent<Transform>().position;
        vel = GetComponent<Rigidbody2D>().velocity;
        input = GetComponent<InputManger>();

    }

    void Update()
    {
        pos = GetComponent<Transform>().position;
        vel = GetComponent<Rigidbody2D>().velocity;
        side = GetComponent<Movement>().side;
        players = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovement>().players;
        
        imSafe = goingToFall();
        onPlat = OnPlatform();
        targget = findClosest();

        avoidFalling();
        seek();
        
 

        input.leftJoystickX = movX;
    }

    #region behaviours
    void avoidFalling()
    {
        if (imSafe)
        {
            movX *= 1;
        }
        else
        {
            if (ableToJump())
                jump();
            else
                movX *= -1;
        }
    }

    void seek(){
        float targgX = targget.GetComponent<Transform>().position.x;
        float targY = targget.GetComponent<Transform>().position.y;

        if (pos.y >= targY - 2 && onPlat && pos.x < targgX + 10 && pos.x > targgX - 10)
        {
            movX = 0;
        }

        else {
            if (movX == 0)
            {
                movX = side;
            }

            if (pos.x > targgX + 5 || pos.x < targgX - 5)
            {
                if (targgX < pos.x)
                    movX = -1;
                else
                    movX = 1;
            }

            if (pos.y < targY && platformOnTop())
            {
                jump();
            }
        }
    }

    void jump()
    {
        if (delay >= 0.2f && GetComponent<Movement>().onFloor)
        {
            delay = 0;
            input.a = true;
        }
        delay += Time.deltaTime;
    }

    GameObject findClosest()
    {
        GameObject _targget = players[0];
        float minDist = 10000000;

        for (int i = 0; i < players.Length; i++)
        {
            if (Vector3.Distance(pos, players[i].GetComponent<Transform>().position) < minDist)
            {
                if (players[i] != this.gameObject)
                {
                    _targget = players[i];
                    minDist = Vector3.Distance(pos, _targget.GetComponent<Transform>().position);
                }
            }
        }
        return _targget;
    }
#endregion

    #region checks
    bool ableToJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(side, 0, 0)*4, Vector2.down, 20, ~lm);
        Debug.DrawRay(transform.position + new Vector3(side, 0, 0), Vector2.down * 20f, Color.red);
        return hit;
    }
    bool goingToFall() {

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(side, 0, 0), Vector2.down, 20, ~lm);
        Debug.DrawRay(transform.position + new Vector3(side, 0, 0), Vector2.down * 20f, Color.red);
        return hit;
    }
    bool OnPlatform()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, ~lm);
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.red);
        return hit;
    }

    bool platformOnTop() {

        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(side, 0, 0)*4, Vector2.up, 2.5f, ~lm);
        Debug.DrawRay(transform.position + new Vector3(side, 0, 0) * 4, Vector2.up * 2.5f, Color.yellow);
        return hit;

    }
    #endregion
}

