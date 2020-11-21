using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMov : MonoBehaviour
{
    public SpriteAnim AnimMotor;
    public float MovSPD,xx,yy,jmpdist,forcejmp;
    public bool jumping,walking,idle,floor;
    public Rigidbody rigid;
    public ShadowScr shdow;
    private RaycastHit hit;
    public float dist;
    public bool saltar;
    public int dirbef;
    public bool moving;
    public InventorySystem iv;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        DirUpd();
         AnimMotor.updateanim();
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) 
        {
          xx = 0;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) 
        {
          yy = 0;
        }
        MovAnimMotor();
        if (floor & !jumping)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Invoke("S",0.1f);
                
                shdow.Anim();
                AnimMotor.updateanim();
                rigid.AddForce(Vector3.up * forcejmp);
            }
        }
        if (Physics.Raycast(this.transform.position, Vector3.down, dist))
        {
            if (saltar) {
                saltar = false;
                if (moving) {
                    walking = true;
                    idle = false;
                } else {
                    idle = true;
                    walking = false;
                }
                
            }
            floor = true;
        }
        else {
            floor = false;
            idle = false;
            walking = false;
        }

        if (Physics.Raycast(this.transform.position,Vector3.down, out hit)) {
            if (shdow.zfloor != hit.collider.transform.position.y + 0.14f) { 
            shdow.zfloor = hit.collider.transform.position.y + 0.14f;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            xx = 1;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xx = -1;
         
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            yy = 1;
          
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            yy = -1;
           
        }
        if (floor) {
        if (moving) {
            walking = true;
            idle = false;
        } 
            
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AnimMotor.frame = 0;
            walking = true;
            idle = false;
            moving = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow)) {

            AnimMotor.animid = 13;
            AnimMotor.frame = 0;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            
            AnimMotor.animid = 9;
            AnimMotor.frame = 0;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
 
            AnimMotor.animid = 11;
            AnimMotor.frame = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
        
            AnimMotor.animid = 15;
            AnimMotor.frame = 0;
        }
        if (!Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow)){
            walking = false;
            idle = true;
            moving = false;
        }
    }

        this.transform.Translate(-yy * MovSPD, 0f, xx * MovSPD);
        if (Input.GetKeyDown(KeyCode.C)) {
            iv.Dbg_show();
        }
    }

    void DirUpd() {
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
    void S() {
        saltar = true;
    }
    void Upd() {
         
    }
    void MovAnimMotor() {
        AnimMotor.play = true;
        if (walking) {
        AnimMotor.animid = dirbef-1;
        }
        if (idle) {
        AnimMotor.animid = dirbef+8;
        }
        if (!floor) {
            
            AnimMotor.animid = dirbef+16;
        }
    }
}
