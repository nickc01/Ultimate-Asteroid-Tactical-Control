using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Static Fields
    public static GameManager Singleton { get; private set; } //The singleton used to access the Game Manager from static methods

    //Non-Static Fields
    public GameObject LaserPrefab; //The Prefab for the Laser

    private void Start()
    {
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
}
