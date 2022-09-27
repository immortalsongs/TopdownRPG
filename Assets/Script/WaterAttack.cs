using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    public float speed;
    public float lifeTine=5;
    public float Damage = 100;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTine -= Time.deltaTime;
        if (lifeTine < 0) Destroy(gameObject);
    }
    //void Spawn()
    //{
    //    rb.AddForce((Vector2.right) * speed);
    //}
}
