using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class characterCreation : MonoBehaviour
{
    //panels
    public List<GameObject> menuCharacters = new List<GameObject>();
    public GameObject characterSpawn;
    public List<GameObject> characters = new List<GameObject>();
    int[] index;
    public Camera[] cams;
    int i;    
    bool timber = false;
   
    public void characterCreate()
    {


        foreach (GameObject obs in menuCharacters)
            obs.SetActive(false);

        foreach (GameObject obj in characters)
            obj.SetActive(false);

        characters[0].SetActive(true);

        cams[1].gameObject.SetActive(true);
        cams[1].enabled = true;
        cams[0].enabled = false;
        

        timber = true;
         
    }
    
    public void buttonClick()
    {
        characters[i].SetActive(false);
         if (i == 0) { i = 1; } else i = 0;
        characters[i].SetActive(true);

    }

    public void buttonBack()
    {
        foreach (GameObject obs in menuCharacters)
            obs.SetActive(true);

        foreach (GameObject obj in characters)
            obj.SetActive(false);


        cams[0].enabled = true;
        cams[1].enabled = false;
        cams[1].gameObject.SetActive(false);

    }

}
