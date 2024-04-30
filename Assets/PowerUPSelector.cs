using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType {none, Push, Velocity, SuperJump}

public class PowerUPSelector : MonoBehaviour
{
    public PowerUpType powerUpType;
    public ParticleSystem powerParticle;

    // Start is called before the first frame update
    void Start()
    {
        powerParticle.Stop();//
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            powerParticle.Play();
        }
    }
}
