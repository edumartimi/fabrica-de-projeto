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
    public float velocidade_corrida;
    public Animator animador;
    private float andarx;
    private float andary;
    bool andando;


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
                andarx = Input.GetAxis("Horizontal") * velocidade;
                andary = Input.GetAxis("Vertical") * velocidade;
                Vector2 andar = new Vector2(andarx,andary);
                fisica.velocity = andar * Time.deltaTime;
            }
            else 
            {
                Vector2 parado = new Vector2(0, 0);
                fisica.velocity = parado;
            }
        }
        if (correr)
        {
            Vector2 andar = new Vector2(Input.GetAxis("Horizontal") * velocidade* velocidade_corrida, Input.GetAxis("Vertical") * velocidade*velocidade_corrida);
            fisica.velocity = andar;
        }


    }

    private void Update() {
        if (fisica.velocity.y != 0 || fisica.velocity.x != 0)
        {
            andando = true;
        }
        else 
        {
            andando = false;
        }
        animador.SetBool("andando", andando);



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