using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactorLibs : MonoBehaviour
{

    public float waterUsage;
    public float powerProduction;
    public int temp = 0;

    public connectorLibs R;
    public connectorLibs D;
    public connectorLibs L;
    public connectorLibs U;

    // Start is called before the first frame update
    void Start()
    {
     
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void waterpipconnected(GameObject connector)
    {
        connector.GetComponent<connectorLibs>().waterconsomationchange(waterUsage - connector.GetComponent<connectorLibs>().sender.gameObject.GetComponent<pipLibs>().GlobalWaterConsommation);
        print("water prelavting");
    }

}
