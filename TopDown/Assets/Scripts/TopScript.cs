using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScript : MonoBehaviour
{
    public GameObject Bottom;
    public GameObject Bullet;
    public Transform FirePoint;
    private Vector3 AimPoint;
    private Camera cam;
    public float reloadStart;
    public float reloadTime;
    public PlayerMovement PlayerMovement;
    public bool dead = false;
    public Animator animator;
    public GameObject MainBody;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        PlayerMovement playerMovement = Bottom.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Input.GetButton("Fire2"))
            {
                AimPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                var dir = AimPoint - transform.position;
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                angle -= 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            transform.position = Bottom.transform.position;


            if (Input.GetKeyDown("space") && Time.time >= reloadStart + reloadTime)
            {
                Instantiate(Bullet, FirePoint.position, transform.rotation);
                reloadStart = Time.time;
            }
        }
        if (PlayerMovement.health < 1)
        {
            animator.SetTrigger("PLaDeath");
            dead = true;
        }
    }
    void OnDestroy()
    {
        Destroy(MainBody.gameObject);
    }
}
