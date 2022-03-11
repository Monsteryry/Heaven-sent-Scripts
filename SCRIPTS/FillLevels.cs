using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillLevels : MonoBehaviour
{
    //public bool isFilled;
    public ToggleManager toggleManager;
    // Start is called before the first frame update
    void Start()
    {
        FillLevelToggles();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(gameObject.activeSelf && !isFilled)
        {
            FillLevelToggles();
            isFilled = true;
        }
        else if (!gameObject.activeSelf && isFilled)
        {
            isFilled = false;
        }
        */
    }
    public void FillLevelToggles()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject t = new GameObject();
            t = (GameObject)Instantiate(Resources.Load("LevelToggle"));
            t.name = "Level " + i;
            t.transform.SetAsLastSibling();
            RectTransform rt = t.GetComponent<RectTransform>();
            Text txt = t.GetComponentInChildren<Text>();
            t.transform.parent = gameObject.transform;
            txt.text = "Level " + (i + 1);
            rt.offsetMax = new Vector2(0, 0 - (i * 50));
            rt.offsetMin = new Vector2(0, 2450 - (i * 50));
            toggleManager.toggles[i] = t.GetComponent<Toggle>();
            //t.GetComponent<Toggle>().onValueChanged.AddListener(value => AccessToStart.instance.ToggleUpdater());
        }
    }
}
