using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHodle : MonoBehaviour
{
    public static PlayerHodle instance;
    public List<HeroCtrl> heroCtrls;
    private void Awake()
    {
        PlayerHodle.instance = this;
    }
    public virtual HeroCtrl GetHero(string name)
    {
        return this.heroCtrls[0];
    }
}
