using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotter : MonoBehaviour
{

    public GameObject bala;
    public float shotCoolDown;
    public Vector3 shotPoint;
    bool shot;
    public float balaForce;
    public float activated;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        
        InvokeRepeating("Shot", 0, shotCoolDown);
    }

    void Update()
    {



        if (player.position.x < activated)
        {
            shot = true;
        }
        else
        {
            shot = false;
        }

        if (player.position.x < -32.58)
        {
            shot = false;
        }


    }

    void Shot()
    {
        if (shot)
        {

            for (int i = 0; i < Random.Range(60, 70); i++)
            {

                shotPoint = new Vector3(Random.Range(-55.2f, 23.02f), 11f, Random.Range(-7.05f, 8.8f));
                Instantiate(bala, shotPoint, bala.transform.rotation);

            }
            Debug.Log(shotCoolDown);
        }

    }
}

