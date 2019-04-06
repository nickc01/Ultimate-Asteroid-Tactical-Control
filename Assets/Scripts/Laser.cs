using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Static Fields
    private static List<GameObject> SpawnedLasers = new List<GameObject>(); //A list of all the lasers currently in the scene

    //Non-Static Fields
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
        //Add this laser to the list of spawned lasers
        SpawnedLasers.Add(gameObject);
    }

    private void Update()
    {
        //Move the Laser
        transform.position += Direction * Speed * Time.deltaTime;
    }

    //Called when the laser is destroyed
    private void OnDestroy()
    {
        //Remove this laser from the list of spawned lasers
        SpawnedLasers.Remove(gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //If the collider is the bounds
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bounds"))
        {
            //Destroy the object
            Destroy(gameObject);
        }
    }

    //Destroys all of the lasers in the scene
    public static void DestroyAllLasers()
    {
        //Loop through each laser in the list
        foreach (var laser in SpawnedLasers)
        {
            //Destroy the laser
            Destroy(laser);
        }
        //Clear the spawned lasers list
        SpawnedLasers.Clear();
    }
}
