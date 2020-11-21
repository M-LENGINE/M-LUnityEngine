using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SPRANIM {
    public string name;
    public Sprite[] Spr;
    public int spd;
    public bool mirror, flip;
}
public class SpriteAnim : MonoBehaviour
{
    public SPRANIM[] Animations;
    public int animid;
    public int frame;
    public int counter;
    public bool len;
    public bool play;
    public SpriteRenderer rend;
     void Start()
    {
        Application.targetFrameRate = 60;
        if (Animations[animid].Spr.Length > 1)
        {

            len = true;
        }
        if (Animations[animid].Spr.Length <= 1)
        {
            len = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
        if(play) {
            counter += 1;
            if (counter > Animations[animid].spd) {
            Updateframe();
           
        }
           
        }
        rend.flipX = Animations[animid].mirror;
        rend.flipY = Animations[animid].flip;
        if (len) {
            if (frame >= Animations[animid].Spr.Length)
            {
                frame = 0;
            }
        }
        else
        {
            if (frame >= Animations[animid].Spr.Length)
            {
                frame = 0;
            }
        }
       
        
    }
    public void updateanim() {
        rend.sprite = Animations[animid].Spr[frame];

    }
    void Updateframe() {
        counter = 0;
        rend.sprite = Animations[animid].Spr[frame];

        frame += 1;
  
     
    }
}
