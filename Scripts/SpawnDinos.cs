using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDinos : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject dino1;
    public GameObject dino2;
    public GameObject dino3;
    public GameObject dino4;
    public int road = 1;

    // Start is called before the first frame update
    void Start()
    {
        // spawnDino();
    }

    public void spawnDino()
    {
        float randomNumber = Random.Range(0f, 1f);
        GameObject dino = null;
       if (randomNumber < 0.1)
        {
            dino = dino1;
        }
       else if(randomNumber < 0.35)
        {
            dino = dino2;
        }
       else if(randomNumber < 0.6)
        {
            dino = dino3;
        }
        else
        {
            dino = dino4;
        }


        //GameObject dino = dino1;
        DinoMovement dm = Instantiate(dino, spawnPoint.position, spawnPoint.rotation).GetComponent<DinoMovement>();
        dm.roadIndex = road; // Ustawiamy customValue na 10
    }
}