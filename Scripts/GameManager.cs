using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int dinosToSpawnNumber = 4;
    public int currentDinosSpawnNumber = 0;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    public bool music = true;

    private bool flag = true;

    private bool tura1 = true;
    private bool tura2 = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (tura1 || tura2){
            if (flag){
                if (currentDinosSpawnNumber < dinosToSpawnNumber)
                {
                    Invoke("Spawn", 4.0f);
                } else{
                    Invoke("next", 25.0f);
                    tura1 = false;
                }
                flag = false;
            }
        }
        if (Time.timeSinceLevelLoad > 60){
            if (FindObjectOfType<DinoMovement>() != null){
                GameWon();
            }
        }
    }

    public void GameWon(){
        SceneManager.LoadScene(3);
    }

    public void next(){
        tura2 = true;
        currentDinosSpawnNumber = 6;
    }

    void Spawn()
    {
        s1.GetComponent<SpawnDinos>().spawnDino();
        s2.GetComponent<SpawnDinos>().spawnDino();
        s3.GetComponent<SpawnDinos>().spawnDino();
        s4.GetComponent<SpawnDinos>().spawnDino();
        currentDinosSpawnNumber++;
        flag = true;
    }

    public void pause(){
        Time.timeScale = 0;
    }

    public void resume(){
        Time.timeScale = 1;
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        Application.Quit();
    }

    public void menu(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void musicswitch(){
        music = !music;
    }
}