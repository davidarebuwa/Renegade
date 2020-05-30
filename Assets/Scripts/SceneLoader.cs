using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour{

    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstScene", 1f);
        //Button btn = playButton.GetComponent<Button>();
       // btn.onClick.AddListener(LoadFirstScene);


    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
      

    }
    //public void TaskOnClick()
    //{
    //    Debug.Log("Play game button pressed!!");
    //    Invoke("LoadFirstScene", 1f);
    //}
}
