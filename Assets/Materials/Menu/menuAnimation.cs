using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class menuAnimation : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject panelNewGame;
    public GameObject panelOptions;
    

    PostProcessVolume menuGraphics;
    DepthOfField dof;

    bool panFar = true;
    void Start()
    {
        menuGraphics = GameObject.Find("Main Camera").GetComponent<PostProcessVolume>();
        menuGraphics.profile.TryGetSettings(out dof);
        panelNewGame.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(0.0f);


    }

    public void Update()
    {
        if (panFar == true)
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f * Time.deltaTime);
        else
            dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f * Time.deltaTime);
    }
    public void clickPlay()
    {
        mainPanel.SetActive(false);
        //dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f);
        panFar = false;
        panelNewGame.SetActive(true);
        panelNewGame.GetComponentInChildren<Image>().CrossFadeAlpha(1, 5, false);
    }

    public void clickOptions()
    {
       
        mainPanel.SetActive(false);
        //dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f);
        panFar = false;
        panelOptions.SetActive(true);
        panelOptions.GetComponentInChildren<Image>().CrossFadeAlpha(1, 5, false);
    }
    public void clickbackPlay()
    {
        panelNewGame.SetActive(false);
        mainPanel.SetActive(true);
        //dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f);
        panFar = true;
    }

    public void clickbackOption()
    {
        panelOptions.SetActive(false);
        mainPanel.SetActive(true);
        //dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f);
        panFar = true;
    }

    public void clickExit()
    {
        Application.Quit();
    }
}
