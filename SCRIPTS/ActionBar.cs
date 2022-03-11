using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBar : MonoBehaviour
{
    public GameObject[] actionButtons;
    public Texture2D actionBar;
    public Rect position;
    public int numberOfSkills;
    public SkillSlot[] skills;
    public float skillX;
    public float skillY;
    public float skillWidht;
    public float skillHeight;
    public float skillDistance;
    // Start is called before the first frame update
    void Start()
    {
        skills = new SkillSlot[numberOfSkills];
        Initialize();
    }
    void Initialize()
    {
        //SpecialAttack[] attacks = GameObject.FindGameObjectWithTag("Player").GetComponents<SpecialAttack>();

        /*
        for(int i = 0; i < attacks.Length; i++)
        {
            skills[i] = new SkillSlot();
            skills[i].skill = attacks[i];
        }*/

        //skills[0].setKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill1","Q")));
        //skills[1].setKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill2", "W")));
        //skills[2].setKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill3", "E")));
        //skills[3].setKey((KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Skill4", "R")));
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateSkillSlots();
    }
    /*
    void UpdateSkillSlots()
    {
        for(int count = 0; count < skills.Length; count++)
        {
            skills[count].position.Set(skillX + count * (skillWidht + skillDistance), skillY,skillWidht ,skillHeight);
        }
    }*/

    void OnGUI()
    {
        //DrawActionBar();
        //DrawSkillSlots();
    }
    void DrawSkillSlots()
    {
        for (int count = 0; count < skills.Length; count++)
        {
            //GUI.DrawTexture(GetScreenRect(skills[count].position), skills[count].skill.icon);
        }
    }
    Rect GetScreenRect(Rect position)
    {
        return new Rect(Screen.width * position.x, Screen.height * position.y, Screen.width * position.width, Screen.height * position.height);
    }
    void DrawActionBar()
    {
        //GUI.DrawTexture(GetScreenRect(position),actionBar);
    }
}
