using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    bool isNearDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isNearDoor)
            {
                GameController.Instance.NextDoor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "door") {
            isNearDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "door")
        {
            isNearDoor = false;
        }
    }
}
