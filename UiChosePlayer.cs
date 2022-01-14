using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiChosePlayer : MonoBehaviour
{
    public void ChoosePlayer()
    {
        string heroClass = transform.name.Replace("Bt","");
        PlayerManager.instance.ChoosePlayer(heroClass);
    }
}
