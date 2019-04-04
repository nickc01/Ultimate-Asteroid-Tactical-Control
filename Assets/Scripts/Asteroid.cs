using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Asteroid : Enemy
{
    public float AsteroidSpeed = 7f; //How fast the asteroid will move
    Vector3 Direction; //The direction the asteroid will be heading towards
    protected override void Start()
    {
        //Run the base method
        base.Start();
        //Get the player's position
        Vector3 playerPosition = SpaceShip.Singleton.transform.position;
        //Calculate the direction towards the player's current position
        Direction = (playerPosition - transform.position).normalized;
    }
    protected override void Update()
    {
        //Run the base method
        base.Update();
        //Move in the set direction
        transform.position += Direction * Time.deltaTime * AsteroidSpeed;
    }
}
