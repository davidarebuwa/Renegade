using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFX;

   public int currentScene;
   public string levelName;

    //[SerializeField] GameObject enemy;


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Finish"))
        {

            Invoke("LoadNextLevel", levelLoadDelay);
        }
        else {

            StartDeathSequence();
            deathFX.SetActive(true);
            Invoke("ReloadLevel", levelLoadDelay);

        }

        //print("Player has triggered object or obstacle");
        //StartDeathSequence();
        //deathFX.SetActive(true);
        //Invoke("ReloadLevel", levelLoadDelay);


        //switch (enemy.gameObject.tag)
        //{
        //    case "Friendly":
        //        // do nothing
        //        break;
        //    case "Finish":
        //        print("Loading next level..."); //todo load level 2
        //        Invoke("LoadNextLevel", levelLoadDelay);
        //        break;
        //    default:
        //        print("collision occured");
        //        break;

        //}



    }

    private void StartDeathSequence()
    {

        print("player collected damage");
        SendMessage("OnPlayerDeath");

    }

    private void ReloadLevel() {
      //  currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextLevel() {

        //currentScene = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentScene + 1);
    }
}
