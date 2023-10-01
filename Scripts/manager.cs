using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{

    public bool music = true;

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Application.Quit();
    }

    public void tryAgain(){
        SceneManager.LoadScene(1);
    }

    public void menu(){
        SceneManager.LoadScene(0);
    }

    public void musicswitch(){
        music = !music;
    }
    
}
