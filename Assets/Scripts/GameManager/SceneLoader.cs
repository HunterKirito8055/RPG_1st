using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public GameObject loadingscreen;
    private string levelname;

    void Awake()
    {
        makesingleton();
    }

    void makesingleton()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void LoadLevel(string name)
    {
        levelname = name;
        StartCoroutine(LoadLevelWIthName());
    }

    IEnumerator LoadLevelWIthName()
    {
        loadingscreen.SetActive(true);
        SceneManager.LoadScene(levelname);
        yield return new WaitForSeconds(2.5f);
        loadingscreen.SetActive(false);
    }
}
