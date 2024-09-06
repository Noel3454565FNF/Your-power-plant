using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipLibs : MonoBehaviour
{

    public GameObject R;
    public GameObject U;
    public GameObject L;
    public GameObject D;

    public float GlobalWaterConsommation = 0;
    public int GlobalWaterFlow = 0;
    public int MaxFlow = 25000;
    public bool firstinit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeglobalwater(float wcc, string ignore)
    {
        GlobalWaterConsommation += wcc;
        if (ignore == "R")
        {
            L.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            U.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            D.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
        }
        if (ignore == "D")
        {
            R.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            U.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            L.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);

        }
        if (ignore == "L")
        {
            R.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            U.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            D.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
        }
        if (ignore != "U")
        {
            R.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            D.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
            L.gameObject.GetComponent<connectorLibs>().transmitwater(wcc);
        }
    }

}
