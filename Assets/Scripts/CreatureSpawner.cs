using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject spawner;

    public void Spawn()
    {
        foreach (string type in Configs.Instance.creatureDict.Keys)
        {
            string[] tempAttributes = Configs.Instance.creatureList[Configs.Instance.creatureDict[type]].Split('|');

            for (int i = 0; i < Configs.Instance.creatureCount[Configs.Instance.creatureDict[type]]; i++)
            {
                transform.localRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
                spawner.transform.localPosition = new Vector3(0, 0, Random.Range(2f, 35f));
                GameObject tempCreature = Instantiate(Configs.Instance.creature, spawner.transform.position, Quaternion.identity);

                tempCreature.GetComponentInChildren<Creature>().DefineAttributes(null, type, 0, float.Parse(tempAttributes[1]), float.Parse(tempAttributes[2]),
                    float.Parse(tempAttributes[3]), float.Parse(tempAttributes[4]), float.Parse(tempAttributes[5]), bool.Parse(tempAttributes[6]),
                    bool.Parse(tempAttributes[7]));
            }
        }
    }
}