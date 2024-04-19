using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCamera : MonoBehaviour
{
    public float speedRotate;
    float rotacionX;

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * speedRotate * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * speedRotate * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
