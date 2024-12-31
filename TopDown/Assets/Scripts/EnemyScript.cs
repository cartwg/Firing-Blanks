using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject Player;
    public Vector3 PlayerPosition;
    public float speed;
    public float health = 5;
    public Animator animator;
    public HealthBar healthBar;
    public bool alive = false;
    public EnemyTop enemyTop;
    public GameObject Top;
    // Start is called before the first frame update
    void Awake()
    {
        EnemyTop enemyTop = Top.GetComponent<EnemyTop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            PlayerPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, 0);
        }
        if (Vector3.Distance(transform.position, PlayerPosition) > 5f && Vector3.Distance(transform.position, PlayerPosition) < 10f && alive == true)
        {
            var dir = PlayerPosition - transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle -= 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, PlayerPosition, speed * Time.deltaTime);
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            health -= 1;
            healthBar.SetHealth(health);
            alive = true;
            enemyTop.Alive();
        }

    }
    public void WakeUp()
    {
        alive = true;
    }

}
