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
    void Start()
    {
        menuGraphics = GameObject.Find("Main Camera").GetComponent<PostProcessVolume>();
        menuGraphics.profile.TryGetSettings(out dof);
        panelNewGame.GetComponentInChildren<Image>().canvasRenderer.SetAlpha(0.0f);


    }

    // Update is called once per frame
    public void clickPlay()
    {
        mainPanel.SetActive(false);
        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f);
        panelNewGame.SetActive(true);
        panelNewGame.GetComponentInChildren<Image>().CrossFadeAlpha(1, 5, false);
    }

    public void clickOptions()
    {
       
        mainPanel.SetActive(false);
        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 2.0f, 2f);
        panelOptions.SetActive(true);
        panelOptions.GetComponentInChildren<Image>().CrossFadeAlpha(1, 5, false);
    }
    public void clickbackPlay()
    {
        panelNewGame.SetActive(false);
        mainPanel.SetActive(true);
        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f);
    }

    public void clickbackOption()
    {
        panelOptions.SetActive(false);
        mainPanel.SetActive(true);
        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance, 6.92f, 5.0f);
    }

    public void clickExit()
    {
        Application.Quit();
    }
}
