using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScr : MonoBehaviour
{
    public Transform target;
    public float zfloor;
    public Animator shdow;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(target.position.x, zfloor, target.position.z);
    }
    void rst()
    {
        shdow.SetBool("JMP", false);
    }
    public void Anim() {
        shdow.SetBool("JMP", true);
        Invoke("rst", 0.1f);
    }
    
    
}
