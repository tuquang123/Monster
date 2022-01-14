using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaiMono : MonoBehaviour
{
    private void Awake()
    {
        this.LoadComponents();
    }
    private void Reset()
    {
        //loadPlayer();
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {

    }
}
