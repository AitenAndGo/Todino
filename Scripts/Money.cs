using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money = 100;
    

    // void Start()
    // {
    //     money = 100;
    // }

    public void addMoney(int amountOfMoney)
    {
        money += amountOfMoney;
    }

    public void removeMoney(int amountOfMoney)
    {
        money -= amountOfMoney;
        if (money <= 0)
        {
            money = 0;
        }
    }

    public bool canBuy(int amountOfMoney)
    {
        int tempMoney = money - amountOfMoney;
        if (tempMoney < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
