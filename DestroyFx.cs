using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : MonoBehaviour
{
    public float Time = 0.3f;
    private void Start()
    {
        //Invoke("Destroy", 0.5f);
    }
    //public float timeDestroy;
    void Update()
    {
        Invoke("Destroy", Time);
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        //Destroy(this.gameObject, timeDestroy);
    }
}
