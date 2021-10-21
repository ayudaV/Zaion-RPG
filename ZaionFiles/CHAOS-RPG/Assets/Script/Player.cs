using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    void Move()
    {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
            transform.position += movement * Time.deltaTime * speed;
            /*
            if(Input.GetAxis("Horizontal") > 0f)
                transform.eulerAngles = new Vector3(0f,0f,0f);

            if(Input.GetAxis("Horizontal") < 0f)
                transform.eulerAngles = new Vector3(0f,180f,0f);
                */
    }
}
