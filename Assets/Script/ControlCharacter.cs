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
    int bulletCount;
    public int mag;
    public float reloadSpeed;
    bool isReloading = false;

    public float bulletSpeed;

    public Animator animator;
    public Camera mainCamera;



    Vector3 MousePos;
    float angle;
    Vector3 dir;

    BoxCollider2D box;

    public float HP;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        bulletCount = mag;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("attack", true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            animator.SetBool("attack", false);
        }
        if(bulletCount<=0 && !isReloading)
        {
            isReloading = !isReloading;
            StartCoroutine(Reload());
        }
        dir = -transform.position + MousePos;
        angle = Mathf.Atan2(dir.y , dir.x)* 57.2957795f;
        //Debug.Log(angle);
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Horizontal, Vertical, 0) * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            GetHit();
        }
    }

    public void Attack()
    {
        if (bulletCount > 0)
        {
            bulletCount--;
            if(bulletCount%3==0)
            {
                GameManager.instance.lightning = true;
            }
            GameObject temp = Instantiate(Bullet, ShootPoint.transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddForce(dir.normalized * bulletSpeed);
            temp.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = !isReloading;
        bulletCount = mag;
    }

    public void GetHit()
    {
        animator.SetBool("hit", true);
        box.enabled = false;
    }
    public void AfterHit()
    {
        animator.SetBool("hit", false);
        box.enabled = true;
    }
}
