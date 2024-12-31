using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuEnemy : MonoBehaviour
{
    public Animator animator;
    public float tpPoint;
    public float stopPoint;
    public float tpX;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,speed,0) * Time.deltaTime;
        animator.SetBool("Moving", true);
        if (Math.Abs(transform.position.y) >= stopPoint)
        {
            transform.position = new Vector3(tpX, tpPoint, 0);
        }
    }
}
