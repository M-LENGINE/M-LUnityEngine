using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public Transform target;
    public float spd;
    public Animator Fadeanim;
    public bool warping;
    // Update is called once per frame
    void Update()
    {
        if (!warping) {
            this.transform.position = Vector3.Lerp(this.transform.position, target.position, spd);
        }
       
    }
    public void Warp() {
        warping = true;
        Fadeanim.SetBool("Warp", true);
    }
}
