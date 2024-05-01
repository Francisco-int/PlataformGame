using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{
    
    public GameObject bala;
    public float shotCoolDown;
    public Transform shotPoint;
    bool shot;
    public float balaForce;
    public float activated;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        InvokeRepeating("Shot", shotCoolDown, shotCoolDown);
    }

    void Update()
    {
        if (player.position.x < activated)
        {
            shot = true;
        }
    }
    void Shot()
    {
        if (shot)
        {
            GameObject newBala = Instantiate(bala, shotPoint);
            Rigidbody rb = newBala.GetComponent<Rigidbody>();
            rb.AddForce(newBala.transform.forward * balaForce, ForceMode.Impulse);
            Debug.Log("Shot");
        }
    }
}
