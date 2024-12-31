using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject MovePoint;
    public float speed;
    public Vector3 MoveTo;
    public float health;
    public HealthBar healthBar;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        MovePoint = GameObject.FindWithTag("MovePoint");
        if (MovePoint != null && health > 0)
        {
            
            MoveTo = new Vector3(MovePoint.transform.position.x, MovePoint.transform.position.y, 0);
            if (Vector3.Distance(transform.position, MoveTo) > 0.01f)
            {
                var dir = MoveTo - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                angle -= 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                animator.SetBool("Moving", true);
            }
            else
            {
                animator.SetBool("Moving", false);
            }
            transform.position = Vector3.MoveTowards(transform.position, MoveTo, speed * Time.deltaTime);

        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            health -= 1;
            healthBar.SetHealth(health);
        }
    }
}
