using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestroyonload : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Global");
        GameObject[] obj2 = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < obj.Length; i += 1) {
            DontDestroyOnLoad(obj[i]);
            for (int ii = 0; ii < obj2.Length; ii += 1)
            {
                DontDestroyOnLoad(obj2[ii]);
            }
        }
    }
}
