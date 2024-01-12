using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        float zDirection = Input.GetAxis("Horizontal");
        float xDirection = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(-xDirection, 0.0f, zDirection);
        transform.position += move* speed;
    }
}
