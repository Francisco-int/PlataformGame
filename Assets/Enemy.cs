using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float speed;
    bool afterPlayer;
    public float activated;

    // Start is called before the first frame update
    void Start()
    {
        afterPlayer = false;
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(afterPlayer == true)
        {
            Vector3 follow = player.position - transform.position;
            transform.Translate(follow * Time.deltaTime * speed);
        }
        if(player.position.x < activated)
        {
            afterPlayer = true;
        }
        else
        {
            afterPlayer = false;
        }
    }

}
