using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connectorLibs : MonoBehaviour
{
    public GameObject sender; // Script to send
    public GameObject received; // GameObject received
    public connectorLibs connectorConnected;

    private pipLibs pipLibs;
    private waterpumpLibs waterPumpLibs;
    private reactorLibs reactorLibs;

    public float initialFurn;
    public string pipMode;

    public GameObject[] whitelist = new GameObject[6]; // Array for whitelists

    // Start is called before the first frame update
    void Start()
    {
        if (sender != null)
        {
            reactorLibs = sender.GetComponent<reactorLibs>();
            if (reactorLibs != null)
            {
                pipMode = "reactor";
                Debug.Log(pipMode);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != sender)
        {
            ScriptReceived(collision.gameObject);
        }
    }

    public void ScriptReceived(GameObject go)
    {
        if (received == null && go != null)
        {
            var goConnector = go.GetComponent<connectorLibs>();
            if (goConnector != null && WhitelistCheck(go))
            {
                connectorConnected = goConnector;

                pipLibs = connectorConnected.sender.GetComponent<pipLibs>();
                if (pipLibs != null)
                {
                    sender.GetComponent<pipLibs>().GlobalWaterConsommation = pipLibs.GlobalWaterConsommation;
                    pipMode = "pip";
                    Debug.Log(pipLibs.GlobalWaterConsommation);
                }

                waterPumpLibs = connectorConnected.sender.GetComponent<waterpumpLibs>();
                if (waterPumpLibs != null)
                {
                    initialFurn = waterPumpLibs.pumpProduction;
                    waterconsomationchange(waterPumpLibs.pumpProduction);
                    pipMode = "waterpump";
                    Debug.Log(waterPumpLibs.pumpProduction);
                }

                reactorLibs = connectorConnected.sender.GetComponent<reactorLibs>();
                if (reactorLibs != null)
                {
                    reactorLibs.waterpipconnected(gameObject);
                    Debug.Log("LOVE");
                }
            }
        }
    }

    public void RemoteRemoveOrder(float wcc)
    {
        received = null;
        connectorConnected = null;
        waterconsomationchange(wcc);
    }

    public void SendRemoveOrder()
    {
        if (connectorConnected != null)
        {
            connectorConnected.RemoteRemoveOrder(initialFurn);
        }
    }

    public void waterconsomationchange(float wcc)
    {
        if (sender != null && sender.GetComponent<pipLibs>() != null)
        {
            sender.GetComponent<pipLibs>().changeglobalwater(wcc, gameObject.name);
        }
    }

    public void transmitwater(float wcc)
    {
        if (connectorConnected != null)
        {
            connectorConnected.waterconsomationchange(wcc);
        }
    }

    public bool WhitelistCheck(GameObject go)
    {
        foreach (var whitelistItem in whitelist)
        {
            if (whitelistItem == go)
            {
                return false;
            }
        }
        return true;
    }
}
