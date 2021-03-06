using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Static Fields
    public static GameManager Singleton { get; private set; } //The singleton used to access the Game Manager from static methods
    public static bool GameStarted { get; private set; } = true; //Determines whether the game is playing or not

    //Non-Static Fields
    [Header("Prefabs")]
    public GameObject LaserPrefab; //The Prefab for the Laser
    public GameObject ExplosionPrefab; //The Prefab for the Explosion
    [Space]
    [Space]
    [Header("Text Fields")]
    public Text LivesText; //A Reference to the text controlling the lives shown on screen
    public Text ScoreText; //A reference to the text controlling the score shown on screen 
    [Space]
    [Space]
    [Header("Lives")]
    public int Lives = 3; //The Amount of lives the player has
    [Space]
    [Space]
    [Header("Score")]
    public int Score = 0; //The current score of the game
    [Space]
    [Space]
    [Header("Lists")]
    public List<GameObject> SpawnPoints; //A list of possible spawnpoints for the enemies to spawn at
    public List<GameObject> Enemies; //A list of possible enemies to spawn into the game
    [Space]
    [Space]
    [Header("Spawning Paramters")]
    public float MinSpawnTime = 1f; //The minimum random spawn time
    public float MaxSpawnTime = 5f; //The maximum random spawn time
    public int EnemyCap = 3; //The maximum amount of enemies that can exist in the scene at once

    public float SpawnTimReductionRate = 0.01f; //How fast the spawn time gets reduced



    private float CurrentSpawnTime = 3f; //The current spawn time set before spawning in a new enemy
    private float spawnClock; //A clock to keep track of the current time

    private void Start()
    {
        //Reset the amount of lives based on the "Lives" variable
        LivesText.text = "Lives " + Lives;
        //Reset the score the the base amount
        ScoreText.text = "Score " + Score;
        //If the singleton is not already set
        if (Singleton == null)
        {
            //Set the singleton to this instance
            Singleton = this;
            //Preserve this object between scenes
            DontDestroyOnLoad(gameObject);
        }
        //If it is already set
        else
        {
            //Destroy this instance
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        //Increment the clock
        spawnClock += Time.deltaTime;
        //If the clock is greater than the current spawn time
        if (spawnClock > CurrentSpawnTime)
        {
            //Reset the spawn clock
            spawnClock = 0;
            //Generate a new spawn time
            CurrentSpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime) - (SpawnTimReductionRate * Time.time);
            //If the game is still running and if there are less enemies in the scene than the enemy cap limit
            if (GameStarted && Enemy.SpawnedEnemies.Count < EnemyCap)
            {
                //Spawn a new enemy
                GameObject.Instantiate(Enemies[Random.Range(0, Enemies.Count)], SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform.position, Quaternion.identity);
            }
        }
    }
    //Increases the score by a set amount
    public static void IncreaseScore(int amount)
    {
        //Increase the score
        Singleton.Score += amount;
        //Update the score text
        Singleton.ScoreText.text = "Score " + Singleton.Score;
    }

    //Called whenever the player gets hit or leaves the screen. Returns true if the game is over and false otherwise
    public static bool LooseALife()
    {
        //Destroy all the enemies
        Enemy.DestroyAllEnemies();
        //Destroy all the lasers
        Laser.DestroyAllLasers();
        //Reset the space ship
        SpaceShip.Reset();
        //Subtract a life
        Singleton.Lives--;

        //If the lives text is set in the inspector
        if (Singleton.LivesText != null)
        {
            //Update the lives text
            Singleton.LivesText.text = "Lives " + Singleton.Lives;
        }
        //If there are no lives left
        if (Singleton.Lives == 0)
        {
            //Stop the game
            GameStarted = false;
            //Disable the player, ending the game
            SpaceShip.Singleton.gameObject.SetActive(false);
            //Quit the application
            Application.Quit();
            return true;
        }
        return false;
    }
}
