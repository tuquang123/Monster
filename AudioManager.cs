using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public int volume = 0;
    private void Awake()
    {
        AudioListener.volume = volume;
    }
}
