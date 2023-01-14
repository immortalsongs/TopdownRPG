using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpgrade : MonoBehaviour
{
    int EXP;
    int MaxEXP=2;
    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        EXP = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="exp")
        {
            Destroy(collision.gameObject);
            EXP++;
            if(EXP>=MaxEXP)
            {
                EXP = 0;
                MaxEXP = (MaxEXP + 2) * 2;
                slide.maxValue = MaxEXP;
                Upgrade.instance.LevelUP();
            }
            slide.value = EXP;

        }
    }
}
