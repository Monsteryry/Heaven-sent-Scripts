using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    //Code from CameraController.cs
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance, height;
    //Code from CameraController.cs

    public GameObject playerCharacter;
    public GameObject gameSettings;
    public Camera mainCamera;

    public float zOffset;
    public float yOffset;
    public float xRotOffset;

    private GameObject _pc;
    private PlayerCharacter _pcScript;

    private Vector3 _playerSpawnPointPos;

    // Start is called before the first frame update
    void Start()
    {
        _playerSpawnPointPos = new Vector3(30, 0.1f, 30);
        GameObject go = GameObject.Find(GameSettings.PLAYER_SPAWN_POINT);

        if (go == null)
        {
            Debug.LogWarning("Cannot find spawn point");

            go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);

            go.transform.position = _playerSpawnPointPos;
        }

        _pc = Instantiate(playerCharacter, go.transform.position, Quaternion.identity) as GameObject;
        _pc.name = "pc";
        _pcScript = _pc.GetComponent<PlayerCharacter>();

        zOffset = -2.5f;
        yOffset = 2.5f;
        xRotOffset = 22.5f;


        /*
        mainCamera.transform.position = new Vector3(
            _pc.transform.position.x,
            _pc.transform.position.y + yOffset,
            _pc.transform.position.z + zOffset
            );

        mainCamera.transform.Rotate(xRotOffset, 0, 0);
        */


        LoadCharacter();
    }

    public void LoadCharacter()
    {
        GameObject gs = GameObject.Find("GameSettings");

        if (gs == null)
        {
            GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
            gs1.name = "GameSettings";
        }

        GameSettings gsScript = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        gsScript.LoadCharacterData();
        //Code from CameraController.cs
        target = _pc.transform;
        distance = 7f;
        height = 10f;
        //Code from CameraController.cs
    }

    // Update is called once per frame
    void Update()
    {
        TargetAndFollow();
        ScrollCameraPOV();
    }

    //Code from CameraController.cs

    private void TargetAndFollow()
    {
        //transform.position = new Vector3(target.position.x, (float)Math.Round((target.position.y + height) * 100f) / 100f, (float)Math.Round((target.position.z - distance) * 100f) / 100f);
        mainCamera.transform.position = new Vector3(target.position.x + ((float)Math.Round(distance * 100f) / 100f), target.position.y + ((float)Math.Round(height * 100f) / 100f), target.position.z - ((float)Math.Round(distance * 100f) / 100f));
        mainCamera.transform.LookAt(target);
    }
    private void ScrollCameraPOV()
    {
        if (Input.mouseScrollDelta.y > 0f &&
            distance > 4.2f && height > 6f)
        {
            height -= 0.4f;
            distance -= 0.28f;
            //((float)Math.Round(height * 100f) / 100f);
        }
        else if (Input.mouseScrollDelta.y < 0f &&
            distance < 7f && height < 10f)
        {
            height += 0.4f;
            distance += 0.28f;
        }
    }

    //Code from CameraController.cs
}
