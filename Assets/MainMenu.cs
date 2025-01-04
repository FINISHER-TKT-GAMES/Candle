using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MainMenu : MonoBehaviour {

    public Animator cameraAnimator;

    public void PlayGame()
    {
        cameraAnimator.SetTrigger("NewGame");

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");


    }

}
