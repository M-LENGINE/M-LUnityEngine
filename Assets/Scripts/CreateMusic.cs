using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusic : MonoBehaviour
{
    public GameObject music;
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Music");
        if (obj.Length >= 1) {
            for (int i = 1; i < obj.Length; i += 1) {
                Destroy(obj[i]);
            }
        }
    }
}
