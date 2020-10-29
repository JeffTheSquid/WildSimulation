using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.UI;

public class CreatureConfigs : MonoBehaviour
{
    [Header("Menu Components")]
    [SerializeField]
    TextMeshProUGUI creatureCountList;

    [Header("Creature Page")]
    [SerializeField]
    TextMeshProUGUI creatureName;
    [SerializeField]
    TextMeshProUGUI creatureStatsDesc;
    [SerializeField]
    TextMeshProUGUI creatureCount;

    [Header("Create Creature")]
    [SerializeField]
    TMP_InputField nameInput;
    [SerializeField]
    TMP_InputField sizeInput;
    [SerializeField]
    TMP_InputField speedInput;
    [SerializeField]
    TMP_InputField mouthSizeInput;
    [SerializeField]
    TMP_InputField armorInput;
    [SerializeField]
    TMP_InputField camoInput;
    [SerializeField]
    Toggle carnivoreInput;
    [SerializeField]
    Toggle herbivoreInput;

    [Header("Panels")]
    [SerializeField]
    GameObject creaturePanel;
    [SerializeField]
    GameObject newCreaturePanel;

    int currentCreatureIndex = 0;
    bool showingNewCreature = false;

    public void SetText()
    {
        SetCurrentCounts();
        SetCreaturePage(currentCreatureIndex);
    }

    void SetCurrentCounts()
    {
        StringBuilder builder = new StringBuilder("");

        foreach(string creatures in Configs.Instance.creatureDict.Keys)
        {
            if(Configs.Instance.creatureCount[Configs.Instance.creatureDict[creatures]] > 0)
            {
                builder.Append(creatures + ": " + Configs.Instance.creatureCount[Configs.Instance.creatureDict[creatures]] + "\n");
            }
        }

        creatureCountList.text = builder.ToString();
    }

    void SetCreaturePage(int i)
    {
        string thisCreature = Configs.Instance.creatureList[i];
        int thisCreatureCount = Configs.Instance.creatureCount[i];

        string[] creatureStats = thisCreature.Split('|');
        creatureName.text = creatureStats[0];
        creatureStatsDesc.text = "Size: " + creatureStats[1] + "\nSpeed: " + creatureStats[2] + "\nMouth Size: " + creatureStats[3] + "\nArmor: " + creatureStats[4] +
            "\nCamo: " + creatureStats[5] + "\nCarnivore: " + creatureStats[6] + "\nHerbivore: " + creatureStats[7] + "\nCOUNT:";
        creatureCount.text = thisCreatureCount.ToString();
    }

    public void IncrementCreatureCount()
    {
        int thisCreatureCount = Configs.Instance.creatureCount[currentCreatureIndex];

        if(thisCreatureCount < 100)
        {
            thisCreatureCount++;
            Configs.Instance.creatureCount[currentCreatureIndex] = thisCreatureCount;
            creatureCount.text = thisCreatureCount.ToString();
            SetCurrentCounts();
        }
    }

    public void DecrementCreatureCount()
    {
        int thisCreatureCount = Configs.Instance.creatureCount[currentCreatureIndex];

        if (thisCreatureCount > 0)
        {
            thisCreatureCount--;
            Configs.Instance.creatureCount[currentCreatureIndex] = thisCreatureCount;
            creatureCount.text = thisCreatureCount.ToString();
            SetCurrentCounts();
        }
    }

    public void IncrementCreaturePage()
    {
        if(currentCreatureIndex < Configs.Instance.creatureList.Count - 1)
        {
            currentCreatureIndex++;
            SetCreaturePage(currentCreatureIndex);
        }
    }

    public void DecrementCreaturePage()
    {
        if (currentCreatureIndex > 0)
        {
            currentCreatureIndex--;
            SetCreaturePage(currentCreatureIndex);
        }
    }

    public void ToggleShowingNewCreature()
    {
        if(showingNewCreature)
        {
            newCreaturePanel.SetActive(false);
            creaturePanel.SetActive(true);

            showingNewCreature = false;
        }
        else
        {
            newCreaturePanel.SetActive(true);
            creaturePanel.SetActive(false);

            showingNewCreature = true;
        }
    }

    public void SaveCreature()
    {
        string thisCreature = nameInput.text + "|" + sizeInput.text + "|" + speedInput.text + "|" + mouthSizeInput.text + "|" + armorInput.text + "|" +
            camoInput.text + "|" + carnivoreInput.isOn + "|" + herbivoreInput.isOn;

        Configs.Instance.creatureDict.Add(nameInput.text, Configs.Instance.creatureList.Count);
        Configs.Instance.creatureList.Add(thisCreature);
        Configs.Instance.creatureCount.Add(0);
    }
}
