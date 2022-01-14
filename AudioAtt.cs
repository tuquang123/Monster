using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAtt : MonoBehaviour
{
	public AudioSource att;
	public void AudioAttack()
	{
		att.Play();
	}
}
