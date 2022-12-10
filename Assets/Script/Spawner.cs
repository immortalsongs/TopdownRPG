using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject LBandit, HBandit, Shield, Boomer, Goblin, SkeletonBoss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLBandit()
    {
        Instantiate(LBandit, transform.position, Quaternion.identity);
    }
    public void SpawnHBandit()
    {
        Instantiate(HBandit, transform.position, Quaternion.identity);
    }
    public void SpawnShield()
    {
        Instantiate(Shield, transform.position, Quaternion.identity);
    }
    public void SpawnBoomer()
    {
        Instantiate(Boomer, transform.position, Quaternion.identity);
    }
    public void SpawnGoblin()
    {
        Instantiate(Goblin, transform.position, Quaternion.identity);
    }
    public void SpawnSkeletonBoss()
    {
        Instantiate(SkeletonBoss, transform.position, Quaternion.identity);
    }
}
