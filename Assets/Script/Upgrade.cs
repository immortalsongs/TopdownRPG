using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Upgrade : MonoBehaviour
{
    public static Upgrade instance;
    public List<PowerUp> list;
    int[] temp=new int[3];
    public ButtonUp up1, up2, up3;
    int lastNumber,lastlastNumber;
    int count=0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUP()
    {
        if (count > 8) return;
        gameObject.SetActive(true);
        for(int i=0;i<3;i++)
        {
            temp[i]=GetRandom(0, list.Count-1);
            Debug.Log(list.Count);
            Debug.Log(list[temp[i]]);
        }
        up1.Setup(list[temp[0]]);
        up2.Setup(list[temp[1]]);
        up3.Setup(list[temp[2]]);
        Time.timeScale = 0;
        count++;
    }
    int GetRandom(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastNumber || rand== lastlastNumber)
            rand = Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }

    public void Dele(PowerUp up)
    {
        list.Remove(up);
    }
}
