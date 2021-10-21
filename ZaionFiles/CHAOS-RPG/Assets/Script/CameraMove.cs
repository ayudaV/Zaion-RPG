using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CameraMove : MonoBehaviour
{
    [Header("Camera")]
    public float speed = 10;

    [Header("Zoom")]
    public float minZoom = 5.0f;
    public float maxZoom = 250.0f;

    float zoom;

    void Update()
    {
        Move();
        Zoom();

        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        GetComponent<Camera>().orthographicSize = zoom; 
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Zoom()
    {
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            zoom -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            zoom += speed * Time.deltaTime;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            zoom -= speed * Time.deltaTime * 10f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoom += speed * Time.deltaTime * 10f;
        }
    }
}