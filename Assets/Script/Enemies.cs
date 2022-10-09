using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Blue Witch");
        transform.Translate((player.transform.position - transform.position) * speed*Time.deltaTime);
        if(hp<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="bullet")
        {
            WaterAttack temp = collision.gameObject.GetComponent<WaterAttack>();
            hp -= temp.Damage;
            GameManager.instance.Hit(transform.position);
        }
    }

}
