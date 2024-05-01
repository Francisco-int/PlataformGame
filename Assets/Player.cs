using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [InspectorName("Hola")]
    //[Range(0f, 10f)]
    public float speed;
    public float speedRotation;
    public float jumpForce;
    [Header("Variable")]
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
        if(transform.position.y < 0)
        {
            SceneManager.LoadScene(0);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal,0, vertical) * Time.deltaTime * speed);

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
        if (collision.gameObject.CompareTag("Bala"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
