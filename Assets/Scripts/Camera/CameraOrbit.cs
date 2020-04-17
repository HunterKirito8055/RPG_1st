using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : Orbit
{
    public float camera_Length = -10f;
    public float camera_Length_zoom = -5f;

    public Vector3 Target_Offset = new Vector3(0, 2f, 0);
    public Vector3 camera_Position_zoom = new Vector3(-0.5f, 0f, 0f);

    public Vector2 Orbit_Speed = new Vector2(0.01f, 0.01f);
    public Vector2 Orbit_offset = new Vector2(0, -0.8f);
    public Vector2 Angle_offset = new Vector2(0, -0.25f);

    private float Zoom_value;
    private Vector3 Camera_Temp_position;
    private Vector3 Camera_position;

    private Transform PLayer;
    private Camera maincamera;

    private void Start()
    {
        PLayer = GameObject.FindGameObjectWithTag("Player").transform;
        Spherical_vector_data.Length = camera_Length;
        Spherical_vector_data.Azimuth = Angle_offset.x;
        Spherical_vector_data.Zenith = Angle_offset.y;
        maincamera = Camera.main;
        Camera_Temp_position = maincamera.transform.localPosition;
        Camera_position = Camera_Temp_position;

        MouseLock.MouseLocked = true;
         
    }
    private void Update()
    {
        HandleCamera();
        Handle_MouseLock();
    }

    void HandleCamera()
    {
        if (MouseLock.MouseLocked)
        {
            Spherical_vector_data.Azimuth += Input.GetAxis("Mouse X") * Orbit_Speed.x;
            Spherical_vector_data.Zenith += Input.GetAxis("Mouse Y") * Orbit_Speed.y;
        }

        Spherical_vector_data.Zenith = Mathf.Clamp(Spherical_vector_data.Zenith + Orbit_offset.x, Orbit_offset.y, 0f);
        float distance_To_Object = Zoom_value;
        float Distance = Mathf.Clamp(Zoom_value, distance_To_Object, -distance_To_Object);

        Spherical_vector_data.Length += (Distance - Spherical_vector_data.Length); //how far will be the camera from player

        Vector3 lookat = Target_Offset; //variable to follow our player
        lookat += PLayer.position;
        base.Update();
        transform.position += lookat;
        transform.LookAt(lookat);

        if(Zoom_value == camera_Length_zoom)
        {
            Quaternion Targetrotation = transform.rotation;
            Targetrotation.x = 0f;
            Targetrotation.y = 0f;
            PLayer.rotation = Targetrotation;
        }
        Camera_position = Camera_Temp_position;
        Zoom_value = camera_Length;

     }
    void Handle_MouseLock()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (MouseLock.MouseLocked)
            {
                MouseLock.MouseLocked = false;
            }
            else
            {
                MouseLock.MouseLocked = true;
            }
        }
    }

} 
