using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject charposition; 

    private int Knight_index = 0;
    private int King_index = 1;
    private int Cat_index = 2;
    void Start()
    {
        characters[Knight_index].SetActive(true);
        characters[Knight_index].transform.position = charposition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void select_character()
    {
        int index = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        Turn_Offcharcter();

        characters[index].SetActive(true);
        characters[index].transform.position = charposition.transform.position;

    }
    void Turn_Offcharcter()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
    }
}


























