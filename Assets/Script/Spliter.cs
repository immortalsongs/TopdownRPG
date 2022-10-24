using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Power Up/Spliter")]
public class Spliter : Effect
{
    // Start is called before the first frame update
    public override void ApplyEffect()
    {
        GameManager.instance.Spliter = true;
    }
}
