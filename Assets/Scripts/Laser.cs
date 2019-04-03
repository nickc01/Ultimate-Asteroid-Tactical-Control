using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float Speed { get; set; } = 1f; //How fast the laser is traveling. This value is changed in the Spaceship Script
    public float Lifetime { get; set; } = 1f; //Determines how long the laser lives. This value is changed in the Spaceship Script
    private Vector3 Direction; //The Direction the Laser is traveling in

    // Start is called before the first frame update
    void Start()
    {
        //Destroy this object after a set amount of time determined by the "Lifetime" variable
        Destroy(gameObject, Lifetime);
        //Calculate the laser's direction based on its current rotation
        Direction = new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad),Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
    }

    private void Update()
    {
        //Move the Laser
        transform.position += Direction * Speed * Time.deltaTime;
    }

    //Triggered when it comes in contact with an enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
