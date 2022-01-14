using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    static public UiManager instace;
    public int gold = 0;
    public Text textGold;

    void Start()
    {
        instace = this;
        textGold.text = gold.ToString();
    }
    public void ResetGold()
    {
        gold = 0;
        textGold.text = gold.ToString();
    }
}
