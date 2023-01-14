using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/BulletDamageTree")]
public class Reaper : Effect
{
    public string Effect;
    public override void ApplyEffect()
    {
        if(Effect=="Reaper")
            GameManager.instance.Reaper = true;
        if(Effect=="Spliter")
            GameManager.instance.Spliter = true;
        if (Effect == "Assassin")
            GameManager.instance.assassin = true;
    }
}
