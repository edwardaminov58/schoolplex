using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    //public bool ClickedStart = false;

    public void PlayGame()
    {
        
        //ClickedStart = true;
        
    }
    public void RetryGame()
    {
        Debug.Log("Retry");
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //void Update()
    //{
    //    if (ClickedStart == true)
    //    {
    //        if (Input.GetKeyDown("space"))
    //        {
    //            SceneManager.LoadScene(1);
    //            Debug.Log("Spacebar");
    //        }
    //
    //    }
    //}


}
