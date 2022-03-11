using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public Dictionary<string, GameObject> equipment;
    public GameObject itemDescriptionPanel;
    public GameObject inventory;
    public GameObject inventoryCH;
    public bool isInventoryOpened;
    public static Inventory instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void FillEquipment()
    {
        //Armor
        equipment["Head"] = new GameObject();
        equipment["Chest"] = new GameObject();
        equipment["Legs"] = new GameObject();
        equipment["Feet"] = new GameObject();
        //Weapons
        equipment["LeftHand"] = new GameObject();
        equipment["RightHand"] = new GameObject();
        //Accessories
        equipment["Rune"] = new GameObject();
        /*
        buttons[0] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 1 },
            ["Enemy2"] = new List<int>() { 2 }
        };
        buttons[1] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 3, 4 },
            ["Enemy2"] = new List<int>() { 5 },
            ["Enemy3"] = new List<int>() { 6 }
        };
        buttons[2] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 7, 8 },
            ["Enemy3"] = new List<int>() { 9, 10 }
        };
        buttons[3] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 12 },
            ["Enemy2"] = new List<int>() { 13 },
            ["Enemy3"] = new List<int>() { 14 },
            ["Enemy4"] = new List<int>() { 11 }
        };
        buttons[4] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 15, 16, 18 },
            ["Enemy4"] = new List<int>() { 17 }
        };
        buttons[5] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 19, 20, 23, 24, 28, 31, 32, 34 },
            ["Enemy2"] = new List<int>() { 21, 29 },
            ["Enemy3"] = new List<int>() { 22, 25, 26, 30 },
            ["Enemy4"] = new List<int>() { 27, 33 }
        };
        buttons[6] = new Dictionary<string, List<int>>
        {
            ["Enemy1"] = new List<int>() { 35, 36, 39, 40, 44, 47, 48, 50 },
            ["Enemy2"] = new List<int>() { 37, 45 },
            ["Enemy3"] = new List<int>() { 38, 41, 42, 46 },
            ["Enemy4"] = new List<int>() { 43, 49 }
        };
        */
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInventoryOpened)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(true);
                isInventoryOpened = true;
                InventoryController.instance.UpdatePanelSlots();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventory.SetActive(false);
                isInventoryOpened = false;
                InventoryController.instance.UpdatePanelSlots();
            }
        }
    }
    public void CreateCanvas()
    {
        GameObject myGO;
        GameObject inv;
        GameObject invHolder;
        Canvas myCanvas;
        Text text;
        RectTransform rectTransform;

        // Canvas
        myGO = new GameObject();
        myGO.name = "GUICanvas";
        myGO.tag = "GUI";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        CreateInventory(myGO);
        CreateInventoryContentHolder(inventory);
        CreateEquipmentFrame(inventory, inventoryCH);
        CreateItemsFrame(inventory, inventoryCH);
        itemDescriptionPanel = CreateItemDescriptionScroll(inventory);
        inventoryCH.transform.SetAsLastSibling();
        CreateStatsFrame(inventory);
        inventory.SetActive(false);
        /*
        // Text
        inv = new GameObject();
        inv.transform.parent = myGO.transform;
        inv.name = "Inventory";

        text = inv.AddComponent<Text>();
        text.font = (Font)Resources.Load("NewRocker-Regular");
        text.text = "";
        text.fontSize = 15;

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);
        AdjustButtons(myGO);*/


    }
    public void CreateInventory(GameObject canvas)
    {
        GameObject inv = new GameObject();
        inv.name = "Inventory";
        inv.tag = "GUI";
        UnityEngine.UI.Image img = inv.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = inv.GetComponent<RectTransform>();
        inv.transform.parent = canvas.transform;
        rect.sizeDelta = new Vector2(0.4f * Screen.width, 0.8f * Screen.height);
        rect.localPosition = new Vector3(0.4f * Screen.width * 0.6f, Screen.height * 0.05f, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("bar_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        
        //edit
        inventory = inv;
        isInventoryOpened = false;
    }
    public void CreateInventoryContentHolder(GameObject inv)
    {
        GameObject invHolder = new GameObject();
        invHolder.name = "InventoryHolder";
        invHolder.tag = "GUI";
        UnityEngine.UI.Image img = invHolder.AddComponent<UnityEngine.UI.Image>();
        img.color = Color.clear;
        RectTransform rect = invHolder.GetComponent<RectTransform>();
        invHolder.transform.parent = inv.transform;
        rect.sizeDelta = new Vector2(inv.GetComponent<RectTransform>().sizeDelta.x, inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0, 0);
        inventoryCH = invHolder;
    }
    public void CreateStatsFrame(GameObject inv)
    {
        GameObject stats = new GameObject();
        stats.name = "Stats";
        stats.tag = "GUI";
        UnityEngine.UI.Image img = stats.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = stats.GetComponent<RectTransform>();
        stats.transform.parent = inv.transform;
        rect.sizeDelta = new Vector2(1 / 3f * inv.GetComponent<RectTransform>().sizeDelta.x, 0.5f * inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(-1 / 3f * inv.GetComponent<RectTransform>().sizeDelta.x, 0.25f * inv.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("bar_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        /*
        GameObject go = new GameObject();
        go.name = "Text";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 25;
        txt.text = "Stats";
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect1 = go.GetComponent<RectTransform>();
        go.transform.parent = stats.transform;
        rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, 0.1f * stats.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0.45f * stats.GetComponent<RectTransform>().sizeDelta.y, 0);
        */
        CreateStatsText(stats);
        GameObject scroll = CreateStatsScroll(inv);
        CreateStatsButton(stats, scroll);
        //
    }
    public void CreateStatsText(GameObject stats)
    {
        GameObject go = new GameObject();
        go.name = "Text";
        go.tag = "GUI";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 25;
        txt.text = "Attributes";
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = stats.transform;
        rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, 0.2f * stats.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0.40f * stats.GetComponent<RectTransform>().sizeDelta.y, 0);


        FillAttributes(stats, "Damage", 2);
        FillAttributes(stats, "Vitality", 1);
        FillAttributes(stats, "Power", 0);
        FillAttributes(stats, "Armor", -1);
        FillAttributes(stats, "Resistance", -2);
    }
    public void CreateStatsButton(GameObject stats, GameObject scroll)
    {
        GameObject obj = (GameObject)Instantiate(Resources.Load("Button"));
        obj.name = "Button";
        obj.tag = "GUI";
        UnityEngine.UI.Button btn = obj.GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = obj.GetComponent<UnityEngine.UI.Image>();

        btn.GetComponentInChildren<Text>().font = (Font)Resources.Load("NewRocker-Regular");
        btn.GetComponentInChildren<Text>().fontSize = 20;
        btn.GetComponentInChildren<Text>().text = "Details";
        btn.GetComponentInChildren<Text>().alignment = TextAnchor.MiddleCenter;
        btn.GetComponentInChildren<Text>().color = new Color(255, 255, 255, 0.5f);

        RectTransform rect = obj.GetComponent<RectTransform>();
        obj.transform.parent = stats.transform;
        rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, 0.2f * stats.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, -0.40f * stats.GetComponent<RectTransform>().sizeDelta.y, 0);

        var tex = Resources.Load<Texture2D>("button_image");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        SetupButtonOnClick(btn, scroll);

        //go.name = "Button";
        //UnityEngine.UI.Button btn = go.AddComponent<UnityEngine.UI.Button>();
        /*btn.font = (Font)Resources.Load("NewRocker-Regular");
        btn.fontSize = 25;
        btn.text = "Stats";
        btn.alignment = TextAnchor.MiddleCenter;
        btn.color = new Color(255, 255, 255, 0.5f);*/
        //RectTransform rect = go.GetComponent<RectTransform>();
        //go.transform.parent = stats.transform;
        //rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, 0.2f * stats.GetComponent<RectTransform>().sizeDelta.y);
        //rect.localPosition = new Vector3(0, -0.40f * stats.GetComponent<RectTransform>().sizeDelta.y, 0);
    }
    public void SetupButtonOnClick(UnityEngine.UI.Button btn, GameObject scroll)
    {
        Debug.Log("Button");
        btn.onClick.AddListener(delegate { ButtonClicked(scroll); });
    }

    public void ButtonClicked(GameObject obj)
    {
        Debug.Log("Button clicked");
        if (!obj.activeSelf)
            obj.SetActive(true);
        else
            obj.SetActive(false);
    }
    public GameObject CreateStatsScroll(GameObject inv)
    {
        //is it has to be scroll?

        //change stats to inv cuz height and width will be calculated from inv's values
        GameObject scroll = (GameObject)Instantiate(Resources.Load("Details"));
        scroll.transform.parent = inv.transform;
        scroll.name = "Scroll View";
        scroll.tag = "GUI";
        GameObject content = GameObject.Find("Content");

        RectTransform rect = scroll.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0.75f * inv.GetComponent<RectTransform>().sizeDelta.x, inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(-0.875f * inv.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

        RectTransform rect1 = content.GetComponent<RectTransform>();
        rect1.sizeDelta = new Vector2(0.75f * inv.GetComponent<RectTransform>().sizeDelta.x, 2f * inv.GetComponent<RectTransform>().sizeDelta.y);
        
        if (content != null)
        {
            FillStats(content, "Damage", 1);
            FillStats(content, "Attack speed", 2);
            FillStats(content, "Critical Strike Chance", 3);
            FillStats(content, "CriticalStrikeDamage", 4);
            FillStats(content, "Vitality", 5);
            FillStats(content, "Power", 6);
            FillStats(content, "Health Regeneration", 7);
            FillStats(content, "Energy Regeneration", 8);
            FillStats(content, "Armor", 9);
            FillStats(content, "Elements Resistance", 10);
            FillStats(content, "Aeras Resistance", 11);
            FillStats(content, "Darc Resistance", 12);
            FillStats(content, "Hydras Resistance", 13);
            FillStats(content, "Lux Resistance", 14);
            FillStats(content, "Pyras Resistance", 15);
            FillStats(content, "Teras Resistance", 16);
        }
        scroll.SetActive(false);
        return scroll;
        /*
    //Force
    Damage, //
    //Swiftness
    AttackSpeed,
    MovementSpeed,
    CoolDownReduction,
    //Criticality
    CriticalStrikeChance,   //
    CriticalStrikeDamage,   //*10
    //defensive
    Armor,
    ElementsResistance,
    AerasResistance,
    DarcResistance,
    HydrasResistance,
    LuxResistance,
    PyrasResistance,
    TerasResistance,
    //sources
    Vitality,
    Power,
    HealthRegeneration,
    EnergyRegeneration,*/
        /*
        for (int i = 0; i < 5; i++)
        {
            GameObject go = new GameObject();
            go.name = attribute;
            Text txt = go.AddComponent<Text>();
            txt.font = (Font)Resources.Load("NewRocker-Regular");
            txt.fontSize = 15;
            txt.text = attribute + PlayerPrefs.GetString(attribute, "0");
            txt.alignment = TextAnchor.MiddleCenter;
            txt.color = new Color(255, 255, 255, 0.25f);
            RectTransform rect = go.GetComponent<RectTransform>();
            go.transform.parent = scroll.transform;
            rect.sizeDelta = new Vector2(scroll.GetComponent<RectTransform>().sizeDelta.x, scroll.GetComponent<RectTransform>().sizeDelta.y);
            rect.localPosition = new Vector3(0, 0, 0);
            txt.transform.parent = content.transform;
        }*/
        /*
        ScrollView scrollView = new ScrollView();
        GameObject scroll = new GameObject();
        scroll.name = "Scroll";
        ScrollRect scrollRect = scroll.AddComponent<ScrollRect>();
        scrollRect.content = scroll.GetComponent<RectTransform>();
        scrollRect.horizontal = false;
        scrollRect.vertical = true;
        
        Mask mask = scroll.AddComponent<Mask>();
        //UnityEngine.UI.Image img = scroll.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = scroll.GetComponent<RectTransform>();
        scroll.transform.parent = stats.transform;
        rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, stats.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0, 0);
        */
        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        //var tex = Resources.Load<Texture2D>("bar_ready");
        //var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        //img.sprite = sprite;
    }
    public void FillAttributes(GameObject content, string text, int id)
    {
        GameObject go = new GameObject();
        go.name = text;
        go.tag = "GUI";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 15;
        txt.text = text;
        txt.alignment = TextAnchor.MiddleLeft;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = content.transform;
        rect.sizeDelta = new Vector2(0.8f * content.GetComponent<RectTransform>().sizeDelta.x, 0.1f * content.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, id * 0.12f * content.GetComponent<RectTransform>().sizeDelta.y, 0);
        FillAttributesValue(go, text, id, TextAnchor.MiddleRight);
    }
    public void FillAttributesValue(GameObject content, string text, int id, TextAnchor textAnchor)
    {
        GameObject go = new GameObject();
        go.name = "Value";
        go.tag = "GUI";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 15;
        txt.text = PlayerPrefs.GetString(text, "0");
        txt.alignment = textAnchor;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = content.transform;
        rect.sizeDelta = new Vector2(content.GetComponent<RectTransform>().sizeDelta.x, 2 * content.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0, 0);
    }
    public void FillStats(GameObject content, string text, int id)
    {
        GameObject go = new GameObject();
        go.name = text;
        go.tag = "GUI";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 18;
        txt.text = text /*+ " = " + PlayerPrefs.GetString(text, "0")*/;
        txt.alignment = TextAnchor.MiddleLeft;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = content.transform;
        rect.sizeDelta = new Vector2(0.8f * content.GetComponent<RectTransform>().sizeDelta.x, 0.1f * content.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, -id * 0.03f * content.GetComponent<RectTransform>().sizeDelta.y, 0);//dostosowac przedtem 1/22
        FillAttributesValue(go, text, id, TextAnchor.MiddleRight);
    }
    public GameObject CreateEquipmentFrame(GameObject inv, GameObject invCH)
    {
        GameObject eq = new GameObject();
        eq.name = "Equipment";
        eq.tag = "GUI";
        UnityEngine.UI.Image img = eq.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = eq.GetComponent<RectTransform>();
        eq.transform.parent = inv.transform;
        rect.sizeDelta = new Vector2(2 / 3f * inv.GetComponent<RectTransform>().sizeDelta.x, 0.5f * inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(1 / 6f * inv.GetComponent<RectTransform>().sizeDelta.x, 0.25f * inv.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("bar_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        CreateEquipmentImage(eq);
        /*
        InventoryController.instance.equipmentSlots[0] = CreateEquipmentSlots(eq, -0.3375f, 0.3375f,"Head","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[1] = CreateEquipmentSlots(eq, -0.3375f, 0.1125f, "Chest","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[2] = CreateEquipmentSlots(eq, -0.3375f, -0.1125f, "Legs","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[3] = CreateEquipmentSlots(eq, -0.3375f, -0.3375f, "Right\nHand","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[4] = CreateEquipmentSlots(eq, 0.3375f, 0.3375f, "Hands","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[5] = CreateEquipmentSlots(eq, 0.3375f, 0.1125f, "Cape","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[6] = CreateEquipmentSlots(eq, 0.3375f, -0.1125f, "Rune","").GetComponent<SlotController>();
        InventoryController.instance.equipmentSlots[7] = CreateEquipmentSlots(eq, 0.3375f, -0.3375f, "Left\nHand","").GetComponent<SlotController>();
        */
        int tmp = 0;
        for (int i = 0; i < 4; i++)
        {
            string type = EquipmentSlotTypeNameSwitcher(i);
            InventoryController.instance.inventorySlots[i] = CreateEquipmentSlots(eq, -0.3375f, 0.3375f - (i * 0.225f), type, "Slot " + (i + 1), invCH).GetComponent<SlotController>();
            tmp++;
        }
        for (int i = tmp; i < 8; i++)
        {
            string type = EquipmentSlotTypeNameSwitcher(i);
            InventoryController.instance.inventorySlots[i] = CreateEquipmentSlots(eq, 0.3375f, 0.3375f - ((i - 4) * 0.225f), type, "Slot " + (i + 1), invCH).GetComponent<SlotController>();
        }
        return eq;
    }
    public string EquipmentSlotTypeNameSwitcher(int i)
    {
        switch (i)
        {
            case 0:
                return "Head";
            case 1:
                return "Chest";
            case 2:
                return "Legs";
            case 3:
                return "Right\nHand";
            case 4:
                return "Hands";
            case 5:
                return "Boots";
            case 6:
                return "Rune";
            case 7:
                return "Left\nHand";
            default:
                return "Slot";
        }
    }
    public string WeaponSlotTypeSwitcher(string type)
    {
        if (type == "Right\nHand" || type == "Left\nHand")
            return "Weapon";
        return type;
    }
    public void CreateEquipmentImage(GameObject eq)
    {
        GameObject image = new GameObject();
        image.name = "Image";
        image.tag = "GUI";
        UnityEngine.UI.Image img = image.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = image.GetComponent<RectTransform>();
        image.transform.parent = eq.transform;
        rect.sizeDelta = new Vector2(0.4f * eq.GetComponent<RectTransform>().sizeDelta.x, 0.8f * eq.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("warrior_silhouette_man");//or woman depending on character's gender
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;
    }
    public GameObject CreateEquipmentSlots(GameObject eq, float x, float y, string type, string name, GameObject invCH)
    {
        //helm - armor - legs - gloves - 
        GameObject go = (GameObject)Instantiate(Resources.Load("Slot"));
        UnityEngine.UI.Button btn = go.GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = go.GetComponent<UnityEngine.UI.Image>();
        go.name = name;
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = invCH.transform;
        rect.sizeDelta = new Vector2(0.2f * eq.GetComponent<RectTransform>().sizeDelta.x, 0.2f * eq.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(
            x * eq.GetComponent<RectTransform>().sizeDelta.x + 1 / 6f * invCH.GetComponent<RectTransform>().sizeDelta.x,
            y * eq.GetComponent<RectTransform>().sizeDelta.y + 0.25f * invCH.GetComponent<RectTransform>().sizeDelta.y, 0);
        var tex = Resources.Load<Texture2D>("Mini_background");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;


        GameObject go1 = new GameObject();
        go1.name = "Text";
        go1.tag = "GUI";
        Text txt = go1.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 20;
        txt.text = type;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.05f);
        RectTransform rect1 = go1.GetComponent<RectTransform>();
        go1.transform.parent = go.transform;
        rect1.sizeDelta = new Vector2(go.GetComponent<RectTransform>().sizeDelta.x, go.GetComponent<RectTransform>().sizeDelta.y);
        rect1.localPosition = new Vector3(0, 0, 0);
        go1.transform.SetAsFirstSibling();

        go.GetComponent<SlotController>().slotType = WeaponSlotTypeSwitcher(type);

        return go;
        /*
        //helm - armor - legs - gloves - 
        GameObject go = new GameObject();
        go.name = "Slot";
        go.tag = "GUI";
        UnityEngine.UI.Button btn = go.AddComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = go.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = eq.transform;
        rect.sizeDelta = new Vector2(0.2f * eq.GetComponent<RectTransform>().sizeDelta.x, 0.2f * eq.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(x * eq.GetComponent<RectTransform>().sizeDelta.x, y * eq.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("Mini_background");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        GameObject go1 = new GameObject();
        go1.name = "Text";
        go1.tag = "GUI";
        Text txt = go1.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 20;
        txt.text = type;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255,255,255,0.25f);
        RectTransform rect1 = go1.GetComponent<RectTransform>();
        go1.transform.parent = go.transform;
        rect1.sizeDelta = new Vector2(go.GetComponent<RectTransform>().sizeDelta.x, go.GetComponent<RectTransform>().sizeDelta.y);
        rect1.localPosition = new Vector3(0, 0, 0);
        */
    }

    public void CreateItemsFrame(GameObject inv, GameObject invCH)
    {
        GameObject it = new GameObject();
        it.name = "Items";

        UnityEngine.UI.Image img = it.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = it.GetComponent<RectTransform>();
        it.transform.parent = inv.transform;
        rect.sizeDelta = new Vector2(inv.GetComponent<RectTransform>().sizeDelta.x, 0.5f * inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, -0.25f * inv.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("barmid_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        int tmp = 0;
        for (int i = 0; i < 4; i++)//(int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < 8; j++)//(int j = 1; j <= 8; j++)
            {
                InventoryController.instance.inventorySlots[tmp+8] = CreateItemsSlots(it, -0.42f + (j * 0.12f), 0.36f - (i * 0.2f), "Slot " + (tmp+9), invCH).GetComponent<SlotController>();
                tmp++;
            }
        }
        CreateWalletSlot(it);



        /*
        CreateItemsSlots(it, -0.42f, 0.38f); // x+0.12 y-0.2
        CreateItemsSlots(it, -0.30f, 0.38f);
        CreateItemsSlots(it, -0.18f, 0.38f);
        CreateItemsSlots(it, -0.06f, 0.38f);
        CreateItemsSlots(it, 0.06f, 0.38f);
        CreateItemsSlots(it, 0.18f, 0.38f);
        CreateItemsSlots(it, 0.30f, 0.38f);
        CreateItemsSlots(it, 0.42f, 0.38f);*/
    }
    public GameObject CreateItemsSlots(GameObject it, float x, float y, string name, GameObject invCH)
    {
        //helm - armor - legs - gloves - 
        //GameObject go = new GameObject();
        GameObject go = (GameObject)Instantiate(Resources.Load("Slot"));


        //GameObject obj = (GameObject)Instantiate(Resources.Load("Button"));
        //obj.name = "Button";
        //obj.tag = "GUI";
        UnityEngine.UI.Button btn = go.GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = go.GetComponent<UnityEngine.UI.Image>();


        //pomysl by dac jeden obj na wszystkie sloty, dodatki w osobnym, a rect zależny od inv 



        go.name = name;
        //UnityEngine.UI.Button btn = go.AddComponent<UnityEngine.UI.Button>();
        //UnityEngine.UI.Image img = go.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = invCH.transform;
        rect.sizeDelta = new Vector2(0.12f * it.GetComponent<RectTransform>().sizeDelta.x, 0.2f * it.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(x * it.GetComponent<RectTransform>().sizeDelta.x, 
            y * it.GetComponent<RectTransform>().sizeDelta.y - 0.25f * invCH.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("Mini_background");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        return go;
        /*
        GameObject go1 = new GameObject();
        go1.name = "Text";
        Text txt = go1.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 20;
        txt.text = type;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.25f);
        RectTransform rect1 = go1.GetComponent<RectTransform>();
        go1.transform.parent = go.transform;
        rect1.sizeDelta = new Vector2(go.GetComponent<RectTransform>().sizeDelta.x, go.GetComponent<RectTransform>().sizeDelta.y);
        rect1.localPosition = new Vector3(0, 0, 0);
        */
    }
    public void CreateWalletSlot(GameObject it)
    {
        GameObject go = new GameObject();
        go.name = "Wallet";
        UnityEngine.UI.Button btn = go.AddComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = go.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = it.transform;
        rect.sizeDelta = new Vector2(0.98f * it.GetComponent<RectTransform>().sizeDelta.x, 0.12f * it.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, -0.40f * it.GetComponent<RectTransform>().sizeDelta.y, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("Mini_background");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;
        /*
        GameObject go1 = new GameObject();
        go1.name = "Text";
        Text txt = go1.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 20;
        txt.text = type;
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.25f);
        RectTransform rect1 = go1.GetComponent<RectTransform>();
        go1.transform.parent = go.transform;
        rect1.sizeDelta = new Vector2(go.GetComponent<RectTransform>().sizeDelta.x, go.GetComponent<RectTransform>().sizeDelta.y);
        rect1.localPosition = new Vector3(0, 0, 0);
        */
    }

    public void AdjustButtons(GameObject canvas)
    {
        RectTransform rtCanvas = canvas.GetComponent<RectTransform>();
        for (int i = 0; i <= 5; i++)
        {
            GameObject go = new GameObject();
            go.name = "SpellButton" + i.ToString();
            go.AddComponent<UnityEngine.UI.Button>();
            go.AddComponent<UnityEngine.UI.Image>();
            //go.GetComponent<Image>().sprite = spells[i].icon;
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(60, 60);
            rt.anchoredPosition = new Vector2((rtCanvas.sizeDelta.x / 2 - 180) + (60 * i), rtCanvas.sizeDelta.y * 0.1f);
            go.transform.parent = canvas.transform;
        }
    }

    public GameObject CreateItemDescriptionScroll(GameObject inv)
    {
        //is it has to be scroll?

        //change stats to inv cuz height and width will be calculated from inv's values
        GameObject scroll = (GameObject)Instantiate(Resources.Load("ItemDescription"));
        //GameObject itemNameBackground = GameObject.Find("ItemNameBackground");
        //RectTransform rect = itemNameBackground.GetComponent<RectTransform>();

        scroll.transform.parent = inv.transform;
        scroll.name = "Item Description Scroll";
        scroll.tag = "GUI";
        GameObject content = GameObject.Find("DescriptionContent");

        RectTransform rect = scroll.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(0.75f * inv.GetComponent<RectTransform>().sizeDelta.x, rect.sizeDelta.y);
        rect.localPosition = new Vector3(-0.875f * inv.GetComponent<RectTransform>().sizeDelta.x, 0, 0);

        //RectTransform rect1 = content.GetComponent<RectTransform>();
        //rect1.sizeDelta = new Vector2(0.75f * inv.GetComponent<RectTransform>().sizeDelta.x, 2f * inv.GetComponent<RectTransform>().sizeDelta.y);
        /*
        if (content != null)
        {
            FillStats(content, "Sjema", 1);
            FillStats(content, "Attack speed", 2);
            FillStats(content, "Critical Strike Chance", 3);
            FillStats(content, "CriticalStrikeDamage", 4);
            FillStats(content, "Vitality", 5);
            FillStats(content, "Power", 6);
            FillStats(content, "Health Regeneration", 7);
            FillStats(content, "Energy Regeneration", 8);
            FillStats(content, "Armor", 9);
            FillStats(content, "Elements Resistance", 10);
            FillStats(content, "Aeras Resistance", 11);
            FillStats(content, "Darc Resistance", 12);
            FillStats(content, "Hydras Resistance", 13);
            FillStats(content, "Lux Resistance", 14);
            FillStats(content, "Pyras Resistance", 15);
            FillStats(content, "Teras Resistance", 16);
        }
        */
        scroll.SetActive(false);
        return scroll;
    }
}
