using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void StartButtonClick()
    {
        //Start Program
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
   
   public void ExitButtonClick()
    {
        //Exit Program
        Application.Quit();
    }
}
