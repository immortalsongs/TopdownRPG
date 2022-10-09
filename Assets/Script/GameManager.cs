using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool lightning, fire;
    // Start is called before the first frame update
    void Start()
    {
        lightning = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(Vector3 pos)
    {
        if(lightning)
        {
            Lightning.instance.SpawnLightning(pos);
        }

    }
}
