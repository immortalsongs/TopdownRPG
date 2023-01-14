using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP : MonoBehaviour
{
    GameObject Player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if ((Player.transform.position - transform.position).magnitude < 5)
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
}
