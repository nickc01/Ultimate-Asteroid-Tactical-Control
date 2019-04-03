using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Static Fields
    private static List<Enemy> SpawnedEnemies = new List<Enemy>(); //A list of all the enemies in the scene

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
    //Called when the enemy is destroyed
    private void OnDestroy()
    {
        //Remove this enemy to the list of spawned enemies
        SpawnedEnemies.Remove(this);
    }

    //Destroys the Enemy
    public void DestroyEnemy()
    {
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
