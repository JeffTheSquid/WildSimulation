using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configs : MonoBehaviour
{
    private static Configs _instance;

    public static Configs Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public bool simStarted = false;

    //Creature appearance configs
    public GameObject creature;
    public Material herbivoreMat;
    public Material carnivoreMat;
    public Material omnivoreMat;

    //WORLD CONFIGS
    public float environmentSize = 5f;
    public int   startingAppleCount = 20;
    public float appleMinSeconds = 1f;
    public float appleMaxSeconds = 3f;

    //METABOLISM CONFIGS
    public float stomachSizeMultiplier = 20f;
    public float birthStomachFill = .75f;
    public float metabolismReductionConstant = 22f;
    public float warmBloodedPenalty = 20f;

    public float sizeMetabolismWeight = 4f;
    public float speedMetabolismWeight = 3f;
    public float mouthMetabolismWeight = 2f;
    public float armorMetabolismWeight = 1f;
    public float camoMetabolismWeight = 1f;
    
    //EATING CONFIGS
    public float creatureConsumptionRate = 3f;
    public float closestFoodProb = 60f;
    public float healthDrainRate = 5f;
    public float satisfiedHunger = .95f;
    public float healingFromFood = .5f;

    //REPRODUCTION CONFIGS
    public float matingMultiplier = 1f;
    public float matingIntervalMultiplier = 1.5f;
    public float babyMultiplier = 1f;
    public float babyCountVolatility = .2f;
    public float reproduceStomachFill = .5f;

    //MUTATION CONFIGS
    public float mutationProbability = .6f;
    public float mutationPercentageChange = .1f;
    public float omnivoreChance = .2f;
    public float maxArmorChange = 5f;
    public float maxCamoChange = 5f;
    
    //SPEED CONFIGS
    public float turnSpeed = 7f;
    public float speedMultiplier = 2f;

    //Creatures map from name to place in array
    public Dictionary<string, int> creatureDict = new Dictionary<string, int>();
    public List<string> creatureList = new List<string>();
    public List<int> creatureCount = new List<int>();
    public CreatureSpawner cSpawn;

    private void Start()
    {
        //Default creatures (type|size|speed|mouthSize|armor|camo|isCarni|isHerbi)
        //Omnivores
        creatureList.Add("Human|40|5|7|0|0|true|true");
        creatureList.Add("Mouse|5|4|1|0|0|true|true");

        //Herbivores
        creatureList.Add("Armadillo|8|4|2|50|0|false|true");
        creatureList.Add("Elephant|100|3|15|15|0|false|true");
        creatureList.Add("Chameleon|12|4|4|0|80|false|true");
        creatureList.Add("Zebra|60|12|9|0|20|false|true");
        creatureList.Add("Tortoise|45|2|3|100|0|false|true");

        //Carnivores
        creatureList.Add("Spider|3|10|1|0|0|true|false");
        creatureList.Add("Wolf|20|8|6|50|0|true|false");
        

        for(int i = 0; i < creatureList.Count; i++)
        {
            creatureDict.Add(creatureList[i].Split('|')[0], i);
            creatureCount.Add(0);
        }
    }

    public void SetCreatureCount(string type, int count)
    {
        creatureCount[creatureDict[type]] = count;
    }
}
