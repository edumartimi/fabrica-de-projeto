using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private Rigidbody2D fisica;
    public int velocidade;
    public Transform posicaotiro;
    public GameObject bullet;
    public int bulletForce;
    public float tempobalas;
    public float tps;
    //teste

    private void Start()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        Vector3 diferrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diferrence.Normalize();

        float rotationZ = Mathf.Atan2(diferrence.y, diferrence.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f,0f, rotationZ);

        Vector2 andar = new Vector2(Input.GetAxis("Horizontal") * velocidade,Input.GetAxis("Vertical") * velocidade);
        fisica.velocity = andar;

        tempobalas = tempobalas + Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && tempobalas > 1 / tps)
        {
            GameObject tmpbullet = Instantiate(bullet, posicaotiro.position, Quaternion.identity);
            tmpbullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce);
            tempobalas = 0;
        }   
    }
}