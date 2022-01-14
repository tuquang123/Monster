using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroProfile : MonoBehaviour
{
    [SerializeField ]protected string heroClass = "hero";
    public string HeroClass()
    {
        return heroClass;
    }
}
