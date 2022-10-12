using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFire : MonoBehaviour
{
    public float lifeTime = 3f;
    public float Damage = 5f;
    Enemies parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) Destroy(gameObject);
        if (parent == null) 
        { 
            parent = gameObject.transform.parent.gameObject.GetComponent<Enemies>();
            StartCoroutine(DealDamage());
        }
    }

    IEnumerator DealDamage()
    {
        parent.hp -= Damage;
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(DealDamage());
    }
}
