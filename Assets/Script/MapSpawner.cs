using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject GroundX, GroundY;
    //10
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Blue Witch");
        if(Mathf.Abs(transform.position.x-player.transform.position.x)>=10)
        {
            
            Instantiate(GroundX, player.transform.position+new Vector3(22 * -((transform.position.x - player.transform.position.x) / Mathf.Abs(transform.position.x - player.transform.position.x)), 0,8), Quaternion.identity);
            transform.position = player.transform.position;
        }
        if (Mathf.Abs(transform.position.y - player.transform.position.y) >= 10)
        {

            Instantiate(GroundY, player.transform.position + new Vector3(0, 22 * -((transform.position.y - player.transform.position.y) / Mathf.Abs(transform.position.y - player.transform.position.y)), 8), Quaternion.identity);
            transform.position = player.transform.position;
        }
    }
}
