using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 1;
    public List<Renderer> Renderers;
    public GameObject Trail;
    public GameObject Impact;
    public Rigidbody Rigidbody;
    public void Start()
    { 
         Destroy(gameObject, 3);
    }

    public void Update()
    {
        if (Rigidbody != null && Rigidbody.useGravity)
        {
            transform.right = Rigidbody.velocity.normalized;
        }
    }
  
   
    public void OnTriggerEnter(Collider other)
    {
        Bang(other.gameObject);
        Enemy2 enemy = other.GetComponent<Enemy2>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Boss enemy2 = other.GetComponent<Boss>();
        if (enemy2 != null)
        {
            enemy2.TakeDamage(damage);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        Bang(other.gameObject);
    }
   
    private void Bang(GameObject other)
    {
        ReplaceImpactSound(other);
        Impact.SetActive(true);
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<Collider>());
        foreach (var ps in Trail.GetComponentsInChildren<ParticleSystem>())
        {
            ps.Stop();
        }

        foreach (var tr in Trail.GetComponentsInChildren<TrailRenderer>())
        {
            tr.enabled = false;
        }
    }

    private void ReplaceImpactSound(GameObject other)
    {
        var sound = other.GetComponent<AudioSource>();

        if (sound != null && sound.clip != null)
        {
            Impact.GetComponent<AudioSource>().clip = sound.clip;
        }
    }
}

