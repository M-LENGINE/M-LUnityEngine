using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyOverworldIA : MonoBehaviour
{
    public SpriteAnim AnimMotor;
    public float xx, yy;
    public int dirbef;
    public bool Noticed;
    public int state; // 0 : Moving, 1 : Noticed
    public Transform Mario;
    public float noticedist;
    public float stopnoticedist;
    public Rigidbody RB;
    public float jmpforce;
    public float MovSPD;
    public int movstate; // 0 Idle, 1 Walking, 2 Noticed Running
    public float dirdist;
    void Start() {
        dirbef = 1;
    }
    void Update()
    {
        this.transform.Translate(-xx * MovSPD, 0f, -yy * MovSPD);
        StateUpdate();
        DirUpdate();
        StateUpdate2();
        if (Vector3.Distance(this.transform.position, Mario.position) < noticedist && !Noticed) {
            Noticed = true;
            movstate = 3;
            state = 3;
            AnimMotor.animid = 24;
            RB.AddForce(this.transform.up * jmpforce);
            Invoke("Notice", 1f);
        }
        if (Vector3.Distance(this.transform.position, Mario.position) > stopnoticedist && Noticed)
        {
            Noticed = false;
            movstate = 0;
            state = 0;
        }

    }
    void StateUpdate2() {
        if (state == 0)
        {
            //Searching
            if (xx == 0 && yy == 0)
            {
                movstate = 0;
            }
            else {
                movstate = 1;
            }
        }
        else if (state == 1)
        {
            // Running For Mario
            movstate = 2;
            if (Mario.position.x < this.transform.position.x && Mario.position.z > this.transform.position.z - dirdist && Mario.position.z < this.transform.position.z + dirdist)
            {
                // Vertical >
                xx = 0;
                yy = 1;
            }
            if (Mario.position.z > this.transform.position.z + dirdist && Mario.position.x < this.transform.position.x - dirdist) {
                // Horizontal >,  Vertical >
                xx = 1;
                yy = 1;
            }
            if (Mario.position.z > this.transform.position.z && Mario.position.x > this.transform.position.x - dirdist && Mario.position.x < this.transform.position.x + dirdist)
            {
                // Horizontal >
                xx = 1;
                yy = 0;
            }
            if (Mario.position.z > this.transform.position.z + dirdist && Mario.position.x > this.transform.position.x + dirdist)
            {
                // Horizontal >,  Vertical <
                xx = 1;
                yy = -1;
            }
            if (Mario.position.x > this.transform.position.x && Mario.position.z > this.transform.position.z - dirdist && Mario.position.z < this.transform.position.z + dirdist)
            {
                // Vertical <
                yy = -1;
                xx = 0;
            }
            if (Mario.position.x > this.transform.position.x + dirdist && Mario.position.z < this.transform.position.z - dirdist)
            {
                // Vertical <, Horizontal <
                yy = -1;
                xx = -1;
            }
            if (Mario.position.z < this.transform.position.z && Mario.position.x > this.transform.position.x - dirdist && Mario.position.x < this.transform.position.x + dirdist)
            {
                // Horizontal <
                xx = -1;
                yy = 0;
            }
            if (Mario.position.x < this.transform.position.x - dirdist && Mario.position.z < this.transform.position.z - dirdist)
            {
                // Vertical >, Horizontal <
                yy = 1;
                xx = -1;
            }
        }
    }
    void StateUpdate() {
        if (movstate == 0)
        {
            AnimMotor.animid = dirbef - 1;
        }
        else if (movstate == 1)
        {
            AnimMotor.animid = dirbef + 7;
        }
        else if (movstate == 2) { AnimMotor.animid = dirbef + 15; } else { 
        }
    }
    void Notice() {
        state = 1;
       


    }
    void DirUpdate() {
        if (xx == 0 && yy > 0)
        {
            dirbef = 1;
        }
        if (xx > 0 && yy > 0)
        {
            dirbef = 2;
        }
        if (xx > 0 && yy == 0)
        {
            dirbef = 3;
        }
        if (xx > 0 && yy < 0)
        {
            dirbef = 4;
        }
        if (xx == 0 && yy < 0)
        {
            dirbef = 5;
        }
        if (xx < 0 && yy < 0)
        {
            dirbef = 6;
        }
        if (xx < 0 && yy == 0)
        {
            dirbef = 7;
        }
        if (xx < 0 && yy > 0)
        {
            dirbef = 8;
        }
    }
}
