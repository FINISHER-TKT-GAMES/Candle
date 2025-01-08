using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Animator cameraAnimator;

    public void PlayGame()
{
    cameraAnimator.SetTrigger("NewGame"); 
    StartCoroutine(LoadSceneAfterAnimation());
}

private IEnumerator LoadSceneAfterAnimation()
{
   
    yield return new WaitForSeconds(cameraAnimator.GetCurrentAnimatorStateInfo(0).length);
    
    yield return new WaitForSeconds(2f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");


    }

}
