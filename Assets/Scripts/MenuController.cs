using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MenuController : MonoBehaviour
{
    public string _newGameLevel;

    public void PlayButton()
    {
        SceneManager.LoadScene(_newGameLevel);
    }
    public void QuitButton()
    {
        Application.Quit();
    }

}
