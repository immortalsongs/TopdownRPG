using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUp : MonoBehaviour
{
    PowerUp upgrade;
    public Text up;
    public GameObject UpPopUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup(PowerUp temp)
    {
        upgrade = temp;
        up.text = upgrade.name;
    }
    public void OnClick()
    {
        upgrade.Apply();
        UpPopUp.SetActive(false);
        Time.timeScale = 1;
        Upgrade.instance.Dele(upgrade);
    }
}
