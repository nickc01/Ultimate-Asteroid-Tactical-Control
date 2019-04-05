using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [HideInInspector]
    public float Speed = 5f; //The Speed of the background. Configured in the ParallaxController
    [HideInInspector]
    public Vector3 Direction; //The Direction the background is traveling in. Configured in the ParallaxController
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move in the set direction
        transform.position += Direction * Speed * Time.deltaTime;
        CheckPositions();
    }

    //Checkes whether the background has went past it's looping boundaries
    void CheckPositions()
    {
        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 10f)
        {
            transform.position = new Vector3(transform.position.x - 20f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 20f, transform.position.z);
        }
        if (transform.position.y > 10f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 20f, transform.position.z);
        }
    }
}
