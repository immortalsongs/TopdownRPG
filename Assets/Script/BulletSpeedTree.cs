using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Power Up/Bullet Speed Tree")]
public class BulletSpeedTree : PowerUp
{
    public string Name;
    public int BulletSpeed;
    public int FireRate;
    public int Knockback;
    public int Pierce;
    public int BulletDamage;
    public Effect effect;

    // Start is called before the first frame update
    public override void Apply()
    {
        GameManager.instance.AffectBulletSpeed(BulletSpeed).AffectAttackSpeed(FireRate).AffectKnockback(Knockback).AffectPiercing(Pierce).AffectDamage(BulletDamage);
        effect.ApplyEffect();
    }
}
