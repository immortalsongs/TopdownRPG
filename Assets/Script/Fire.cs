using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire instance;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnFire(Enemies go)
    {
        GameObject temp = Instantiate(fire, go.transform.position, Quaternion.identity);
        temp.transform.parent = go.gameObject.transform;
    }
}
