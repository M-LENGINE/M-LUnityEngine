using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraSCR : MonoBehaviour
{

    public Vector3[] positions;
    public float spd;
    public int curr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, positions[curr], spd);
    }
}
