using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Slector_Controller : MonoBehaviour
{
    public GameObject GO;
    public bool canMove;
    public string mode = "spawn";

    public float movefactor = 1.3f;
    public string thingtospawn = "pip";
    public TMPro.TMP_Dropdown Dropdown;

    public PrefabsStorage storage;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                GO.transform.position = new Vector3(GO.transform.position.x + movefactor, GO.transform.position.y, GO.transform.position.z);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                GO.transform.position = new Vector3(GO.transform.position.x + -movefactor, GO.transform.position.y, GO.transform.position.z);
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                GO.transform.position = new Vector3(GO.transform.position.x, GO.transform.position.y + movefactor, GO.transform.position.z);
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                GO.transform.position = new Vector3(GO.transform.position.x, GO.transform.position.y + -movefactor, GO.transform.position.z);
            }

            if (Input.GetKeyUp(KeyCode.Space) && mode == "spawn")
            {
                print(thingtospawn);
                storage.placebat(gameObject.transform.position, thingtospawn, gameObject.transform);
            }

            if (Input.GetKey(KeyCode.Space) && mode == "delete")
            {

            }

            if (Input.GetKeyUp(KeyCode.Tab))
            {
                if (mode == "spawn")
                {
                    mode = "delete";
                    return;
                }
                if (mode == "delete")
                {
                    mode = "spawn";
                    return;
                }
            }
        }
    }


    public void changeslectedobject()
    {
            thingtospawn = Dropdown.options[Dropdown.value].text;
            print(thingtospawn);
    }

}
