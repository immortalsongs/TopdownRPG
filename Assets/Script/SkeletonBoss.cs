using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBoss : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject ShootPoint, ShootPoint1, ShootPoint2;
    public Animator chaAni;
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        chaAni.SetBool("attack", true);
        yield return new WaitForSeconds(1.5f);
        chaAni.SetBool("attack", false);
        yield return new WaitForSeconds(8f);
        StartCoroutine(Attack());
    }

    public void Slash()
    {
        Instantiate(bullet, ShootPoint.transform.position, Quaternion.identity);
        Instantiate(bullet, ShootPoint1.transform.position, Quaternion.identity);
        Instantiate(bullet, ShootPoint2.transform.position, Quaternion.identity);
    }
}
