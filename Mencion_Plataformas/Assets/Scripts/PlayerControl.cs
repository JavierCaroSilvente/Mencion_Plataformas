using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedPlayer = 8;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Movement();
        DirDetect();
    }

    private void Movement()
    {
        rb.velocity = new Vector2(speedPlayer * Input.GetAxis("Horizontal"), rb.velocity.y); // <--------------------- con este no vibra al colisionar con las paredes y objetos.
    }

    private void DirDetect()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            //cambiar de direccion el personaje derecha
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //cambiar  de direccion personaje izquierda
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
