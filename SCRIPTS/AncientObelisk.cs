using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AncientObelisk : MonoBehaviour
{
    public GameObject canvas;
    public GameObject panel;
    public GameObject[] levelButtons = new GameObject[50];

    public bool isDungeonPanelOpened;
    public GameObject dungeonPanel;

    public List<Toggle> togglesOn;
    public List<Toggle> togglesOff;
    public List<Toggle> toggles;
    public Toggle toggleOn;
    /*
    public void CreateCanvas()
    {
        GameObject go;
        Canvas c;
        Text text;
        RectTransform rectTransform;

        // Canvas
        go = new GameObject();
        go.name = "GUICanvas";
        go.tag = "GUI";
        go.AddComponent<Canvas>();

        c = go.GetComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        go.AddComponent<CanvasScaler>();
        go.AddComponent<GraphicRaycaster>();
        canvas = go;
    }
    public void CreateDungeonPanel(GameObject canvas)
    {
        GameObject go = new GameObject();
        go.name = "Inventory";
        go.tag = "GUI";
        Image img = go.AddComponent<Image>();
        RectTransform rect = go.GetComponent<RectTransform>();
        go.transform.parent = canvas.transform;
        rect.sizeDelta = new Vector2(0.3f * Screen.width, 0.6f * Screen.height);
        rect.localPosition = new Vector3(0, 0, 0);
        var tex = Resources.Load<Texture2D>("bar_ready");
        var sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        img.sprite = sprite;
        panel = go;
    }
    void OnMouseClick()
    {
        CreateCanvas();
    }
    void DestroyCanvasIfMoveOrClickX()
    {
        if (true)
        Destroy(canvas); 
    }*/
    /* Dungeon banner
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
     */


    /* Start button
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
        btn.color = new Color(255, 255, 255, 0.5f);
        //RectTransform rect = go.GetComponent<RectTransform>();
        //go.transform.parent = stats.transform;
        //rect.sizeDelta = new Vector2(stats.GetComponent<RectTransform>().sizeDelta.x, 0.2f * stats.GetComponent<RectTransform>().sizeDelta.y);
        //rect.localPosition = new Vector3(0, -0.40f * stats.GetComponent<RectTransform>().sizeDelta.y, 0);
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
    */
    /* Scroll view
    public GameObject CreateStatsScroll(GameObject inv)
    {
        //is it has to be scroll?

        //change stats to inv cuz height and width will be calculated from inv's values
        GameObject scroll = (GameObject)Instantiate(Resources.Load("Scroll View"));
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
    }
    */


    // Start is called before the first frame update
    void Start()
    {
        //CreateDungeonPanel();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDungeonPanelOpened)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                dungeonPanel.SetActive(true);
                isDungeonPanelOpened = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                dungeonPanel.SetActive(false);
                isDungeonPanelOpened = false;
            }
        }
    }
    public void CreateDungeonPanel()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("DungeonCanvas"));
        dungeonPanel = go;
        isDungeonPanelOpened = false;
        dungeonPanel.SetActive(false);
    }
    /*
    private void SetToggle()
    {
        foreach (Toggle t in togglesOff)
        {
            if (t.isOn == true && !togglesOn.Contains(t))
                togglesOn.Add(t);
            if (togglesOn.Count > 1)
            {
                togglesOn[0].isOn = false;
                togglesOn.RemoveAt(0);
            }
        }
        foreach (Toggle t in togglesOff)
        {
            if (t.isOn == true && toggleOn != t))
                toggleOn = t;
            if (togglesOn.Count > 1)
            {
                togglesOn[0].isOn = false;
                togglesOn.RemoveAt(0);
            }
        }
    }
    private void SetToggle2()
    {
        foreach (Toggle t in toggles)
        {
            if (t.isOn == true && toggleOn != t)
                toggleOn = t;

            if (togglesOn.Count > 1)
            {
                togglesOn[0].isOn = false;
                togglesOn.RemoveAt(0);
            }
        }
    }*/
}
