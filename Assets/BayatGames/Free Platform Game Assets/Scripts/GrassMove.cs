using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMove : MonoBehaviour
{

    public float maxDistance = 10;
    public float moveSpeed = 1;
    public float moveDistance;
    public float moveDirection = 1;
    private float movedDis;
    
    
    void FixedUpdate()
    {
        moveDistance = moveSpeed * Time.fixedDeltaTime;
        
        this.transform.position += new Vector3(0, moveDistance*moveDirection, 0);
        movedDis += moveDistance;
        if (Mathf.Abs(movedDis) > maxDistance )
        {
            moveDirection = -moveDirection;
            movedDis = 0;
            
        }
    }
}
