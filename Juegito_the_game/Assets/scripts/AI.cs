using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    public InputManger input;
    public Vector3 pos;
    public Vector3 vel;
    public bool imSafe;
    public bool onPlat;
    public bool charging;
    public LayerMask lm;
    public bool close = false;
    public bool chargingUlt = false;
    private int side;
    private float objCharge;
    public float movX = 1;
    public float movY = 0;
    private float delay = 0.5f;
    public float shotDdelay = 0.5f;
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

        bool clear = clearShot();

        avoidFalling();

        input.XboxLbNd = false;
        input.lb = false;
        input.lbUp = true;

        seek();
        charge();
        usePickUp();


        input.leftJoystickX = movX;
        input.leftJoystickY = movY;
    }

    #region behaviours

    void usePickUp()
    {
        input.y = false;
        if (GetComponent<EffectsManager>().next != EffectsManager.Effect.None)
            input.y = true;
    }
        
    void charge() {
        input.lt = 0;
        if (close && GetComponent<Shoot>().ultCharge == 100 && !chargingUlt) {
            chargingUlt = true;     
        }

        if (chargingUlt){
            if (GetComponent<Shoot>().ltDown <= GetComponent<Shoot>().ultChargeTime)
                input.lt = 1;
            else{
                aim();
                input.lt = 0;
                chargingUlt = false;
            }

        }

        if(shotDdelay >= 0.5f) { 
            if(!charging) {
                objCharge = Random.Range(0.8f, 1);
                charging = true;
            }
            if(charging && GetComponent<Shoot>().shotCharge < objCharge){
                input.rt = 1;
            }
            else if(charging && GetComponent<Shoot>().shotCharge >= objCharge){ // try to fix crazy bullets here
                aim();
                side = (targget.GetComponent<Transform>().position.x < pos.x) ? -1 : 1;
                input.rt = 0;
                charging = false;
                shotDdelay = 0;
            }
        }
        else {
            shotDdelay += Time.deltaTime;
        }

    }

    void aim()
    {
        Vector2 aim = new Vector2(targget.GetComponent<Transform>().position.x - pos.x, targget.GetComponent<Transform>().position.y - pos.y);
        aim.Normalize();
        movX = aim.x;
        movY = aim.y;
}

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

        if (pos.y >= targY - 3 && pos.y <= targY + 8 && onPlat && pos.x < targgX + 10 && pos.x > targgX - 10)
        {
            close = true;
            //press lb and shoot
            input.XboxLbNd = true;
            input.lb = true;
            input.lbUp = false;
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
        Debug.Log(gameObject.name + ": " + _targget);
        return _targget;
    }
#endregion

    #region checks
    bool clearShot()
    {
        Vector2 aim = new Vector2(targget.GetComponent<Transform>().position.x - pos.x, targget.GetComponent<Transform>().position.y - pos.y);
        aim.Normalize();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, aim, 20, ~lm);
        Debug.DrawRay(transform.position, aim * 20f, Color.cyan);
        return hit;
    }

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

