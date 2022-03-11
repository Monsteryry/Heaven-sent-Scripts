using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;//playerObject
    public int moveSpeed;//1
    public int rotationSpeed;//1
    public int maxDistance;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        maxDistance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //If target is in range do the stuff below
        RotateToTarget();
        if (Vector3.Distance(target.position, myTransform.position) > maxDistance)
            MoveToTarget();
    }
    private void RotateToTarget()
    {
        myTransform.rotation = Quaternion.Slerp(
            myTransform.rotation,
            Quaternion.LookRotation(target.position - myTransform.position),
            rotationSpeed * Time.deltaTime
            );
    }
    private void MoveToTarget()
    {
        myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
}
