using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotauro : MonoBehaviour
{
    public float speed;
    private Vector3 movimento;
    private float mexendox;
    private float mexendoxatra;
    private float mexendoy;
    private float mexendoyatra;
    public Transform target;
    private float tmpmovimento;
    public SpriteRenderer minoart;
    private float tempovar;
    private float eixoy;
    private float eixox;
    public bool girando;



    void Start() 
    {
    }

    void Update()
    {

        tmpmovimento = tmpmovimento + Time.deltaTime;
            
        if (transform.position == target.position)
        {
              Transform[] points = target.GetComponent<waypoints>().nearbyPoints;
              int rand = Random.Range(0, points.Length);
              target = points[rand];
        }
        else 
        {
                Vector3 movimento = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                transform.position = movimento;
                mexendoy = transform.position.y;
                mexendox = transform.position.x;
        }

        /* if (transform.position.x != mexendox && !girou)
         {

         }*/


        tempovar = tempovar + Time.deltaTime;

        if (tempovar > 0.1) 
        {
            mexendoyatra = mexendoy;
            mexendoxatra = mexendox;
            tempovar = 0;
        }

        eixoy = mexendoy - mexendoyatra;
        eixox = mexendox - mexendoxatra;

        
        if (eixoy > 0)
        {
            if (transform.rotation.z != -0.7071068)
            {
                if (transform.rotation.z > -0.7071068)
                {
                    transform.Rotate(0, 0, 10);
                }
                if (transform.rotation.z < -0.7071068)
                {
                    transform.Rotate(0, 0, -10);
                }
            }
        }


        else if (eixoy < 0) 
        {
            if (transform.rotation.z != 0.7071068)
            {
                if (transform.rotation.z > 0.7071068)
                {
                    transform.Rotate(0, 0, 10);
                }
                if (transform.rotation.z < 0.7071068)
                {
                    transform.Rotate(0, 0, -10);
                }
            }
        }



        if (eixox > 0)
        { 
            if (transform.rotation.z != 0) 
            {
                if (transform.rotation.z > 0)
                {
                    transform.Rotate(0, 0, 10);
                }
                if(transform.rotation.z < 0) {
                    transform.Rotate(0, 0, -10);
                }
            }
        }


      if (eixox < 0)
        {
            if (transform.rotation.z != -1)
            {
                if (transform.rotation.z > -1)
                {
                    transform.Rotate(0, 0, 10);
                }
                if (transform.rotation.z < -1)
                {
                    transform.Rotate(0, 0, -10);
                }
            }
        }
    }
}
