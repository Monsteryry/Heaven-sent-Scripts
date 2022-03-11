using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance, height;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TargetAndFollow();
        ScrollCameraPOV();
    }

    private void TargetAndFollow()
    {
        //transform.position = new Vector3(target.position.x, (float)Math.Round((target.position.y + height) * 100f) / 100f, (float)Math.Round((target.position.z - distance) * 100f) / 100f);
        transform.position = new Vector3(target.position.x, target.position.y + ((float)Math.Round(height * 100f) / 100f), target.position.z - ((float)Math.Round(distance * 100f) / 100f));
        transform.rotation = new Quaternion(0, 45, 0, 0);
        transform.LookAt(target);
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
}
