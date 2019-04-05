using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraHelper
{
    public static Rect Bounds //Returns the boundaries of the camera
    {
        get
        {
            //If the Current Camera is not set
            if (CurrentCamera == null)
            {
                //Set it to the currently used camera in the scene
                CurrentCamera = Camera.main;
            }
            var ortho = CurrentCamera.orthographicSize; //The orthographic size of the camera
            var height = ortho * 2; //The height of the camera
            var width = CurrentCamera.aspect * height; //The width of the camera
            var position = CurrentCamera.transform.position; //The current position of the camera
            return new Rect(position.x - (width / 2) - Offset.x, position.y - (height / 2) - Offset.y, width + (Offset.x * 2), height + (Offset.y * 2)); //The final bounds rect calculated
        }
    }
    public static Vector2 Offset = new Vector2(0.5f, 0.5f); //An offset used to extend the boundaries by a set amount
    private static Camera CurrentCamera; //The current camera being used in the scene
}
