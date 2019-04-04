using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyShip : Enemy
{
    public bool InstantRotation = false; //If true, rotates instantly to point towards the player. If false, gradually turns to point towards the player
    public float RotationSpeed = 45f; //How fast the ship rotates per second. Only used if Instant Rotation is false
    public float Speed = 3f; //How fast the ship moves per second

    private Vector3 Direction; //The current direction the ship is facing in

    protected override void Start()
    {
        //Call the base function
        base.Start();
        //Get the player's position
        Vector3 playerPosition = SpaceShip.Singleton.transform.position;
        //Calculate the direction towards the player's current position
        Direction = (playerPosition - transform.position).normalized;
    }

    protected override void Update()
    {
        //Call the base function
        base.Update();
        Direction = Vector3.RotateTowards(Direction, SpaceShip.Singleton.transform.position, RotationSpeed * Mathf.Deg2Rad * Time.deltaTime, 0.0f);
        //Move in the direction
        transform.position += Direction * Speed * Time.deltaTime;
    }
}
