using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionHandler : MonoBehaviour
{

   
    //Change between Menu and options
    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScence", LoadSceneMode.Single);
    }

    public void GotoOptions()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Single);
    }

}
