//based on https://www.youtube.com/watch?v=t7GuWvP_IEQ&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=6
using UnityEngine;

public class BuildManager : MonoBehaviour{

    // public GameObject smallTowerPrefab;
    // public GameObject mediumTowerPrefab;
    // public GameObject largeTowerPrefab;

    //void Start()
    //{
    //    towerToBuild = standardTowerPrefab;
    //}
    public int Index = 0;

    private GameObject towerToBuild = null;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToBuild(GameObject tower, int i)
    {
        towerToBuild = tower;
        Index = i;
    }
}