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
        shotCoolDown = Random.Range(0, 2);
        InvokeRepeating("Shot", shotCoolDown, shotCoolDown);
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
        if (shot)
        {
            for (int i = 0; i < Random.Range(5, 15); i++)
            {
                float time = Time.deltaTime;
                if (time > Random.Range(0, 2))
                {
                    shotPoint.position = new Vector3(Random.Range(-32.58f, -7.5f), 3.1f, Random.Range(-5.6f, 8.8f));
                    Instantiate(bala, shotPoint);
                    time = 0;
                }
            }
        }
    }
    void Shot()
    {
        
    }
}
