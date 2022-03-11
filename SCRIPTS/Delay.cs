using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delay : MonoBehaviour
{
    public GameObject go;
    public void Wait(float delay)
    {
        //float timer = Time.deltaTime;
        StartCoroutine(Delayer(delay));
        //if (timer >)
        //    go.SetActive(false);
    }
    public IEnumerator Delayer(float delay)
    {
        yield return new WaitForSeconds(delay);
        go.SetActive(false);
    }
}
