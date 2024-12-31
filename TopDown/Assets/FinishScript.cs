using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public GameObject[] EnemyTotal;
    public GameObject[] EnemyCount;
    public Text text;
    public int total;
    public int count;
    // Start is called before the first frame update
    void Awake()
    {
        EnemyTotal = GameObject.FindGameObjectsWithTag("Enemy");
        total = EnemyTotal.Length;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount = GameObject.FindGameObjectsWithTag("Enemy");
        count = EnemyTotal.Length-EnemyCount.Length;
        text.text = count.ToString() + "/" + total.ToString() ;
        if(EnemyCount.Length == 0)
        {
            Debug.Log("Finish");
        }
    }
}
