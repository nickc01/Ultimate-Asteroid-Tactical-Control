using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float MinSpeed = 1f; //The minimum speed of the backgrounds
    public float MaxSpeed = 6f; //The maximum speed of the backgrounds
    public float Direction = 0f; //The direction the backgrounds will travel in degrees
    // Start is called before the first frame update
    private List<ParallaxBackground> Backgrounds; //A list of the current backgrounds
    void Start()
    {
        //Get a list of all the backgrounds inside of this object
        Backgrounds = GetComponentsInChildren<ParallaxBackground>().ToList();

        //Loop over all the backgrounds in the list
        for (int i = 0; i < Backgrounds.Count; i++)
        {
            //Get the current background at the index
            var background = Backgrounds[i];

            //Set the background's speed depending on it's order in the list
            background.Speed = Mathf.Lerp(MinSpeed, MaxSpeed, i / (float)Backgrounds.Count);
            //Set the background's direction
            background.Direction = new Vector3(Mathf.Cos(Direction * Mathf.Deg2Rad),Mathf.Sin(Direction * Mathf.Deg2Rad));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
