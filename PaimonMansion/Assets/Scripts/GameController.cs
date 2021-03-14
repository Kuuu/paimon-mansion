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

    public Transform[] roomStartPoints;
    public Text roomText;
    public GameObject player;

    public GameObject torch;
    private int[] torchRooms = {5};

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

    private void Start()
    {
        torch.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void NextDoor()
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

        torch.SetActive(false);
        foreach (int x in torchRooms)
        {
            if (x.Equals(nextRoomIndex))
            {
                torch.SetActive(true);
            }
        }

        vec3.x = roomStartPoints[nextRoomIndex].position.x;
        vec3.y = roomStartPoints[nextRoomIndex].position.y;
        vec3.z = roomStartPoints[nextRoomIndex].position.z;

        //player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = vec3;
        player.transform.rotation = roomStartPoints[nextRoomIndex].rotation;

    }
}
