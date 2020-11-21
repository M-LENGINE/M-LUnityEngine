using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestroyonload : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Global");
        for (int i = 0; i < obj.Length; i += 1) {
            DontDestroyOnLoad(obj[i]);
        }
    }
}
