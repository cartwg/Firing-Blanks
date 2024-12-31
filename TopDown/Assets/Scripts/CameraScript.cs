using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset = new Vector3(0, 0, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player != null)
        {
            transform.position = Player.transform.position + offset;
        }
        
    }
}
