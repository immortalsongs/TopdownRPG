using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public static Lightning instance;
    public GameObject lightning;
    public float Damage = 100f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnLightning(Vector3.zero);
        //}
    }
    public void SpawnLightning(Vector3 pos)
    {
        Instantiate(lightning, new Vector3(pos.x, pos.y + 5.3f, pos.z), Quaternion.identity);
    }

}
