using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeedEffect : PowerUp
{
    public override void Apply()
    {
        GameManager.instance.assassin = true;
    }
}
