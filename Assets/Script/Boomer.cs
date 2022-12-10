using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{
    GameObject player;
    public Animator chaAni;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Blue Witch");
        if ((player.transform.position - transform.position).magnitude < 4f)
        {
            chaAni.SetBool("attack", true);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
