using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Button loadSceneButton;
    public string sceneName;
    void Start()
    {
        loadSceneButton.onClick.AddListener(ChangeScene);
    }
    
    public void ChangeScene()
    {
        //Application.LoadLevel("Survival");
       
        SceneManager.LoadScene(sceneName);
    }
    /*
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

   

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    // Update is called once per frame
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } */
    void Update()
    {
        
    }

    
}
