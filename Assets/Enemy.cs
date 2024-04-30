using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public float speed;
    public Collider trigger;
    bool afterPlayer;

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
            Vector3 follow = (player.position - transform.position);
            transform.position = (follow * Time.deltaTime * speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            afterPlayer = true;
        }
    }
}
