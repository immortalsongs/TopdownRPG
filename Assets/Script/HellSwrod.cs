using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellSwrod : MonoBehaviour
{
    public GameObject Fire;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFire());
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        transform.parent.RotateAround(Vector3.forward, -360);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            GameManager.instance.Hit(collision.gameObject.GetComponent<Enemies>());
        }
    }

    IEnumerator SpawnFire()
    {
        Fire.GetComponent<AnimationFire>().SpawnFire(transform.position);
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(SpawnFire());
    }
}
