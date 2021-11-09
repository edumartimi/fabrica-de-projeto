using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minotauro : MonoBehaviour
{
    public float speed;
    private Vector3 movimento;
    private float mexendox;
    private float mexendoy;
    public Transform target;
    public Transform lastTarget;
    private float tmpmovimento;
    bool girou;



    void Start() 
    {
        girou = false;
    }

    void Update()
    {
        mexendox = transform.position.x;
        mexendoy = transform.position.y;
        
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
        }

        if (transform.position.x != mexendox && !girou) 
        {
            transform.Rotate(0, 0, 90);
            girou = true;
        }
        if (transform.position.y != mexendoy && girou)
        {
            transform.Rotate(0, 0, 90);
            girou = false;
        }

    }
}
