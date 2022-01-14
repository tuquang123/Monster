using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public static Layer instance;

    public int LayerHero;
    public int LayerBullet;

    private void Awake()
    {
        Layer.instance = this;
        Physics.IgnoreLayerCollision(LayerHero, LayerBullet, true);
    }
    private void Start()
    {
        GetLayer();
    }

    private void GetLayer()
    {
        LayerHero = LayerMask.NameToLayer("Player");
        LayerBullet = LayerMask.NameToLayer("Bullet");
    }

}
