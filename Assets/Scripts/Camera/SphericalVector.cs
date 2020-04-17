using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SphericalVector 
{
    public float Length;
    public float Azimuth;
    public float Zenith;

    public SphericalVector(float azimuth,float zenith,float length)
    {
        Azimuth = azimuth;
        Zenith = zenith;
        Length = length;
    }

    //using spherical coordinate system
    public Vector3 Direction
    {
        get
        {
            Vector3 dir;
           
            float Vertical_angle = Zenith * Mathf.PI / 2f;
            float Horizontal_angle = Azimuth * Mathf.PI;

            
            float h = Mathf.Cos(Vertical_angle);

            dir.y = Mathf.Sin(Vertical_angle); //Elevation Angle

            //Polar angle:Rotation around Zenith axis
            dir.x = h * Mathf.Sin(Horizontal_angle); 
            dir.z = h * Mathf.Cos(Horizontal_angle); 

            return dir;
        }
    }
    public Vector3 Position
    {
        get
        {
            return Length * Direction;
        }
    }
}

