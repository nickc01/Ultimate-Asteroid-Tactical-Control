using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //Static Fields
    public static List<Enemy> SpawnedEnemies = new List<Enemy>(); //A list of all the enemies in the scene

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Add this enemy to the list of spawned enemies
        SpawnedEnemies.Add(this);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    //Gets the score used when the enemy dies
    public abstract int GetScore();

    //Called when the enemy is destroyed
    public void OnDestroy()
    {
        //Remove this enemy to the list of spawned enemies
        SpawnedEnemies.Remove(this);
    }

    public void OnBecameInvisible()
    {
        //Destroy the object
        DestroyEnemy(false);
    }

    //When the enemy comes in contact with something
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the enemy has come in contact with a laser
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            //Destroy the enemy
            DestroyEnemy(true);
            //Increase the Score by utilizing GetScore()
            GameManager.IncreaseScore(GetScore());
        }
    }

    //Destroys the Enemy
    public void DestroyEnemy(bool Explode)
    {
        //If explode is set to true
        if (Explode)
        {
            //Trigger an explosion
            Explosion.PlayExplosion(transform.position);
        }
        //Destroy the gameobject
        Destroy(gameObject);
    }
    //Destroys all enemies in the scene
    public static void DestroyAllEnemies()
    {
        //Loop over all the spawned enemies
        foreach (var enemy in SpawnedEnemies)
        {
            //Destroy each enemy
            Destroy(enemy.gameObject);
        }
        //Clear the list
        SpawnedEnemies.Clear();
    }
}
