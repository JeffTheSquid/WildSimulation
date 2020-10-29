using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Creature : MonoBehaviour, Eatable
{
    /*
     *  CREATURE ATTRIBUTES
     *  These stats define each creatures ability to eat. As each stat increases, the creatures metabolism also
     *  increases. This requires the creature to eat more food to stay alive. Once stomach fill reaches 0, 
     *  the creature starts starving to death. If the creature can get above 1/2 full once its mating interval is
     *  reached, it will reproduce a certain number of like-bodied creatures with random genetic alterations. 
     *  Each trait has a 20% chance to increase, 20% chance to decrease, or 60% chance of staying the same. Camo and
     *  armor have a chance of increasing/decreasing up to 5 points per generation. All attributes are within 10% of 
     *  the parents genes and the child has a 2% chance of becoming an omnivore. Creatures have a 5% chance to have 
     *  1 extra or 1 fewer baby. Carnivores can not eat their parents or children.
     */

    //General Attributes
    [SerializeField]
    bool isStarter;
    [SerializeField]
    string type;            //This creatures species
    [SerializeField]
    int generation;
    [SerializeField]
    float size;             //No bounds, defines the size, stomach size, health, mating interval, and baby count of the creature
    [SerializeField]
    float health;           //Derivative of size (5 * size), defines amount of health this creature has left (health = predator food)
    [SerializeField]
    float matingInterval;   //Derivative of size, defines amount of time between births
    [SerializeField]
    int babyCount;          //Derivative of size, defines amount of babies in a birth
    [SerializeField]
    float speed;            //No bounds, defines the speed of this creature

    //Attack Attributes
    //[SerializeField]      //Removed arm length for increased simplicity & since it should be redundant
    //float armLength;      //No bounds, defines the length of this creatures arms to pull food to its mouth
    [SerializeField]
    float mouthSize;        //No bounds, defines the speed at which this creature can eat food

    //Defense Attributes
    [SerializeField]
    float armor;            //Ranges 0-100, defines the speed at which this creature can be eaten (0 is instantaneous, 100 is very slow)
    [SerializeField]
    float camo;             //Ranges 0-100, defines the probability of a predator spotting this creature (0 is certain, 100 is very unlikely)

    //Appetite Attributes
    [SerializeField]
    bool isCarnivore;       //Defines whether this creature can eat other creatures
    [SerializeField]
    bool isHerbivore;       //Defines whether this creature can eat apples


    //Stomach Attributes
    [SerializeField]
    float stomachSize;      //Derivative of size, defines the amount of food this creature can have in its stomach
    [SerializeField]
    float stomachFill;      //Defines the amount of food currently in this creatures stomach
    [SerializeField]
    float metabolism;       //Derivative of all stats above, defines how fast this creatures stomach drains

    //Family Variables
    Creature parent;
    List<Creature> children = new List<Creature>();

    //Part References
    [SerializeField]
    GameObject mouth;
    [SerializeField]
    GameObject body;
    [SerializeField]
    GameObject[] legs;

    //Eating Variables
    [SerializeField]
    GameObject targetFood;
    Eatable targetEatable;
    [SerializeField]
    List<GameObject> objectsInMouth = new List<GameObject>();
    [SerializeField]
    bool isEating = false;

    //Turning Vectors
    Vector3 targetDirection;
    Vector3 newDirection;

    //Mating Variables
    [SerializeField]
    bool readyToReproduce = false;
    [SerializeField]
    float reproduceCooldownTimer = 0;

    //Health, Stomach, & Reproduce Bars
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    Slider stomachSlider;
    [SerializeField]
    Slider reproduceSlider;
    [SerializeField]
    TextMeshProUGUI nametag;
    

    //Basically the constructor, will be called by parent on birth to define this creatures attributes
    public void DefineAttributes(Creature p, string t, int g, float si, float sp, float ms, float ar, float cm, bool c, bool h)
    {
        parent = p;
        type = t;
        generation = g;
        size = si;
        speed = sp;
        //armLength = al;
        mouthSize = ms;
        armor = ar;
        camo = cm;
        isCarnivore = c;
        isHerbivore = h;

        //Derive attributes
        health = size * 5;
        matingInterval = size * Configs.Instance.matingIntervalMultiplier + 5;
        babyCount = Mathf.CeilToInt(12f / size * Configs.Instance.babyMultiplier);
        stomachSize = size * Configs.Instance.stomachSizeMultiplier;
        stomachFill = stomachSize * Configs.Instance.birthStomachFill;

        float warmBloodedAdd = 0;
        if (isCarnivore)
        {
            warmBloodedAdd = Configs.Instance.warmBloodedPenalty;
        }
        metabolism = ((size * Configs.Instance.sizeMetabolismWeight) + (speed * Configs.Instance.speedMetabolismWeight) + (mouthSize * Configs.Instance.mouthMetabolismWeight) + 
            (Mathf.CeilToInt(armor / 3f) * Configs.Instance.armorMetabolismWeight) + (Mathf.CeilToInt(camo / 3f) * Configs.Instance.camoMetabolismWeight) + warmBloodedAdd)
            / Configs.Instance.metabolismReductionConstant;
        //Arm length multilier: 2


        //Handle Appearance
        transform.localScale = new Vector3(size / 12f, size / 12f, size / 12f);
        mouth.transform.localScale = new Vector3(mouthSize / 10f, .4f, .2f);

        if(isHerbivore && isCarnivore)
        {
            SetMaterial(Configs.Instance.omnivoreMat);
        }
        else if(isHerbivore)
        {
            SetMaterial(Configs.Instance.herbivoreMat);
        }
        else
        {
            SetMaterial(Configs.Instance.carnivoreMat);
        }

        nametag.text = "(" + (generation + 1) + ") " + type;
    }

    //Helper function to help color creature
    void SetMaterial(Material mat)
    {
        MeshRenderer temp = body.GetComponent<MeshRenderer>();

        temp.material = new Material(mat);
        temp.material.SetFloat("_Metallic", armor / 100f);
        temp.material.SetFloat("_Glossiness", armor / 100f);

        temp = mouth.GetComponent<MeshRenderer>();
        temp.material = new Material(mat);
        temp.material.SetFloat("_Metallic", armor / 100f);
        temp.material.SetFloat("_Glossiness", armor / 100f);

        foreach (GameObject leg in legs)
        {
            temp = leg.GetComponent<MeshRenderer>();
            temp.material = new Material(mat);
            temp.material.SetFloat("_Metallic", armor / 100f);
            temp.material.SetFloat("_Glossiness", armor / 100f);
        }
    }

    //Called every frame
    private void Update()
    {
        if(Configs.Instance.simStarted)
        {
            //Remove destroyed objects from mouth
            CheckMouth();

            //Locate nearest food
            //FindFood();

            if (!targetFood && stomachFill / stomachSize < Configs.Instance.satisfiedHunger)
            {
                //Locate food (not necessarily closest)
                FindFood();
            }

            if (targetFood)
            {
                //If food is found either move towards it or eat it if close enough
                EatOrMove();
            }

            //Slowly depletes stomach
            DepleteStomach();

            //Reproduce logic
            UpdateReproduceTimer();

            //Update health bars
            UpdateBars();
        }
    }

    void UpdateBars()
    {
        healthSlider.value = health / (size * 5);
        stomachSlider.value = stomachFill / stomachSize;
        reproduceSlider.value = reproduceCooldownTimer / matingInterval;
    }

    void CheckMouth()
    {
        try
        {
            foreach (GameObject go in objectsInMouth)
            {
                if (!go)
                {
                    objectsInMouth.Remove(go);
                }
            }
        }
        catch(System.Exception e)
        {

        }
    }

    //Finds the nearest food
    void FindFood()
    {
        List<GameObject> foodList = new List<GameObject>();

        //Add apples if is herbivore
        if (isHerbivore)
        {
            foreach (Apple a in FindObjectsOfType<Apple>())
            {
                foodList.Add(a.gameObject);
            }
        }
        //Add creatures if is carnivore
        if (isCarnivore)
        {
            foreach (Creature c in FindObjectsOfType<Creature>())
            {
                if (c != this && c.getType() != type)
                {
                    //if a creature has 100 camo, they have a very little chance of being added, but still possible
                    if(Random.Range(0, 101f) > c.getCamo())
                    {
                        foodList.Add(c.gameObject);
                    }
                }
            }
        }
        
        if (foodList.Count > 0)
        {
            float shortestDistance = Vector3.Distance(transform.position, foodList[0].transform.position);
            GameObject closestFood = foodList[0];
            foreach (GameObject e in foodList)
            {
                float tempLength = Vector3.Distance(transform.position, e.transform.position);

                //Randomizer is to diversify which food creatures go for, not necessarily the closest
                if (tempLength < shortestDistance && Random.Range(1, 101) < Configs.Instance.closestFoodProb)
                {
                    shortestDistance = tempLength;
                    closestFood = e;
                }
            }

            targetFood = closestFood;
            targetEatable = closestFood.GetComponent<Eatable>();
        }
        
    }

    public float getCamo()
    {
        return camo;
    }

    public string getType()
    {
        return type;
    }

    //Eats food if it is in this creatures mouth, if not then the creature turns and moves towards the nearest food
    void EatOrMove()
    {
        if (objectsInMouth.Count > 0 && objectsInMouth.Contains(targetFood))
        {
            isEating = true;
            float foodIntake = targetEatable.GetEaten(mouthSize);
            stomachFill += foodIntake;
            health += foodIntake * Configs.Instance.healingFromFood;

            if(stomachFill > stomachSize)
            {
                stomachFill = stomachSize;
            }
        }
        else
        {
            isEating = false;
            TurnTo(targetFood);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * Configs.Instance.speedMultiplier);
        }
    }
    
    //Turns the creature to the nearest food;
    void TurnTo(GameObject target)
    {
        targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0;
        newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Configs.Instance.turnSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }


    //If this creature is being eaten by a predator
    public float GetEaten(float bite)
    {
        float biteAmount = (bite * Configs.Instance.creatureConsumptionRate * Time.deltaTime) / (110 / (111 - armor));
        health -= biteAmount;

        if (health <= 0)
        {
            biteAmount += health;
            Destroy(transform.parent.gameObject);
        }
        else
        {
            //Update health bar
        }

        return biteAmount;
    }

    void DepleteStomach()
    {
        stomachFill -= Time.deltaTime * metabolism;

        if(stomachFill <= 0)
        {
            stomachFill = 0;
            health -= Time.deltaTime * ((size * 5f) * (Configs.Instance.healthDrainRate / 100));
            if(health <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    //Called by mouth when food enters
    public void EnterFood(GameObject target)
    {
        if((isHerbivore && target.GetComponent<Apple>() != null) || (isCarnivore && target.GetComponent<Creature>() != null))
        {
            objectsInMouth.Add(target);
        }
    }

    //Called by mouth when food exits
    public void ExitFood(GameObject target)
    {
        if (objectsInMouth.Contains(target))
        {
            objectsInMouth.Remove(target);
        }
    }

    void UpdateReproduceTimer()
    {
        if(!readyToReproduce)
        {
            reproduceCooldownTimer += Time.deltaTime * Configs.Instance.matingMultiplier;

            if(reproduceCooldownTimer >= matingInterval)
            {
                readyToReproduce = true;
            }
        }
        else
        {
            TryReproduce();
        }
    }

    void TryReproduce()
    {
        if(stomachFill > stomachSize * .5f)
        {
            readyToReproduce = false;
            reproduceCooldownTimer = 0;

            float babyRandomizer = Random.Range(0, 1f);
            int tempBabyCount = babyCount;

            if (babyRandomizer <= Configs.Instance.babyCountVolatility)
            {
                if(Random.Range(0, 2) == 1)
                {
                    tempBabyCount = babyCount + 1;
                }
                else
                {
                    tempBabyCount = babyCount - 1;
                }
            }
            
            float alterationRandomizer;
            float attributeOffset;
            float attributeRandomizer;
            for (int i = 0; i < tempBabyCount; i++)
            {
                //
                //SIZE
                //
                alterationRandomizer = Random.Range(0f, 1f);
                float tempSize;
                if(alterationRandomizer < 1 - Configs.Instance.mutationProbability)
                {
                    tempSize = size;
                }
                else
                {
                    attributeRandomizer = Random.Range(0f, Configs.Instance.mutationPercentageChange);
                    attributeOffset = attributeRandomizer * size;

                    int iOrD = Random.Range(0, 2);

                    if(iOrD == 0)
                    {
                        tempSize = size - attributeOffset;

                        if(tempSize <= .1f)
                        {
                            tempSize = .1f;
                        }
                    }
                    else
                    {
                        tempSize = size + attributeOffset;
                    }
                }

                //
                //SPEED
                //
                alterationRandomizer = Random.Range(0f, 1f);
                float tempSpeed;
                if (alterationRandomizer < 1 - Configs.Instance.mutationProbability)
                {
                    tempSpeed = speed;
                }
                else
                {
                    attributeRandomizer = Random.Range(0f, Configs.Instance.mutationPercentageChange);
                    attributeOffset = attributeRandomizer * speed;

                    int iOrD = Random.Range(0, 2);

                    if (iOrD == 0)
                    {
                        tempSpeed = speed - attributeOffset;

                        if (tempSpeed <= .1f)
                        {
                            tempSpeed = .1f;
                        }
                    }
                    else
                    {
                        tempSpeed = speed + attributeOffset;
                    }
                }

                //
                //MOUTH SIZE
                //
                alterationRandomizer = Random.Range(0f, 1f);
                float tempMouthSize;
                if (alterationRandomizer < 1 - Configs.Instance.mutationProbability)
                {
                    tempMouthSize = mouthSize;
                }
                else
                {
                    attributeRandomizer = Random.Range(0f, Configs.Instance.mutationPercentageChange);
                    attributeOffset = attributeRandomizer * mouthSize;

                    int iOrD = Random.Range(0, 2);

                    if (iOrD == 0)
                    {
                        tempMouthSize = mouthSize - attributeOffset;

                        if (tempMouthSize <= .1f)
                        {
                            tempMouthSize = .1f;
                        }
                    }
                    else
                    {
                        tempMouthSize = mouthSize + attributeOffset;
                    }
                }

                //
                //ARMOR
                //
                alterationRandomizer = Random.Range(0f, 1f);
                float tempArmor;
                if(alterationRandomizer < 1 - Configs.Instance.mutationProbability)
                {
                    tempArmor = armor;
                }
                else
                {
                    attributeRandomizer = Random.Range(0f, Configs.Instance.maxArmorChange);

                    int iOrD = Random.Range(0, 2);

                    if (iOrD == 0)
                    {
                        tempArmor = armor - attributeRandomizer;

                        if (tempArmor < 0)
                        {
                            tempArmor = 0;
                        }
                    }
                    else
                    {
                        tempArmor = armor + attributeRandomizer;

                        if (tempArmor > 100)
                        {
                            tempArmor = 100;
                        }
                    }
                }

                //
                //CAMO
                //
                alterationRandomizer = Random.Range(0f, 1f);
                float tempCamo;
                if(alterationRandomizer < 1 - Configs.Instance.mutationProbability)
                {
                    tempCamo = camo;
                }
                else
                {
                    attributeRandomizer = Random.Range(0f, Configs.Instance.maxCamoChange);

                    int iOrD = Random.Range(0, 2);

                    if (iOrD == 0)
                    {
                        tempCamo = camo - attributeRandomizer;

                        if (tempCamo < 0)
                        {
                            tempCamo = 0;
                        }
                    }
                    else
                    {
                        tempCamo = camo + attributeRandomizer;

                        if (tempCamo > 100)
                        {
                            tempCamo = 100;
                        }
                    }
                }

                bool tempHerbivore = isHerbivore;
                if(!isHerbivore)
                {
                    alterationRandomizer = Random.Range(0f, 1f);
                    if(alterationRandomizer < Configs.Instance.omnivoreChance)
                    {
                        tempHerbivore = true;
                    }
                }

                bool tempCarnivore = isCarnivore;
                if (!isCarnivore)
                {
                    alterationRandomizer = Random.Range(0f, 1f);
                    if (alterationRandomizer < Configs.Instance.omnivoreChance)
                    {
                        tempCarnivore = true;
                    }
                }

                GameObject tempBaby = Instantiate(Configs.Instance.creature, transform.position, transform.rotation);
                Creature tempCreature = tempBaby.GetComponentInChildren<Creature>();
                tempCreature.transform.localPosition = Vector3.zero;
                tempCreature.DefineAttributes(this, type, generation, tempSize, tempSpeed, tempMouthSize, tempArmor, tempCamo, tempCarnivore, tempHerbivore);
                children.Add(tempCreature);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
        }
    }
}
