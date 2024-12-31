using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTop : MonoBehaviour
{

    public GameObject Bottom;
    public GameObject Bullet;
    public Transform FirePoint;
    private Vector3 AimPoint;
    public GameObject Player;
    private Camera cam;
    public float reloadStart;
    public float reloadTime;
    public Animator animator;
    public EnemyScript enemyScript;
    public GameObject Enemy;
    public bool alive = false;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    void Awake()
    {
        EnemyScript enemyScript = Bottom.GetComponent<EnemyScript>();
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Bottom.transform.position;
        if (Player!=null )
        {
            AimPoint = Player.transform.position;
        }
        if (Vector3.Distance(transform.position, AimPoint) < 10f && alive == true)
        {
            var dir = AimPoint - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        if (Vector3.Distance(transform.position, AimPoint) < 7f && Time.time >= reloadStart + reloadTime && alive == true)
        {
            Instantiate(Bullet, FirePoint.position, transform.rotation);
            reloadStart = Time.time;

        }
        if (enemyScript.health < 1)
        {
            animator.SetTrigger("Death");
           
        }
        Vector3 up = transform.TransformDirection(Vector3.up) * 10;
        RaycastHit2D hit = Physics2D.Raycast(FirePoint.position, AimPoint-FirePoint.position);
        Debug.DrawRay(FirePoint.position, AimPoint-FirePoint.position, Color.green);
        if (hit.collider.tag == "Player")
        {
            alive = true;
            enemyScript.WakeUp();
        }
    }
    void OnDestroy()
    {
        Destroy(Enemy);
    }
    public void Alive()
    {
        alive = true;
        enemyScript.WakeUp();
    }

}
