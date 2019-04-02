using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float RotationSpeed = 90f;
    public float Speed = 1f;

    private Vector3 velocity;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Turn the ship left
            transform.Rotate(new Vector3(0,0,Time.deltaTime * RotationSpeed));
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Turn the ship right
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * RotationSpeed));
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //Turn the ship left
            velocity += new Vector3(Mathf.Cos(transform.rotation.z) * Speed * Time.deltaTime,Mathf.Sin(transform.rotation.z) * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            velocity -= new Vector3(Mathf.Cos(transform.rotation.z) * Speed * Time.deltaTime, Mathf.Sin(transform.rotation.z) * Speed * Time.deltaTime);
            //Turn the ship right
            //transform.Rotate(new Vector3(0, 0, -Time.deltaTime * RotationSpeed));
        }
        transform.position += velocity;
    }
}
