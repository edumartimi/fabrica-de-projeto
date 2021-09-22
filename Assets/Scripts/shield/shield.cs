using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 diferrence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diferrence.Normalize();

        float rotationZ = Mathf.Atan2(diferrence.y, diferrence.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
