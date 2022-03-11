using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Vector3 startPoint;
    public float mapLength;
    public float mapWidth;
    public GameObject[] caveParts;

    public void DefineMapSize()
    {
        GameObject go = new GameObject();
        go.name = "Mapa";
        
        /*
        Ins
        GameObject go = new GameObject();
        go.name = "Mapa";
        var terrain = go.AddComponent<Terrain>();
        go.AddComponent<TerrainCollider>();
        terrain.transform.position = startPoint;
        terrain.terrainData.size = new Vector3(mapLength, mapWidth, 600);*/
    }
    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(0, 0, 0);
        mapLength = 200;
        mapWidth = 200;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
