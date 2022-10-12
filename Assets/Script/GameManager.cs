using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool lightning, fire;
    public CinemachineVirtualCamera vcamPlayer;
    public CinemachineVirtualCamera vcamShop;
    bool isShop=false;
    // Start is called before the first frame update
    void Start()
    {
        lightning = true;
        fire = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(Enemies go)
    {
        if(lightning)
        {
            Lightning.instance.SpawnLightning(go.transform.position);
            go.hp -= Lightning.instance.Damage;
        }
        if(fire)
        {
            Fire.instance.SpawnFire(go);
        }
    }

    public void SwitchCamera()
    {
        if(!isShop)
        {
            vcamPlayer.Priority = 0;
            vcamShop.Priority = 1;
            isShop = !isShop;
        } else if (isShop)
        {
            vcamPlayer.Priority = 1;
            vcamShop.Priority = 0;
            isShop = !isShop;
        }
    }
}
