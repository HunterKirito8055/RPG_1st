using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class menuAnimation : MonoBehaviour
{
    public List<GameObject> panels = new List<GameObject>();                                //  0   Main
    private int i;                                                                          //  1   Play
                                                                                            //  2   Options
    PostProcessVolume menuGraphics;                                                         //  3   create
    DepthOfField dof;

    bool panFar = true;
    bool fade = true;
    void Start()
    {
        menuGraphics = GameObject.Find("Main Camera").GetComponent<PostProcessVolume>();                
        menuGraphics.profile.TryGetSettings(out dof);
        panels[0].SetActive(true);
    }                                                                                                   

    public void Update()
    {
        if (panFar == true)
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f * Time.deltaTime);
        else
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f * Time.deltaTime);

        if (fade == true)
        panels[i].GetComponentInChildren<Image>().canvasRenderer.SetAlpha(0.0f);
        else
        panels[i].GetComponentInChildren<Image>().CrossFadeAlpha(1, 5, false);

        panels[i].SetActive(true);
    }

    public void panelMain() { panels[i].SetActive(false); i = 0; panFar = false; fade = false; }
    public void panelPlay() { panels[i].SetActive(false);    i = 1;    panFar = false; fade=false;}
    public void panelOptions() { panels[i].SetActive(false);  i = 2; panFar = false;   fade =false; }
    public void panelCreate() { panels[i].SetActive(false); i = 3; panFar = false; fade = false; }


    public void univBack() {

        panels[i].SetActive(false);
        panFar = true;
        i = 0;
        panels[i].SetActive(true);
    }

   


    public void clickExit()
    {
        Application.Quit();
    }
}

