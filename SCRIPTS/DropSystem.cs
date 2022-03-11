using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    //należy dodać to, że gdy dropi to losuje przedmiot i jemu przypisuje statystyki wartości itd a nie tworzy nowy, tworzy nowy w oparciu o istniejące w database
    //public Item.Statistics statistics;

    public Item[] items;
    public List<Item> commonItems;
    public List<Item> uncommonItems;
    public List<Item> enhancedItems;
    public List<Item> rareItems;
    public List<Item> mythicItems;
    public List<Item> uniqueItems;
    public float[] rarityDropRates = { 0.1f, 0.05f, 0.01f, 0.005f, 0.001f };//common, enhanced, rare, mythic, unique
    void Start()
    {
        items = Resources.LoadAll("Items", typeof(Item)).Cast<Item>().ToArray();
        FillItemsTabs();
    }
    //
    void FillItemsTabs()
    {
        foreach (var item in items)
        {
            if (item.rarity == "Common")
                commonItems.Add(item);
            else if (item.rarity == "Uncommon")
                uncommonItems.Add(item);
            else if (item.rarity == "Enhanced")
                enhancedItems.Add(item);
            else if (item.rarity == "Rare")
                rareItems.Add(item);
            else if (item.rarity == "Mythic")
                mythicItems.Add(item);
            else if (item.rarity == "Unique")
                uniqueItems.Add(item);
        }
    }

    public void DrawRarityDropRates(int mobType)//call if mob died
    {
        System.Random generator = new System.Random();
        float[] rarityDropRates = new float[] { 0.1f, 0.05f, 0.01f, 0.005f, 0.001f, 0.0005f };
        //int[] randomNumbers = new int[] { generator.Next(1, 5), generator.Next(1, 5) };
        List<int> randomNumbers = new List<int>();
        int numberOfItems;
        switch (mobType)
        {
            case 1://normal 0-2
                rarityDropRates = new float[] { 0.2f, 0.1f, 0.05f, 0.01f, 0.005f, 0.001f };
                numberOfItems = generator.Next(0, 3);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                //randomNumbers = new int[] { generator.Next(1, 5), generator.Next(1, 5) };
                break;
            case 2://elite 1-3
                rarityDropRates = new float[] { 0.5f, 0.4f, 0.3f, 0.2f, 0.1f, 0.05f };
                numberOfItems = generator.Next(1, 4);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                //randomNumbers = new int[] { generator.Next(1, 5), generator.Next(1, 5), generator.Next(1, 5) };
                break;
            case 3://boss 3-5
                rarityDropRates = new float[] { 0.8f, 0.7f, 0.6f, 0.5f, 0.25f, 0.1f };
                numberOfItems = generator.Next(3, 6);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                //randomNumbers = new int[] { generator.Next(1, 5), generator.Next(1, 5), generator.Next(1, 5), generator.Next(1, 5), generator.Next(1, 5) };
                break;
            default:
                break;
        }
        foreach (var num in randomNumbers)
        {
            DropItem(rarityDropRates[num], num);
        }
        //losuj liczbe
        //szansa na kolejno 1-5 jest równa droprejtom
        //zależnie od liczby 1-5 dropi item
        //item jest losowy spośród puli przedmiotów danego stopnie rzadkości

    }
    public void DropItem(float dropRate, int num)//means to drop item on the ground, by collecting it is moved to inv
    {
        System.Random generator = new System.Random();
        if (Random.Range(0.0f, 1.0f) <= dropRate)
        {
            GameObject obj = (GameObject)Instantiate(Resources.Load("DroppedItem"));
            switch (num)
            {
                case 1://common
                    //losowanie przedmiotu
                    int indexOfItem = generator.Next(commonItems.Count); //commonItems[indexOfItem]

                    //ustalić widełki przed dodaniem przedmiotu do pola item poniżej
                    obj.GetComponent<ItemsPickup>().item = commonItems[indexOfItem];
                    //ustawić transform obj względem położenia poległego przeciwnika


                    //GameObject item = Instantiate(obj, transform.position, Quaternion.identity) as GameObject;
                    break;
                case 2://uncommon
                    //losowanie przedmiotu
                    indexOfItem = generator.Next(uncommonItems.Count); //commonItems[indexOfItem]
                    obj.GetComponent<ItemsPickup>().item = uncommonItems[indexOfItem];
                    break;
                case 3://enhanced
                    indexOfItem = generator.Next(enhancedItems.Count); //commonItems[indexOfItem]
                    obj.GetComponent<ItemsPickup>().item = enhancedItems[indexOfItem];
                    break;
                case 4://rare
                    indexOfItem = generator.Next(rareItems.Count); //commonItems[indexOfItem]
                    obj.GetComponent<ItemsPickup>().item = rareItems[indexOfItem];
                    break;
                case 5://mythic
                    indexOfItem = generator.Next(mythicItems.Count); //commonItems[indexOfItem]
                    obj.GetComponent<ItemsPickup>().item = mythicItems[indexOfItem];
                    break;
                case 6://unique
                    indexOfItem = generator.Next(uniqueItems.Count); //commonItems[indexOfItem]
                    obj.GetComponent<ItemsPickup>().item = uniqueItems[indexOfItem];
                    break;
                default:
                    break;
            }
        }
    }
    /*
    public void DrawItem()
    {
        System.Random generator = new System.Random();
        const int probabilityWindow = 30;
        int randomChance = generator.Next();

        if (randomChance < probabilityWindow)
        {
            // spawn
        }
        UnityEngine.Random generator2 = new UnityEngine.Random();
        const int probabilityWindow2 = 30;
        int randomChance2 = generator.Next();

        if (randomChance2 < probabilityWindow2)
        {
            // spawn
        }
    }
    */
    
    public void SetStatCollections()
    {

    }
    public Item LosujPrzedmiot()
    {
        //losuje 0 lub 1, jak 1 to drop, jak 0 to nie//droprate uzależniony od poziomu trudności/poziomu postaci
        System.Random generator = new System.Random();
        if (generator.Next(10) == 1)
        {
            int type = generator.Next(0, 2);
            if (type == 0)
            {
                int armorType = generator.Next(0, 4);
            }
            var item = DrawItemByNumber(type);

            //tworzy przedmiot
            //pozniej dobiera staty
            //Basic
            //Statistics.Statistic[] stats = ChooseStatsCollection(type);
            //Primary
            //Statistics.Statistic[] primaryStats = ChooseStatsCollection(type);
            //Damage
            //Statistics.Statistic[] damageStats = ChooseStatsCollection(type);
            //Resistance
            //Statistics.Statistic[] resistanceStats = ChooseStatsCollection(type);
            //Other
            //Statistics.Statistic[] otherStats = ChooseStatsCollection(type);
            List<int> k = new List<int>();

            //stats[0].curValue = generator.Next(stats[0].minValue, stats[0].maxValue);
            int primaryAmount = generator.Next(1, 3);
            //if (primaryAmount)
            int damageAmount = 0;
            int resistanceAmount = 0;
            int otherAmount = 0;
            NumberOfStatsSwitcher(generator, primaryAmount, out damageAmount, out resistanceAmount, out otherAmount);
            //mamy ilość statystyk określonego typu co dalej?

            //dalej losowanie statystyk - pętla iterująca po ilości wylosowanych statystyk co wyżej
            //przydałoby się tablice dostępnych stat
            //mamy je w statistics
            /*
            for (int i = 0; i < primaryAmount; i++)
            {
                Statistics.Statistic[] stats = Statistics.PrimaryStats;
                int tmp = generator.Next(stats.Length);
                Statistics.Statistic stat = stats[tmp];

                //losuj z Statistics.PrimaryStats;
                //w następnym kroku losuj z tego co zostało
                //może kopia statistics.primarystats i usuwanie z niej w kolejnych krokach wylosowane już staty
            }*/
            List<Statistics.Statistic> aStats = Statistics.ArmorStats;
            List<Statistics.Statistic> wStats = Statistics.WeaponStats;
            List<Statistics.Statistic> pStats = Statistics.PrimaryStats;
            List<Statistics.Statistic> dStats = Statistics.DamageStats;
            List<Statistics.Statistic> rStats = Statistics.ResistanceStats;
            List<Statistics.Statistic> oStats = Statistics.OtherStats;
            for (int i = 0; i < Statistics.PrimaryStats.Count - primaryAmount; i++)
            {
                int tmp = generator.Next(pStats.Count);
                pStats.Remove(pStats[tmp]);
            }
            for (int i = 0; i < Statistics.DamageStats.Count - damageAmount; i++)
            {
                int tmp = generator.Next(dStats.Count);
                dStats.Remove(dStats[tmp]);
            }
            for (int i = 0; i < Statistics.ResistanceStats.Count - resistanceAmount; i++)
            {
                int tmp = generator.Next(rStats.Count);
                rStats.Remove(rStats[tmp]);
            }
            for (int i = 0; i < Statistics.OtherStats.Count - otherAmount; i++)
            {
                int tmp = generator.Next(oStats.Count);
                oStats.Remove(oStats[tmp]);
            }

            /*
            //losuje typ przedmiotu
            //określa zbiór właściowości
            //losuje ilość właściowości
            //losuje wartości właściwości z zakresu min max
            //mnożnik poziomu
            //określa przedmiot względem właściwości
            */

            //tu należy dodać już tablice odfiltrowane
            if (type == 0)
            {
                item.SetStats(aStats);
            }
            else if (type == 1)
            {
                item.SetStats(wStats);
            }
            item.SetStats(pStats);
            item.SetStats(dStats);
            item.SetStats(rStats);
            item.SetStats(oStats);
            return item;
        }
        return null;
    }
    public void NumberOfStatsSwitcher(System.Random generator,
        int prim, out int damageAmount, out int resistanceAmount, out int otherAmount)
    {
        //int damageAmount;
        //int resistanceAmount;
        //int otherAmount;
        switch (prim)
        {
            case 1:
                damageAmount = generator.Next(0, 1);
                resistanceAmount = generator.Next(0, 1);
                otherAmount = 0;
                break;
            case 2:
                damageAmount = generator.Next(1, 2);
                resistanceAmount = 2;
                otherAmount = generator.Next(0, 1);
                break;
            case 3:
                damageAmount = 3;
                resistanceAmount = generator.Next(3, 4);
                otherAmount = generator.Next(2, 3);
                break;
            default:
                damageAmount = 0;
                resistanceAmount = 0;
                otherAmount = 0;
                break;
        }
    }
    public Item DrawItemByNumber(int type)
    {
        switch (type)
        {
            case 0:
                return new Armor();
            case 1:
                return new Weapon();
            case 2:
                return new Rune();
            default:
                return new Rune();
        }
    }
    //////////////////////////////////
    
    public void DropItem(int mobType, Transform t)//call if mob died
    {
        System.Random generator = new System.Random();
        float[] rarityDropRates = new float[] { 0.1f, 0.05f, 0.01f, 0.005f, 0.001f, 0.0005f };
        List<int> randomNumbers = new List<int>();
        int numberOfItems;
        switch (mobType)
        {
            case 1://normal 0-2
                rarityDropRates = new float[] { 0.2f, 0.1f, 0.05f, 0.01f, 0.005f, 0.001f };
                numberOfItems = generator.Next(0, 3);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                break;
            case 2://elite 1-3
                rarityDropRates = new float[] { 0.5f, 0.4f, 0.3f, 0.2f, 0.1f, 0.05f };
                numberOfItems = generator.Next(1, 4);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                break;
            case 3://boss 3-5
                rarityDropRates = new float[] { 0.8f, 0.7f, 0.6f, 0.5f, 0.25f, 0.1f };
                numberOfItems = generator.Next(3, 6);
                for (int i = 0; i < numberOfItems; i++)
                {
                    randomNumbers.Add(generator.Next(1, 6));
                }
                break;
            default:
                break;
        }
        foreach (var num in randomNumbers)
        {
            SelectItemType(rarityDropRates[num], num, t);
        }
    }
    
    public void SelectItemType(float dropRate, int num, Transform t)
    {
        System.Random generator = new System.Random();
        if (Random.Range(0.0f, 1.0f) <= dropRate)
        {
            int indexOfItem;
            GameObject obj = (GameObject)Instantiate(Resources.Load("DroppedItem"), t.position, Quaternion.identity);
            switch (num)
            {
                case 1://common
                    indexOfItem = generator.Next(commonItems.Count);
                    Item item = commonItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                case 2://uncommon
                    indexOfItem = generator.Next(uncommonItems.Count);
                    item = uncommonItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                case 3://enhanced
                    indexOfItem = generator.Next(enhancedItems.Count);
                    item = enhancedItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                case 4://rare
                    indexOfItem = generator.Next(rareItems.Count);
                    item = rareItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                case 5://mythic
                    indexOfItem = generator.Next(mythicItems.Count);
                    item = mythicItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                case 6://unique
                    indexOfItem = generator.Next(uniqueItems.Count);
                    item = uniqueItems[indexOfItem];
                    obj.GetComponent<ItemsPickup>().item = DrawItemStats(item);
                    break;
                default:
                    break;
            }
        }
    }
    
    public Item DrawItemStats(Item item)
    {
        System.Random generator = new System.Random();
        int primaryAmount = generator.Next(1, 3);
        int damageAmount = 0;
        int resistanceAmount = 0;
        int otherAmount = 0;
        NumberOfStatsSwitcher(generator, primaryAmount, out damageAmount, out resistanceAmount, out otherAmount);
        List<Statistics.Statistic> aStats = Statistics.ArmorStats;
        List<Statistics.Statistic> wStats = Statistics.WeaponStats;
        List<Statistics.Statistic> pStats = Statistics.PrimaryStats;
        List<Statistics.Statistic> dStats = Statistics.DamageStats;
        List<Statistics.Statistic> rStats = Statistics.ResistanceStats;
        List<Statistics.Statistic> oStats = Statistics.OtherStats;
        for (int i = 0; i < Statistics.PrimaryStats.Count - primaryAmount; i++)
        {
            int tmp = generator.Next(pStats.Count);
            pStats.Remove(pStats[tmp]);
        }
        for (int i = 0; i < Statistics.DamageStats.Count - damageAmount; i++)
        {
            int tmp = generator.Next(dStats.Count);
            dStats.Remove(dStats[tmp]);
        }
        for (int i = 0; i < Statistics.ResistanceStats.Count - resistanceAmount; i++)
        {
            int tmp = generator.Next(rStats.Count);
            rStats.Remove(rStats[tmp]);
        }
        for (int i = 0; i < Statistics.OtherStats.Count - otherAmount; i++)
        {
            int tmp = generator.Next(oStats.Count);
            oStats.Remove(oStats[tmp]);
        }
        if (item.itemType == "Head" || item.itemType == "Chest" || item.itemType == "Legs" || item.itemType == "Hands" || item.itemType == "Boots")
        {
            item.SetStats(aStats);
        }
        else if (item.itemType == "Weapon")
        {
            item.SetStats(wStats);
        }
        item.SetStats(pStats);
        item.SetStats(dStats);
        item.SetStats(rStats);
        item.SetStats(oStats);
        return item;
    }
}
