using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    public GameObject boom, shootPoint;
    public Animator chaAni;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Blue Witch");
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log((player.transform.position - transform.position).magnitude);
        if((player.transform.position-transform.position).magnitude<15)
        {
            chaAni.SetBool("attack", true);
        } else chaAni.SetBool("attack", false);
    }

    public void Throw()
    {
        GameObject temp=Instantiate(boom, shootPoint.transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody2D>().AddForce((shootPoint.transform.position-transform.position).normalized *500);
        temp.GetComponent<Boom>().Spawn(player);
        temp.SetActive(true);
    }

}
