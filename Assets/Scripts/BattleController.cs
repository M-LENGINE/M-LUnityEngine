using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public BattleCameraSCR camara;
    public SpriteAnim MarioSpr;
    public bool marioturn;
    public ThinkBlocks think;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MarioTurn", 2f);
    }
    void MarioTurn() {
        marioturn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (marioturn)
        {
            think.active = true;
            MarioSpr.animid = 1;
            camara.curr = 1;
        }
        else {
            think.active = false;
        }
    }
    void Jmp() { 
    
    }
}