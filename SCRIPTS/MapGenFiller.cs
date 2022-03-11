using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenFiller : MonoBehaviour
{
    GenerationSettings generationSettings;
    public int[] setTab = 
    { 
        10, //minRooms
        15, //maxRooms
        6,  //amountOfAdjacentRoomsToConnect
        20, //minRoomWidth
        30, //maxRoomWidth
        20, //minRoomHeight
        30, //maxRoomHeight
        20, //minBossRoomWidth
        30, //maxBossRoomWidth
        20, //minBossRoomHeight
        30, //maxBossRoomHeight
        250, //areaWidth
        350, //areaHeight
        5, //minDistanceBetweenRooms
        2, //minEnemiesPerRoom;
        5, //maxEnemiesPerRoom;
        30, //wallObjConsequitiveDistance;
        30, //cornerObjectsRate;
        30, //destroyablesRate;
        30, //middleObjectsRate;

    };
    // Start is called before the first frame update
    void Start()
    {
        FillSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FillSettings()
    {
        //objects from prefabs
        //(GameObject)Instantiate(Resources.Load("enemy"));
        generationSettings = new GenerationSettings();
        generationSettings.name = "NewGenerationSettings";
        generationSettings.generation.minRooms = 0;
        generationSettings.generation.maxRooms = 0;

        generationSettings.generation.amountOfAdjacentRoomsToConnect = 0;

        //Make Minimum of 2
        generationSettings.generation.minRoomWidth = 0;
        generationSettings.generation.maxRoomWidth = 0;

        generationSettings.generation.minRoomHeight = 0;
        generationSettings.generation.maxRoomHeight = 0;

        generationSettings.generation.minBossRoomWidth = 0;
        generationSettings.generation.maxBossRoomWidth = 0;

        generationSettings.generation.minBossRoomHeight = 0;
        generationSettings.generation.maxBossRoomHeight = 0;

        generationSettings.generation.areaWidth = 0;
        generationSettings.generation.areaHeight = 0;

        generationSettings.generation.minDistanceBetweenRooms = 0;
        /*
        [SerializeField] public List<ObjectList> walls = new List<ObjectList>();
        [SerializeField] public List<ObjectList> outerCorners = new List<ObjectList>();
        [SerializeField] public List<ObjectList> innerCorners = new List<ObjectList>();
        [SerializeField] public bool deleteInnerCorners;
        [SerializeField] public List<ObjectList> uCorners = new List<ObjectList>();
        [SerializeField] public List<ObjectList> squareCorners = new List<ObjectList>();
        [SerializeField] public List<ObjectList> doors = new List<ObjectList>();
        [SerializeField] public List<Vector3> doorsDisplacements;
        [SerializeField] public List<ObjectList> flooring = new List<ObjectList>();
        */
        //[SerializeField] public GameObject player;

        generationSettings.generation.minEnemiesPerRoom = 0;
        generationSettings.generation.maxEnemiesPerRoom = 0;
        /*
        [SerializeField] public List<ObjectList> enemies = new List<ObjectList>();
        [SerializeField] public List<ObjectList> bosses = new List<ObjectList>();
        [SerializeField] public List<ObjectList> breakables = new List<ObjectList>();
        [SerializeField] public List<ObjectList> staticObjects = new List<ObjectList>();
        [SerializeField] public List<ObjectList> wallObjects = new List<ObjectList>();
        */
        generationSettings.generation.wallObjConsequitiveDistance = 0;
        //[SerializeField] public List<Vector3> wallObjDisplacements;

        //[Range(0, 100)]
        generationSettings.generation.cornerObjectsRate = 0;
        //[Range(0, 100)]
        generationSettings.generation.destroyablesRate = 0;

        //[SerializeField] public List<ObjectList> middleObjects = new List<ObjectList>();
        //[Range(0, 100)]
        generationSettings.generation.middleObjectsRate = 0;
    }
}
