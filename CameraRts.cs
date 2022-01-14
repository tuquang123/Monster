using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraRts : MonoBehaviour
{
    public Vector2 panLimit;
    public float panSpeed = 20f;
    private void Update()
    {
        Vector3 pos = transform.position;
        if (CrossPlatformInputManager.GetButton("camr"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (CrossPlatformInputManager.GetButton("caml"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
    }
}
