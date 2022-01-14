using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public List<HeroCtrl> herros = new List<HeroCtrl>();

    private void Reset()
    {
        this.loadComponents();
    }

    private void loadComponents()
    {
        this.LoadHeros();
    }

    private void LoadHeros()
    {
        if (this.herros.Count > 0) return;
        foreach (HeroCtrl heroCtrl in transform.GetComponentsInChildren <HeroCtrl>())
        {
            this.herros.Add(heroCtrl);
        }
    }
    public virtual GameObject GetHero()
    {
        GameObject heroObj = this.herros[0].gameObject;
        GameObject hero = Instantiate(heroObj, new Vector3(0, 0, 0), transform.rotation);
        return hero;
    }
}
