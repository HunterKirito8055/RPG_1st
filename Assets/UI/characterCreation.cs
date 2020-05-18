using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class characterCreation : MonoBehaviour
{
    //panels
  

    PostProcessVolume menuGraphics;
    DepthOfField dof;
    bool timber = false;
    void Start()
    {
        menuGraphics = GameObject.Find("Main Camera").GetComponent<PostProcessVolume>();
        
        menuGraphics.profile.TryGetSettings(out dof);


    }

    public void characterCreate()
    {
        timber = true;
        
    }
    
    void Update()
    {
        //if(timber == true)
       //dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 10.0f * Time.deltaTime);
    }
}
