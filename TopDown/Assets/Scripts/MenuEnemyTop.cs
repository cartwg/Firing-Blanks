using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemyTop : MonoBehaviour
{
    public GameObject Bottom;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Bottom.transform.position;
    }
}
