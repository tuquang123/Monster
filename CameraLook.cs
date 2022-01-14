using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Animator cam;

    public void CamLooking()
    {
        cam.SetTrigger("looking");
    }
}
