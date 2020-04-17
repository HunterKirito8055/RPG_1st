using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float Zoom_Sensitivity = 15f;
    public float Zoom_Speed = 20f;
    public float Zoom_Min = 30f;
    public float Zoom_Max = 70f;

    private float z;
    private Camera maincamera;
    void Start()
    {
        maincamera = Camera.main;
        z = maincamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        z -= Input.GetAxis("Mouse ScrollWheel") * Zoom_Sensitivity;
        z = Mathf.Clamp(z,Zoom_Min,Zoom_Max);
    }
    private void LateUpdate()
    {
        maincamera.fieldOfView = Mathf.Lerp(maincamera.fieldOfView, z, Time.deltaTime * Zoom_Speed);
    }
}
