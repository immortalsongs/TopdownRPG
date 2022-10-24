using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFire : MonoBehaviour
{
    public float lifeTime = 3f;
    public float Damage = 5f;
    Enemies parent;
    public bool isAlone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) Destroy(gameObject);
        if (parent == null && !isAlone) 
        { 
            parent = gameObject.transform.parent.gameObject.GetComponent<Enemies>();
            StartCoroutine(DealDamage());
        }
   
    }

    IEnumerator DealDamage()
    {
        parent.hp -= Damage;
        yield return new WaitForSeconds(1f);
        StartCoroutine(DealDamage());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isAlone && collision.gameObject.tag=="Enemy")
        {
            Fire.instance.SpawnFire(collision.gameObject.GetComponent<Enemies>());
        }
    }

    public void SpawnFire(Vector3 pos)
    {
        AnimationFire temp = Instantiate(this.gameObject, pos, Quaternion.identity).GetComponent<AnimationFire>();
        temp.isAlone = true;
    }
}
