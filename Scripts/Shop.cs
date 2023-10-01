using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject smallTowerPrefab;
    public GameObject mediumTowerPrefab;
    public GameObject largeTowerPrefab;
    // Start is called before the first frame update

    public void buySmallTower()
    {
        // if (FindObjectOfType<Money>().canBuy(100)){
        //     FindObjectOfType<Money>().removeMoney(100);
            FindObjectOfType<BuildManager>().SetTowerToBuild(smallTowerPrefab, 1);
        // }
    }

    public void buyMediumTower()
    {
        FindObjectOfType<BuildManager>().SetTowerToBuild(mediumTowerPrefab, 2);
    }

    public void buyLargeTower()
    {
        FindObjectOfType<BuildManager>().SetTowerToBuild(largeTowerPrefab, 3);
    }


}
