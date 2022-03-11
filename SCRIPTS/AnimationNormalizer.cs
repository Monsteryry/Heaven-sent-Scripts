using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNormalizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = gameObject.transform.position;
        tmp.z = 0;
        gameObject.transform.position = tmp;
    }
}
