using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    GameObject player;
    public float lifeTime;
    public Animator chaAni;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(FinePlayer());
        //sdir = (player.transform.position - transform.position).normalized;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        
        if(lifeTime<0)
        {
            StartCoroutine(End());
        }
    }

    IEnumerator Move()
    {
        
        transform.position += dir;
        yield return new WaitForSeconds(0.15f);
        StartCoroutine(Move());
    }

    IEnumerator FinePlayer()
    {
        //yield return new WaitForSeconds(1.5f);
        player = GameObject.Find("Blue Witch");
        dir = (player.transform.position - transform.position).normalized;
        yield return new WaitForSeconds(0.5f);
        
        StartCoroutine(FinePlayer());
    }

    IEnumerator End()
    {
        chaAni.SetBool("end", true);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        StopAllCoroutines();
        
    }

}
