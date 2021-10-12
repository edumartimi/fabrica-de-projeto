using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private Rigidbody2D fisica;
    public int velocidade;
    private bool correr;
    private float tmpcorrida;
    public float estamina;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bau")
        {

            Destroy(collision.gameObject);
        }
    }




    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }
        
    private void FixedUpdate() 
    {
        /*
        Vector3 diferrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diferrence.Normalize();

        float rotationZ = Mathf.Atan2(diferrence.y, diferrence.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f, rotationZ);
        */

        if (!correr)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Vector2 andar = new Vector2(Input.GetAxis("Horizontal") * velocidade, Input.GetAxis("Vertical") * velocidade);
                fisica.velocity = andar;
            }
            else 
            {
                Vector2 parado = new Vector2(0, 0);
                fisica.velocity = parado;
            }
        }
        if (correr)
        {
            Vector2 andar = new Vector2(Input.GetAxis("Horizontal") * velocidade*2, Input.GetAxis("Vertical") * velocidade*2);
            fisica.velocity = andar;
        }


    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
                correr = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            correr = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            fisica.rotation = 180;
        }
        
        
        if(Input.GetKey(KeyCode.D))
        {
            fisica.rotation = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            fisica.rotation = 90;
        }


        if (Input.GetKey(KeyCode.S))
        {
            fisica.rotation = 270;
        }

    }
}