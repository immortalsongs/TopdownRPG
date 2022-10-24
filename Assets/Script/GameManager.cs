using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool lightning, fire;
    public CinemachineVirtualCamera vcamPlayer;
    public CinemachineVirtualCamera vcamShop;
    bool isShop=false;
    public WaterAttack WaterAttack;
    public AnimationFire AnimationFire;

    //stats
    [SerializeField]
    float HP=4;
    [SerializeField]
    float Movement=5;
    [SerializeField]
    float AttackSpeed=1;
    [SerializeField]
    float Reload;
    [SerializeField]
    float BulletSpeed=2000;
    [SerializeField]
    public float Knockback = 5;
    [SerializeField]
    public float Piercing = 0;
    [SerializeField]
    float Damage=10;
    [SerializeField]
    int NumBullet=15;
    [SerializeField]
    float FireDamage=5;
    [SerializeField]
    float LightningDamage=80;

    public bool Spliter=false;
    public bool Reaper=false;
    public bool assassin = false;

    // Start is called before the first frame update
    void Start()
    {
        lightning = false;
        fire = false;
        Spliter = true;
        instance = this;
        //AffectDamage(100);
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
            lightning = !lightning;
        }
        if(fire)
        {
            Fire.instance.SpawnFire(go);
        }
        if(Spliter && go.hp<=0)
        {
            SpliterEffect(go.gameObject);
        }
        if(Reaper && go.hp<=0 && Piercing<10)
        {
            Piercing++;
        }
        if (assassin) Assassin(go);
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

    public GameManager AffectHp(int hp)
    {
        HP += hp;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().HP =HP;
        Debug.Log("HP");
        return this;
    }
    public GameManager AffectMoveSpeed(int speed)
    {
        Movement += Movement* speed/100;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().speed = Movement;
        Debug.Log("ms");
        return this;
    }
    public GameManager AffectAttackSpeed(int speed)
    {
        AttackSpeed += AttackSpeed* speed/100;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().animator.SetFloat("attackMulti", AttackSpeed);
        Debug.Log("as");
        return this;
    }
    public GameManager AffectBulletSpeed(int speed)
    {
        BulletSpeed += BulletSpeed* speed/100;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().bulletSpeed=BulletSpeed;
        Debug.Log("bs");
        return this;
    }
    public GameManager AffectReload(int speed)
    {
        Reload += Reload* speed/100;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().reloadSpeed = Reload;
        Debug.Log("rs");
        return this;
    }
    public GameManager AffectDamage(int damage)
    {
        Damage +=Damage* damage/100;
        WaterAttack.Damage = Damage;
        Debug.Log("damage");
        return this;
    }
    public GameManager AffectBulletNum(int num)
    {
        NumBullet += num;
        GameObject.Find("Blue Witch").GetComponent<ControlCharacter>().mag = NumBullet;
        Debug.Log("mag");
        return this;
    }

    public GameManager AffectLightningDamage(int damage)
    {
        LightningDamage += LightningDamage* damage/100;
        Lightning.instance.Damage = LightningDamage;
        Debug.Log("lightning");
        return this;
    }
    public GameManager AffectFireDamage(int damage)
    {
        FireDamage += FireDamage* damage/100;
        AnimationFire.Damage = LightningDamage;
        Debug.Log("fire");
        return this;
    }
    public GameManager AffectKnockback(int strenght)
    {
        Knockback += Knockback * strenght / 100;
        Debug.Log("knock");
        return this;
    }
    public GameManager AffectPiercing(int strenght)
    {
        Piercing += Piercing* strenght / 100;
        Debug.Log("pierce");
        return this;
    }

    void SpliterEffect(GameObject go)
    {
        float angle = 0;
        for (int i = 0; i < 5; i++)
        {
            GameObject temp = Instantiate(WaterAttack.gameObject, go.transform.position, Quaternion.identity);
            temp.transform.rotation = Quaternion.Euler(0, 0, angle);
            temp.GetComponent<Rigidbody2D>().AddForce(temp.transform.right*500);
            angle += 72;

        }
    }

    void Assassin(Enemies go)
    {
        if(go.hp<=go.BaseHp*0.2)
        {
            Destroy(go.gameObject);
        }
    }
}
