using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThinkBlocks : MonoBehaviour
{
    public Vector3[] Atk;
    public GameObject attack, bross, itemm, runn;
    public int selected;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //    2
    //  3   1
    //    0

    //    3
    //  0   2
    //    1

    //    0
    //  1   3
    //    2

    //    3
    //  0   2
    //    1
    void Update()
    {
        if (active)
        {
            attack.SetActive(true);
            bross.SetActive(true);
            runn.SetActive(true);
            itemm.SetActive(true);
        }
        else {
            attack.SetActive(false);
            bross.SetActive(false);
            runn.SetActive(false);
            itemm.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (selected == 3)
            {
                selected = 0;
            }
            else {
                selected += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selected == 0)
            {
                selected = 3;
            }
            else
            {
                selected -= 1;
            }
        }
        if (selected == 0) {
            
            // ATK
            attack.transform.localPosition = Vector3.Lerp(attack.transform.localPosition, Atk[0], 0.1f);
            bross.transform.localPosition = Vector3.Lerp(bross.transform.localPosition, Atk[1], 0.1f);
            runn.transform.localPosition = Vector3.Lerp(runn.transform.localPosition, Atk[2], 0.1f);
            itemm.transform.localPosition = Vector3.Lerp(itemm.transform.localPosition, Atk[3], 0.1f);
        } else if (selected == 1)
        {
            // Bros
            attack.transform.localPosition = Vector3.Lerp(attack.transform.localPosition, Atk[3], 0.1f);
            bross.transform.localPosition = Vector3.Lerp(bross.transform.localPosition, Atk[0], 0.1f);
            runn.transform.localPosition = Vector3.Lerp(runn.transform.localPosition, Atk[1], 0.1f);
            itemm.transform.localPosition = Vector3.Lerp(itemm.transform.localPosition, Atk[2], 0.1f);
        }
        else if (selected == 2)
        {
            // Run
            attack.transform.localPosition = Vector3.Lerp(attack.transform.localPosition, Atk[2], 0.1f);
            bross.transform.localPosition = Vector3.Lerp(bross.transform.localPosition, Atk[3], 0.1f);
            runn.transform.localPosition = Vector3.Lerp(runn.transform.localPosition, Atk[0], 0.1f);
            itemm.transform.localPosition = Vector3.Lerp(itemm.transform.localPosition, Atk[1], 0.1f);
        }
        else if (selected == 3)
        {
            // Item
            attack.transform.localPosition = Vector3.Lerp(attack.transform.localPosition, Atk[1], 0.1f);
            bross.transform.localPosition = Vector3.Lerp(bross.transform.localPosition, Atk[2], 0.1f);
            runn.transform.localPosition = Vector3.Lerp(runn.transform.localPosition, Atk[3], 0.1f);
            itemm.transform.localPosition = Vector3.Lerp(itemm.transform.localPosition, Atk[0], 0.1f);
        }
    }
}
