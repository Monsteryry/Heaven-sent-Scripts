using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public GameObject descriptionContent;
    public PlayerController player;
    public Transform cursor;
    public string[] statDictNames = new string[]{ "WeaponStats", "ArmorStats", "PrimaryStats", "DamageStats", "ResistanceStats", "OtherStats" };
    public Text itemName;
    public List<string> statKeysValues;
    public GameObject[] stats;
    public Text additionalInfo;
    public Item item;
    private void OnEnable()
    {
        //player = GameObject.Find("pc").GetComponent<PlayerController>();
        /*gameObject.transform.position = new Vector3
            (
                cursor.position.x - 0.5f * gameObject.transform.position.x,
                cursor.position.y,
                0
                //pozycja kursora jako wyjściowa
                //x = kursor - połowe szerokości desc
                //y = kursor
                //z = 0

            );*/
        if (item)
        {
            if (stats.Length > 0)
            {
                for (int i = 0; i < stats.Length; i++)
                {
                    Destroy(stats[i].gameObject);
                    stats[i] = null;
                }
            }
            statKeysValues.Clear();

            itemName.text = item.itemName;
            //dodać tablice statów do klasy item
            foreach (var sdn in statDictNames)
            {
                if (item.StatsSwitcher(sdn) != null)
                {
                    foreach (var stat in item.StatsSwitcher(sdn))
                    {
                        statKeysValues.Add(stat.Key + "\t" + stat.Value /*+ "\n"*/);
                    }
                }
            }
            //dodać tworzenie nowego obiektu zawierającego component text oraz dodanie wartości po czym usunięcie 
            
            stats = new GameObject[statKeysValues.Count];
            for (int i = 0; i < statKeysValues.Count; i++)
            {
                //wgranie prefab i zmiana pozycji względem i
                GameObject obj = (GameObject)Instantiate(Resources.Load("StatInfo"));
                obj.transform.SetParent(descriptionContent.transform);
                stats[i] = obj;
                stats[i].GetComponent<Text>().text = statKeysValues[i];
                obj.GetComponent<RectTransform>().offsetMax = new Vector2(-17, -(5 + (i * 30))); // new Vector2(-right, -top);
                obj.GetComponent<RectTransform>().offsetMin = new Vector2(0, 315 - (i * 30)); // new Vector2(left, bottom);
                /*
                GameObject obj = new GameObject();
                obj.transform.SetParent(descriptionContent.transform);
                stats[i] = obj.AddComponent<Text>();
                stats[i].text = statKeysValues[i];
                */
                //dodać formatowanie tego tekstu
            }
            additionalInfo.text = item.itemDescription;
        }
    }
}
