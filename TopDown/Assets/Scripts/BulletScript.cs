using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag != "bullet" )
        {
            Destroy(gameObject);
        }

    }
}
