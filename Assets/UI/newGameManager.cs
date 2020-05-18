using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Cinemachine;

public class newGameManager : MonoBehaviour
{

    public Camera cameraNew, cameradefault;
    void Start()
    {
        cameraNew.enabled = false;
    }
    

    void Update()
    {
        cameraNew.transform.position = cameradefault.transform.position;
    }

    public void newGameClick()
    {


        cameraNew.enabled = true;
        cameradefault.enabled = false;
        cameraNew.transform.eulerAngles += new Vector3(Mathf.LerpAngle(transform.rotation.x, transform.rotation.x*20f, 100f), Mathf.LerpAngle(transform.rotation.y, transform.rotation.y * 20f, 100f), Mathf.LerpAngle(transform.rotation.z, transform.rotation.z * 20f, 100f));
    }
}
