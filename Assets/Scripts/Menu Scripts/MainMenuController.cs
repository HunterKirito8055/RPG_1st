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
        mainmenucamera.changeposition(1);
        ButtonPanel.SetActive(false);
            CharacterSelect_Panel.SetActive(true);
        //if (mainmenucamera.Can_Click)
        //{
        //    mainmenucamera.Can_Click = false;
        //    ButtonPanel.SetActive(false);
        //    CharacterSelect_Panel.SetActive(true);

        //    mainmenucamera.reached_CharacterSelectposition = false;
        //}
    }
    public void BackToMainMenu()
    {
        mainmenucamera.changeposition(0);
        ButtonPanel.SetActive(true );
        CharacterSelect_Panel.SetActive(false);
        //if (mainmenucamera.Can_Click)
        //{
        //    mainmenucamera.Can_Click = false;
        //    mainmenucamera.BakToMainMenu = true;

        //    ButtonPanel.SetActive(true);
        //    CharacterSelect_Panel.SetActive(false);
        //}
    }




}
