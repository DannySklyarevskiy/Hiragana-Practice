using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Animator shake;
    
    public void CamShake()
    {
        shake.SetTrigger("shake");
    }

    public void SmallCamShake()
    {
        shake.SetTrigger("small shake");
    }
}
