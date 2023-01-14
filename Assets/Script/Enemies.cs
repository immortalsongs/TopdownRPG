using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    public float BaseHp;
    public float hp;
    bool isRotate=false;

    public GameObject EXP;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Blue Witch");
        transform.Translate((player.transform.position - transform.position) * speed*Time.deltaTime);
        if (transform.position.x < player.transform.position.x)
        {
            if (isRotate == false)
            {
                //transform.Rotate(new Vector3(0, 180f, 0));
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                isRotate = !isRotate;
            }
        }
        else if (isRotate)
        {
            //transform.Rotate(new Vector3(0, 180f, 0));
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isRotate = !isRotate;
        }

        if (hp<=0)
        {
            Instantiate(EXP, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            WaterAttack temp = collision.gameObject.GetComponent<WaterAttack>();
            hp -= temp.Damage;
            temp.Pierce--;
            GameManager.instance.Hit(this);
            StartCoroutine(Knockback(collision.gameObject));
        }
    }

    IEnumerator Knockback(GameObject Sender)
    {
        Vector3 dir = (transform.position - Sender.transform.position).normalized;
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * GameManager.instance.Knockback, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.15f);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}
