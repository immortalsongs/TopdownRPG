using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Power Up/Damage Tree")]
public class BulletDamageTree : PowerUp
{
    public string Name;
    public int Damage;
    public int FireRate;
    public int Knockback;
    public int Pierce;
    public Effect effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Apply()
    {
        GameManager.instance.AffectDamage(Damage).AffectAttackSpeed(FireRate).AffectKnockback(Knockback).AffectPiercing(Pierce);
        if(effect!=null)
            effect.ApplyEffect();
    }
}
