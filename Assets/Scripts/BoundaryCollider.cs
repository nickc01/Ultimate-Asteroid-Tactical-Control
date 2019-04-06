using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 Offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Camera Bounds
        var bounds = CameraHelper.Bounds;
        //Set the size of the object to the bounds
        transform.localScale = new Vector3(bounds.width + (Offset.x * 2), bounds.height + (Offset.y * 2));
    }
}
