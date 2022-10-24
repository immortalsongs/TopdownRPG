using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public PowerUp temp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        temp.Apply();
    }

}
