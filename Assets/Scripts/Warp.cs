using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class WarpObject {
    public Vector3 where;
    public int exitdirection;
}
public class Warp : MonoBehaviour
{
    public PlayerMov Mario;
    public CameraMov cameramov;
    public WarpObject warp;
    public string scene;
    public int entracedirection;
    public void OnTriggerEnter(Collider other)
    {
        if (!Mario.warping) { 
        if (other.tag == "Character") {
            RememberWarp ConfigWarp = GameObject.Find("Conf").GetComponent<RememberWarp>();
            ConfigWarp.wherewarp = warp;
            ConfigWarp.wasWarping = true;
            Mario.warping = true;
            Mario.warpdir = entracedirection;
            cameramov.Warp();
            Invoke("gotoscene", 3f);
        }
        }
    }
    void gotoscene() {
        SceneManager.LoadScene(scene);
    }
}
