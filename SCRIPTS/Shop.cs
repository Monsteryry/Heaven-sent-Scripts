using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject inventory;
    public GameObject inventoryCH;
    public bool isInventoryOpened;
    void Start()
    {
        CreateCanvas();
    }
    void Update()
    {
        if (!isInventoryOpened)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                inventory.SetActive(true);
                isInventoryOpened = true;
                InventoryController.instance.UpdatePanelSlots();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G))
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

        CreateShop(myGO);
        CreateInventoryContentHolder(inventory);
        CreateEquipmentFrame(inventory, inventoryCH);
        CreateShopsTexts(inventory);
        inventory.SetActive(false);
        inventoryCH.transform.SetAsLastSibling();


    }
    public void CreateShop(GameObject canvas)
    {
        GameObject inv = new GameObject();
        inv.name = "Inventory";
        inv.tag = "GUI";
        UnityEngine.UI.Image img = inv.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = inv.GetComponent<RectTransform>();
        inv.transform.parent = canvas.transform;
        rect.sizeDelta = new Vector2(0.3f * Screen.width, 0.6f * Screen.height);
        rect.localPosition = new Vector3(0.4f * Screen.width * -0.6f, Screen.height * 0.05f, 0);

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
    }
    public void SetupButtonOnClick(UnityEngine.UI.Button btn, GameObject scroll)
    {
        btn.onClick.AddListener(delegate { ButtonClicked(scroll); });
    }

    public void ButtonClicked(GameObject obj)
    {
        if (!obj.activeSelf)
            obj.SetActive(true);
        else
            obj.SetActive(false);
    }
    public GameObject CreateEquipmentFrame(GameObject inv, GameObject invCH)
    {
        GameObject eq = new GameObject();
        eq.name = "Equipment";
        eq.tag = "GUI";
        UnityEngine.UI.Image img = eq.AddComponent<UnityEngine.UI.Image>();
        RectTransform rect = eq.GetComponent<RectTransform>();
        eq.transform.parent = inv.transform;
        rect.sizeDelta = new Vector2(inv.GetComponent<RectTransform>().sizeDelta.x, 0.75f * inv.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(/*1 / 6f * inv.GetComponent<RectTransform>().sizeDelta.x*/0,0/* 0.25f * inv.GetComponent<RectTransform>().sizeDelta.y*/, 0);

        //img.sprite = Resources.Load<Sprite>("bar_ready"); 
        var tex = Resources.Load<Texture2D>("bar_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;

        CreateEquipmentImage(eq);
        int tmp = 0;
        for (int i = 0; i < 4; i++)
        {
            string type = EquipmentSlotTypeNameSwitcher(i);
            InventoryController.instance.shopButtons[i] = CreateShopButtons(eq, -0.3375f, 0.3375f - (i * 0.225f), type, "ShopButton " + (i + 1), invCH).GetComponent<ShopButtonController>();
            tmp++;
        }
        for (int i = tmp; i < 8; i++)
        {
            string type = EquipmentSlotTypeNameSwitcher(i);
            InventoryController.instance.shopButtons[i] = CreateShopButtons(eq, 0.3375f, 0.3375f - ((i - 4) * 0.225f), type, "ShopButton " + (i + 1), invCH).GetComponent<ShopButtonController>();
        }
        return eq;
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
    public void CreateShopsTexts(GameObject shop)
    {
        GameObject go = new GameObject();
        go.name = "Text";
        go.tag = "GUI";
        Text txt = go.AddComponent<Text>();
        txt.font = (Font)Resources.Load("NewRocker-Regular");
        txt.fontSize = 25;
        txt.text = "Click button to buy";
        txt.alignment = TextAnchor.MiddleCenter;
        txt.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = shop.transform;
        rect.sizeDelta = new Vector2(shop.GetComponent<RectTransform>().sizeDelta.x, 0.2f * shop.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(0, 0.43f * shop.GetComponent<RectTransform>().sizeDelta.y, 0);
        GameObject go1 = new GameObject();
        go1.name = "Text";
        go1.tag = "GUI";
        Text txt1 = go1.AddComponent<Text>();
        txt1.font = (Font)Resources.Load("NewRocker-Regular");
        txt1.fontSize = 25;
        txt1.text = "Each cost: " + (PlayerPrefs.GetInt("PlayerLevel") * 100).ToString();
        txt1.alignment = TextAnchor.MiddleCenter;
        txt1.color = new Color(255, 255, 255, 0.5f);
        RectTransform rect1 = go1.GetComponent<RectTransform>();
        go1.transform.parent = shop.transform;
        rect1.sizeDelta = new Vector2(shop.GetComponent<RectTransform>().sizeDelta.x, 0.2f * shop.GetComponent<RectTransform>().sizeDelta.y);
        rect1.localPosition = new Vector3(0, -0.43f * shop.GetComponent<RectTransform>().sizeDelta.y, 0);
    }
    public GameObject CreateShopButtons(GameObject eq, float x, float y, string type, string name, GameObject invCH)
    {
        //helm - armor - legs - gloves - 
        GameObject go = (GameObject)Instantiate(Resources.Load("ShopButton"));
        UnityEngine.UI.Button btn = go.GetComponent<UnityEngine.UI.Button>();
        UnityEngine.UI.Image img = go.GetComponent<UnityEngine.UI.Image>();
        go.name = name;
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = invCH.transform;
        rect.sizeDelta = new Vector2(0.2f * eq.GetComponent<RectTransform>().sizeDelta.x, 0.2f * eq.GetComponent<RectTransform>().sizeDelta.y);
        rect.localPosition = new Vector3(
            x * eq.GetComponent<RectTransform>().sizeDelta.x /*+ 1 / 6f * invCH.GetComponent<RectTransform>().sizeDelta.x*/,
            y * eq.GetComponent<RectTransform>().sizeDelta.y /*+ 0.25f * invCH.GetComponent<RectTransform>().sizeDelta.y*/, 0);
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

        go.GetComponent<ShopButtonController>().slotType = WeaponSlotTypeSwitcher(type);

        return go;
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
}
