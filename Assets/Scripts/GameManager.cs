using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Static Fields
    public static GameManager Singleton { get; private set; } //The singleton used to access the Game Manager from static methods

    //Non-Static Fields
    public GameObject LaserPrefab; //The Prefab for the Laser
    public Text LivesText; //A Reference to the text controling the lives shown on screen
    [Space]
    [Space]
    public int Lives = 3; //The Amount of lives the player has

    private void Start()
    {
        //Reset the amount of lives based on the "Lives" variable
        LivesText.text = "Lives:" + Lives;
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

    //Called whenever the player gets hit or leaves the screen
    public static void PlayerDeath()
    {
        //Destroy all the enemies
        Enemy.DestroyAllEnemies();
        //Destroy all the lasers
        Laser.DestroyAllLasers();
        //Reset the space ship
        SpaceShip.Reset();
        //Subtract a life
        Singleton.Lives--;
        //Update the lives text
        Singleton.LivesText.text = "Lives:" + Singleton.Lives;
        //If there are no lives left
        if (Singleton.Lives == 0)
        {
            //Disable the player, ending the game
            SpaceShip.Singleton.gameObject.SetActive(false);
        }
    }
}
