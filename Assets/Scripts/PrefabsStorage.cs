using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsStorage : MonoBehaviour
{

    public GameObject pip;
    public GameObject waterpump;
    public GameObject reactorMK1;


    public bool canPlace = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     

    }


    public void placebat(Vector3 pos, string bat, Transform par)
    {
        if (canPlace)
        {
            GameObject lol = null;
            if (bat == "water pump")
            {
                lol = waterpump;
            }
            if (bat == "pip")
            {
                lol = pip;
            }
            if (bat == "reactor MK1")
            {
                lol = reactorMK1;
            }
            print(lol);
            GameObject.Instantiate(lol, par.transform.position, new Quaternion(0, 0, 0, 0), lol.transform);
        }
    }
}
