using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    GameObject itemObject;
    void OnDestroy()
    {
        GameObject item = Instantiate(itemObject, transform.position, Quaternion.identity) as GameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
