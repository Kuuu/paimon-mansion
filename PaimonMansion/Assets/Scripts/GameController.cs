using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    private int currentRoom = 1;
    private Vector3 vec3;
    private int nextRoomIndex;
    private bool reEnableFPC = false;
    private bool teleportOnUpdate = false;

    public Transform[] roomStartPoints;
    public Text roomText;
    public GameObject player;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }

        vec3 = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (reEnableFPC)
        {
            player.GetComponent<FirstPersonController>().enabled = true;
            reEnableFPC = false;
        }

        if (teleportOnUpdate)
        {
            Teleport();
            teleportOnUpdate = false;
            reEnableFPC = true;
        }
    }

    public void NextDoor()
    {
        teleportOnUpdate = true;
    }

    private void Teleport()
    {
        currentRoom++;

        if (currentRoom < 10)
        {
            roomText.text = "00" + currentRoom;
        } else if (currentRoom < 100)
        {
            roomText.text = "0" + currentRoom;
        } else
        {
            roomText.text = "" + currentRoom;
        }

        nextRoomIndex = Random.Range(0, roomStartPoints.Length);

        vec3.x = roomStartPoints[nextRoomIndex].position.x;
        vec3.y = roomStartPoints[nextRoomIndex].position.y;
        vec3.z = roomStartPoints[nextRoomIndex].position.z;

        player.GetComponent<FirstPersonController>().enabled = false;
        player.transform.position = vec3;

    }
}
