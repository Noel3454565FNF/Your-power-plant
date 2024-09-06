using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterpumpLibs : MonoBehaviour
{

    public string pumpType;
    public float pumpProduction;
    public float pumpPowerUsage;
    public float pumpRate;
    // Start is called before the first frame update
    private void Awake()
    {
        if(pumpType == "normal")
        {
            pumpProduction = 400;
            pumpRate = 10;
            pumpPowerUsage = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
