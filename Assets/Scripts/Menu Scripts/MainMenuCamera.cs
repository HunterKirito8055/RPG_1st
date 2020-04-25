using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public GameObject GameStartedPosition;
    public GameObject CharacterSelectPosition;

    private bool reach_Gamestartposition;

    private bool reach_Characterselectposition = true;
    private bool canclick;
    private bool backToMainmenu;
   

    
    void Update()
    {
       MoveToGameStartedPosition();
       MoveToCharacterSelectPosition();
    }
    void MoveToGameStartedPosition()
    {
        if (!reach_Gamestartposition)
        {
            if (Vector3.Distance(transform.position, GameStartedPosition.transform.position) < 0.2f)
            {
                reach_Gamestartposition = true;
                canclick = true;
            }
        }

        if (!reach_Gamestartposition)
        {
            transform.position = Vector3.Lerp(transform.position, GameStartedPosition.transform.position, 1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, GameStartedPosition.transform.rotation, 1f * Time.deltaTime);

        }
    }
    void MoveToCharacterSelectPosition()
    {
        
        if (!reach_Characterselectposition)
        {
            transform.position = Vector3.Lerp(transform.position, CharacterSelectPosition.transform.position, 1f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, CharacterSelectPosition.transform.rotation, 1f * Time.deltaTime);

        }
        if (!reach_Characterselectposition)
        {
            if (Vector3.Distance(transform.position, CharacterSelectPosition.transform.position) < 0.2f)
            {
                reach_Characterselectposition = true;
                canclick = true;
            }
        }
    }

    public bool reached_CharacterSelectposition
    {
        get
        {
            return reach_Characterselectposition;

        }
        set
        {
            reach_Characterselectposition = value;
        }
    }
    public bool Can_Click
    {
        get
        {
            return canclick;
        }
        set { 
            canclick = value;
        }
    }
    public bool BakToMainMenu
    {
        get { return backToMainmenu; }
        set { backToMainmenu = value;  }
    }
}
