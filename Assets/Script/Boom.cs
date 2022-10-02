using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 player;
    public AnimationCurve aniCurve;
    Enemies self;
    public Animator chaAni;
    void Start()
    {
        self = this.GetComponent<Enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(GameObject playObject)
    {
        player = playObject.transform.position;
    }
    private void OnEnable()
    {
        StartCoroutine(Throw());
    }
    public IEnumerator Throw()
    {
        float time = 0;
        Vector3 startPos = transform.position;
        while (time < 1)
        {
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, player,time/5);
            transform.position += new Vector3(0, aniCurve.Evaluate(time),0);
            yield return 0;
        }
        yield return new WaitForSeconds(.3f);
        chaAni.SetBool("attack", true);
    }
    public void Explosion()
    {
        Destroy(gameObject);
    }
}
