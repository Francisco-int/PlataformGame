using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
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

        body.AddForce(new Vector3(horizontal, 0, vertical) * speed);

        if(Input.GetKeyDown(KeyCode.Escape) && jumpAble)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            jumpAble = false;
        }
        else
        {
            jumpAble = true;
        }
    }
}
