using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBanditBoss : MonoBehaviour
{
    CircleCollider2D range;
    Rigidbody2D rb;
    public float maxSpeed, minSpeed, step;
    public AnimationCurve aniCurve;
    Enemies self;
    float count = 3f;
    public Animator chaAni;

    // Start is called before the first frame update
    void Start()
    {
        self = this.GetComponent<Enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if (count < 0)
            {
                chaAni.SetBool("attack", true);
                StartCoroutine(MoveObject(collision.transform.position, 0.6f));
            }
        }
    }
    public IEnumerator MoveObject(Vector3 targetPos, float duration)
    {
        self.speed = 0;
        yield return new WaitForSeconds(0.4f);
        self.speed = 0.35f;
        float time = 0;
        float rate = 1 / duration;
        Vector3 startPos = transform.position;
        while (time < 0.5)
        {
            time += rate * Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, targetPos, aniCurve.Evaluate(time));
            yield return 0;
        }
        chaAni.SetBool("attack", false);
        count = 3f;
    }

}
