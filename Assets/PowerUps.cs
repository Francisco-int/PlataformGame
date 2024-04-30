using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [Tooltip("")] public PowerUpType currentPowerUp = PowerUpType.none;
     public Player player;
    public float pushForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E) &&  currentPowerUp == PowerUpType.Velocity)
        {
            Velocity();
        }
        else
        {
            player.speed = 5;
        }
        if (Input.GetKey(KeyCode.E) && currentPowerUp == PowerUpType.SuperJump)
        {
            SuperJump();
        }
        else
        {
            player.jumpForce = 5;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player") && currentPowerUp == PowerUpType.Push)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAway = (collision.gameObject.transform.position - transform.position);

            rb.AddForce(pushAway * pushForce, ForceMode.Impulse); 
        }
    }
    void Velocity()
    {
        player.speed = 10;
    }
     void SuperJump()
    {
        player.jumpForce = 8;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            currentPowerUp = other.gameObject.GetComponent<PowerUPSelector>().powerUpType;
        }
    }
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(5);
        currentPowerUp = PowerUpType.none;
    }
}
