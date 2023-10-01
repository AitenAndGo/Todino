using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyText : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = FindObjectOfType<Money>().money.ToString("0");
    }
}
