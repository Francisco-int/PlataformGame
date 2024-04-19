using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float speedRotation;
    public float jumpForce;
    [SerializeField] bool jumpAble;
    [SerializeField] Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        body.AddForce(transform.right * horizontal * speed + transform.forward * vertical * speed);

        if(Input.GetKeyDown(KeyCode.Space) && jumpAble)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpAble = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            jumpAble = true;
        }
    }
}
