using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PowerUps : MonoBehaviour
{
    [Tooltip("")] public PowerUpType currentPowerUp = PowerUpType.none;
    public Player player;
    public float pushForce;
    public float speedPower;
    public float escalaTiempo;
    public GameObject jugador;
    public float estabilisador;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && currentPowerUp == PowerUpType.Velocity)
        {
            Velocity();
        }
        else
        {
            Time.timeScale = 1;
            player.speed = 5.15f;
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
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Push)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 pushAway = (collision.gameObject.transform.position - transform.position);

            rb.AddForce(pushAway * pushForce, ForceMode.Impulse); 
        }
    }
    void Velocity()
    {
        Time.timeScale = escalaTiempo;
        player.speed = estabilisador;
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
}
