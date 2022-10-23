using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetKeyDown("E"))
            {
                anim.SetBool("openChest",true);
                
            }
        }
    }
    
    
}
