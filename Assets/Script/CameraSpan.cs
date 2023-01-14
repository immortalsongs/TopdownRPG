using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSpan : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        vcam.m_Lens.OrthographicSize = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CameraSpanWhenClick()
    {
        vcam.m_Lens.OrthographicSize = 10;
    }
}
