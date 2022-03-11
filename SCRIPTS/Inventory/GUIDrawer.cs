using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIDrawer : MonoBehaviour
{
    public Rect spellButtonRect;
    public SpecialAttack[] spells;
    public string[] buttonText;
    public GUIStyle style;
    public GUIContent content0;
    public GUIContent content1;
    public GUIContent content2;
    public GUIContent content3;
    public GUIContent content4;
    public GUIContent content5;
    public bool cooldownReset;
    public float[] timer;
    void Awake()
    {
        style = new GUIStyle();
        content0 = new GUIContent();
        content1 = new GUIContent();
        content2 = new GUIContent();
        content3 = new GUIContent();
        content4 = new GUIContent();
        content5 = new GUIContent();
        //spells = new SpecialAttack[6];
        cooldownReset = true;
        spellButtonRect = new Rect(Screen.width / 2 - 180, Screen.height * 0.9f, 60, 60);
    }
    // Start is called before the first frame update
    void Start()
    {
        spells = GameObject.Find("pc").GetComponents<SpecialAttack>();
        timer = new float[spells.Length];
    }

    public void SwitcherA(int i)
    {
        switch(i)
        {
            case 0:
                content0.text = Mathf.Ceil(timer[i]).ToString();
                break;
            case 1:
                content1.text = Mathf.Ceil(timer[i]).ToString();
                break;
            case 2:
                content2.text = Mathf.Ceil(timer[i]).ToString();
                break;
            case 3:
                content3.text = Mathf.Ceil(timer[i]).ToString();
                break;
            case 4:
                content4.text = Mathf.Ceil(timer[i]).ToString();
                break;
            case 5:
                content5.text = Mathf.Ceil(timer[i]).ToString();
                break;
            default:
                break;
        }
    }
    public void SwitcherB(int i)
    {
        switch (i)
        {
            case 0:
                content0.text = "LMB";
                break;
            case 1:
                content1.text = "RMB";
                break;
            case 2:
                content2.text = spells[i].key.ToString();
                break;
            case 3:
                content3.text = spells[i].key.ToString();
                break;
            case 4:
                content4.text = spells[i].key.ToString();
                break;
            case 5:
                content5.text = spells[i].key.ToString();
                break;
            default:
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //zrobic dla kazdego z osobna
        //dostosowac - poprawic animacje
        //umiejki
        //timerow tyle co contentow
        for (int i = 0; i < spells.Length; i++)
        {
            if (Input.GetKeyDown(spells[i].key) && spells[i].isReady)
            {
                timer[i] = spells[i].cooldown;
                spells[i].isReady = false;
            }
            if (timer[i] > 0)
            {
                SwitcherA(i);
                timer[i] -= Time.deltaTime;
            }
            if (timer[i] < 0)
                timer[i] = 0;
            if (timer[i] == 0)
            {
                timer[i] = 0;
                spells[i].isReady = true;
                SwitcherB(i);
                //cooldownReset = true;
            }
        }







        //Debug.Log(Time.deltaTime);
        //Debug.Log(spellbtn.width + " " + spellbtn.height + " " + spellbtn.x + " " + spellbtn.y);
        //Debug.Log(Screen.width + " " + Screen.height);

        //for (int i = 0; i <= 5; i++)
        // ShowCooldownOnClick(0);
        //Debug.Log(content.text);
        //content.text = timer.ToString();
    }

    public void ShowCooldownOnClick(int i)
    {
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
            //Debug.Log(content.text);
            //AdjustContent(timer,i);
        //}
    }

    /*public void OnGUI()
    {
        Rect rect = new Rect(spellButtonRect.x + (60 * 0), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(0);
        GUI.Button(rect, content0, style);

        rect = new Rect(spellButtonRect.x + (60 * 1), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(1);
        GUI.Button(rect, content1, style);

        rect = new Rect(spellButtonRect.x + (60 * 2), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(2);
        GUI.Button(rect, content2, style);

        rect = new Rect(spellButtonRect.x + (60 * 3), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(3);
        GUI.Button(rect, content3, style);

        rect = new Rect(spellButtonRect.x + (60 * 4), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(4);
        GUI.Button(rect, content4, style);

        rect = new Rect(spellButtonRect.x + (60 * 5), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
        AdjustStyle(5);
        GUI.Button(rect, content5, style);
    */
    //spells = GameObject.Find("pc").GetComponents<SpecialAttack>();
    //for (int i = 0; i <= 5; i++)
    //{
    //Rect rect = new Rect(spellButtonRect.x + (60 * i), spellButtonRect.y, spellButtonRect.width, spellButtonRect.height);
    //AdjustStyle(i);
    //GUI.Button(rect, content0, style);
    /*if (GUI.Button(rect, content, style))
    {
        PlayerController.isGUIClicked = true;
        if (cooldownReset)
        {
            cooldownReset = false;
            AdjustContent(i);
        }
        if (Input.GetMouseButtonUp(0))
            PlayerController.isGUIClicked = false;
    }*/
    //}
//}
public void AdjustContent(float timer, int i)
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
            timer = 0;
        if (timer == 0)
        {
            //content.text = "";
            //cooldownReset = true;
        }
    }
    public void AdjustStyle(int i)
    {
        style.normal.background = spells[i].icon;
        style.active.textColor = Color.black;
        style.normal.textColor = Color.white;
        style.border = new RectOffset(5, 5, 5, 5);
        style.font = (Font)Resources.Load("NewRocker-Regular");
        style.fontSize = 20;
        style.alignment = TextAnchor.MiddleCenter;
        //
        //style.active.background = spells[i].icon;
    }

    /*
    public void CreateCanvas()
    {
        GameObject myGO;
        GameObject myText;
        Canvas myCanvas;
        Text text;
        RectTransform rectTransform;

        // Canvas
        myGO = new GameObject();
        myGO.name = "GUICanvas";
        myGO.AddComponent<Canvas>();

        myCanvas = myGO.GetComponent<Canvas>();
        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        myGO.AddComponent<CanvasScaler>();
        myGO.AddComponent<GraphicRaycaster>();

        // Text
        myText = new GameObject();
        myText.transform.parent = myGO.transform;
        myText.name = "wibble";

        text = myText.AddComponent<Text>();
        text.font = (Font)Resources.Load("NewRocker-Regular");
        text.text = "";
        text.fontSize = 15;

        // Text position
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(400, 200);
        AdjustButtons(myGO);


    }
    public void AdjustButtons(GameObject canvas)
    {
        RectTransform rtCanvas = canvas.GetComponent<RectTransform>();
        for (int i = 0; i <= 5; i++)
        {
            GameObject go = new GameObject();
            go.name = "SpellButton" + i.ToString();
            go.AddComponent<Button>();
            go.AddComponent<Image>();
            go.GetComponent<Image>().sprite = spells[i].icon;
            RectTransform rt = go.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(60, 60);
            rt.anchoredPosition = new Vector2((rtCanvas.sizeDelta.x / 2 - 180) + (60 * i), rtCanvas.sizeDelta.y * 0.1f);
            go.transform.parent = canvas.transform;
        }
    }*/
}
