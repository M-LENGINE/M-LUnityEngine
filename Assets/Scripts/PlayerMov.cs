﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMov : MonoBehaviour
{
    public SpriteAnim AnimMotor;
    public float MovSPD,xx,yy,jmpdist,forcejmp;
    public bool jumping, walking, idle, floor, landing;
    public bool warping = false;
    public bool caninput;
    public Rigidbody rigid;
    public ShadowScr shdow;
    private RaycastHit hit;
    public float dist;
    public bool saltar;
    public int dirbef;
    public bool moving;
    public InventorySystem iv;
    public AudioSource Jump;
    public int warpdir = 0; // 0 - right, 1 - up, 2 - left, 3 - down.
    public RememberWarp ConfigWarp;
    // Start is called before the first frame update
    void Start()
    {

        ConfigWarp = GameObject.Find("Conf").GetComponent<RememberWarp>();
        if (ConfigWarp.wasWarping) {
            warping = true;
            this.transform.position = ConfigWarp.wherewarp.where;
            warpdir = ConfigWarp.wherewarp.exitdirection;
            Invoke("warpvolver", 1f);
        }
        Application.targetFrameRate = 60;
    }
    void warpvolver() {
        caninput = true;
        warping = false;
        xx = 0;
        yy = 0;
    }
    // Update is called once per frame
    void Update()
    {
        DirUpd();
         AnimMotor.updateanim();
        
        MovAnimMotor();
        if (floor & !jumping)
        {
            if (caninput) { 
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Jump.Play();
                Invoke("S",0.1f);
                AnimMotor.frame = 0;
                AnimMotor.counter = 0;
                shdow.Anim();
                AnimMotor.updateanim();
                rigid.AddForce(Vector3.up * forcejmp);
                landing = false;
                walking = false;
                idle = false;
            }
            }
        }
        Debug.DrawLine(new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z), new Vector3(this.transform.position.x, 0f,this.transform.position.z),Color.red);
        if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 0.15f, this.transform.position.z), Vector3.down, dist))
        {
            
            if (saltar) {
                saltar = false;

                if (moving) {
                    walking = true;
                    idle = false;
                } else {
                    idle = false;
                    walking = false;
                    landing = true;
                    AnimMotor.frame = 0;
                    Invoke("StopLand", 0.5f);
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
        if (caninput) {
            if (Input.GetKey(KeyCode.RightArrow))
            {
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
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                xx = 0;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                yy = 0;
            }
        }
       
        if (floor) {
        if (moving) {
            walking = true;
            idle = false;
        } 
         if (caninput) { 
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AnimMotor.frame = 0;
            walking = true;
            idle = false;
            moving = true;
            landing = false;
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
        }

        this.transform.Translate(-yy * MovSPD, 0f, xx * MovSPD);
        if (Input.GetKeyDown(KeyCode.C)) {
            iv.Dbg_show();
        }
    }
    void StopLand() {
        walking = false;
        idle = true;
        landing = false;
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
        if (!warping)
        {
            if (!floor)
            {

                AnimMotor.animid = dirbef + 16;
            }
            if (!landing)
            {
                if (idle)
                {
                    AnimMotor.animid = dirbef + 8;
                }
            }
            else
            {
                AnimMotor.animid = dirbef + 24;
            }
        }
        else {
            walking = true;
            idle = false;
            jumping = false;
            landing = false;
            caninput = false;
            if (warpdir == 0) {
                xx = 1;
                yy = 0;
            }else if (warpdir == 1)
            {
                xx = 0;
                yy = 1;
            }
            else if (warpdir == 2)
            {
                xx = -1;
                yy = 0;
            }
            else if (warpdir == 3)
            {
                xx = 0;
                yy = -1;
            }

        }
        
    }
}
