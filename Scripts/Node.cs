// based on https://www.youtube.com/watch?v=t7GuWvP_IEQ&list=PLPV2KyIb3jR4u5jX8za5iU1cqnQPmbzG0&index=6
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject tower;

    private Renderer rend;
    private Color startColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (FindObjectOfType<BuildManager>().GetTowerToBuild() == null){
            return;
        }

        if (tower != null) 
        {
            // Debug.Log("null");
            // to do can't buuild here
            return;
        }

        GameObject towerToBuild = FindObjectOfType<BuildManager>().GetTowerToBuild();
        if (FindObjectOfType<BuildManager>().Index == 1){
            if (FindObjectOfType<Money>().canBuy(300)){
                FindObjectOfType<Money>().removeMoney(300);
                tower = Instantiate(towerToBuild, transform.position + new Vector3(0, 2f, 0), Quaternion.Euler(0, 90, 0));
            }
        }
        if (FindObjectOfType<BuildManager>().Index == 2){
            if (FindObjectOfType<Money>().canBuy(100)){
                FindObjectOfType<Money>().removeMoney(100);
                tower = Instantiate(towerToBuild, transform.position + new Vector3(3, 2.5f, -7), Quaternion.Euler(0, 90, 0));
            }
        }
        if (FindObjectOfType<BuildManager>().Index == 3){
            if (FindObjectOfType<Money>().canBuy(150)){
                FindObjectOfType<Money>().removeMoney(150);
                tower = Instantiate(towerToBuild, transform.position + new Vector3(0, 1f, 0), Quaternion.Euler(270, 0, 0));
            }
        }        
    }

    private void OnMouseEnter()
    {
        // Debug.Log("jest na tym kolorku");
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color=startColor;
    }
}
