using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public Vector3 startPoint;
    public float mapLength;
    public float mapWidth;
    public void DefineMapSize()
    {
        Terrain terrain = new Terrain();
        terrain.name = "Mapa";
        terrain.transform.position = startPoint;
        terrain.terrainData.size = new Vector3(mapLength, mapWidth, 600);
    }
    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(0, 0, 0);
        mapLength = 200;
        mapWidth = 200;
        DefineMapSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
