using Assets.HeroEditor.Common.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManagers : MonoBehaviour
{
    public static HeroManagers instance;
    public HeroManager[] heroManagers;


    private void Awake()
    {
        if (HeroManagers.instance != null) Debug.LogError("only hero");
        HeroManagers.instance = this;
    }
  
    private void Reset()
    {
        this.LoadComponents();
    }

    private void LoadComponents()
    {
        this.loadHeroComponent();
    }
    private void loadHeroComponent()
    {
        if (heroManagers.Length > 0) return;
        heroManagers = transform.GetComponentsInChildren<HeroManager>();
    }
}
