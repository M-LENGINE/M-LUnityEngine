using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Warp : MonoBehaviour
{
    public PlayerMov Mario;
    public CameraMov cameramov;
    public int direction;
    public string scene;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character") {
            Mario.warping = true;
            Mario.warpdir = direction;
            cameramov.Warp();
            Invoke("gotoscene", 3f);
        }
    }
    void gotoscene() {
        SceneManager.LoadScene(scene);
    }
}
