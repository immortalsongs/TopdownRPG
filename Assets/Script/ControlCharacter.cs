using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    float Horizontal, Vertical;
    public GameObject Bullet;
    public GameObject ShootPoint;


    public Animator animator;
    public Camera mainCamera;



    Vector3 MousePos;
    float angle;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    animator.SetBool("attack", true);
        //}
        //else
        //{
        //    animator.SetBool("attack", false);
        //}
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attack", true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("attack", false);
        }
        dir = -transform.position + MousePos;
        angle = Mathf.Atan2(dir.y , dir.x)* 57.2957795f;
        //Debug.Log(angle);
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Horizontal, Vertical, 0) * speed * Time.deltaTime;
    }

    public void Attack()
    {
        GameObject temp= Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 1000);
        temp.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}
