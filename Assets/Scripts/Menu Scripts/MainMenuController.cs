using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject ButtonPanel, CharacterSelect_Panel;
    private MainMenuCamera mainmenucamera;

    private void Awake()
    {
        mainmenucamera = Camera.main.GetComponent<MainMenuCamera>();
        

    }

    public void PlayGame()
    {
        if (mainmenucamera.Can_Click)
        {
            mainmenucamera.Can_Click = false;
            ButtonPanel.SetActive(false);
            CharacterSelect_Panel.SetActive(true);

            mainmenucamera.reached_CharacterSelectposition = false;
        }
    }




}
