using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGate : MonoBehaviour
{
    bool inShop = false;
    BoxCollider2D box;
    EdgeCollider2D edge;
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        edge = GetComponent<EdgeCollider2D>();
        box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if (!inShop)
            {
                box.enabled = true;
                collision.gameObject.transform.position = new Vector3(-3, 25, 8);
                GameManager.instance.SwitchCamera();
                inShop = true;
            } else
            {
                box.enabled = false;
                collision.gameObject.transform.position = new Vector3(-3, 2.5f, 0);
                GameManager.instance.SwitchCamera();
                inShop = false;
            }
        }
    }
}
