using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    //Static Fields
    public static SpaceShip Singleton { get; private set; } //A singleton for accessing the player from static methods

    //Non-Static Fields
    [Header("Ship")]
    public float RotationSpeed = 90f; //How fast the ship rotates per second
    public float Acceleration = 1f; //How fast the ship accelerates
    [Space]
    [Header("Lasers")]
    public float LaserSpeed = 5f; //Determines how fast the lasers travel per second
    public float LaserLifetime = 5; //Determines how long the laser lives in seconds
    public float LaserFireRate = 5f; //Determines how many lasers will fire per second

    private Vector3 velocityVector; //Stores the current speed of the ship
    private float FireClock = 0f; //A clock for keeping track of the fire rate

    void Start()
    {
        //If the singleton is not already set
        if (Singleton == null)
        {
            //Set the singleton to this instance
            Singleton = this;
        }
        //If it is already set
        else
        {
            //Destroy this instance
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //If the Left Arrow or A keys are pressed
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Turn the ship left
            transform.Rotate(new Vector3(0,0,Time.deltaTime * RotationSpeed));
        }
        //If the Right Arrow or D keys are pressed
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Turn the ship right
            transform.Rotate(new Vector3(0, 0, -Time.deltaTime * RotationSpeed));
        }
        //If the Up Arrow or W keys are pressed
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //Increase the Speed of the Ship based on the direction that it is facing
            velocityVector += new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad) * Acceleration * Time.deltaTime,Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * Acceleration * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //Decrease the Speed of the Ship based on the direction that it is facing
            velocityVector -= new Vector3(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad) * Acceleration * Time.deltaTime, Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad) * Acceleration * Time.deltaTime);
        }
        //Move the ship
        transform.position += velocityVector;



        //If the firing clock is less than 1
        if (FireClock < 1f)
        {
            //Increase the FireClock based on the fire rate
            FireClock += LaserFireRate * Time.deltaTime;
        }
        //If the firing clock is greater than or equal to 1 and if the space bar is pressed
        if (FireClock >= 1f && Input.GetKey(KeyCode.Space))
        {
            //Spawn a laser
            var laser = GameObject.Instantiate(GameManager.Singleton.LaserPrefab, transform.position, transform.rotation).GetComponent<Laser>();
            //Set the laser's speed
            laser.Speed = LaserSpeed;
            //Set the laser's lifetime
            laser.Lifetime = LaserLifetime;
            //Reset the Fire Clock
            FireClock = 0f;
        }
        //If the ship is outside of the camera view
        if (!CameraHelper.Bounds.Contains(transform.position))
        {
            //The player has died and lost a life
            GameManager.LooseALife();
        }
    }

    //Triggered when an enemy hits the player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //The player has died and lost a life
        GameManager.LooseALife();
    }
    //Resets the space ship's position and velocity
    public static void Reset()
    {
        //Reset the ship's position
        Singleton.transform.position = Vector3.zero;
        Singleton.velocityVector = Vector3.zero;
    }
}
