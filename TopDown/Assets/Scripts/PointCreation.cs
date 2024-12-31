using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreation : MonoBehaviour
{
    public GameObject MovePoint;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate (MovePoint, cam.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
        }
    }
}
