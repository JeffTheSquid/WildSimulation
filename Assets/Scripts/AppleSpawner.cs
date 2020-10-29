using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject apple;
    [SerializeField]
    GameObject spawner;
    

    public void StartSpawner()
    {
        int startingAppleCount = Configs.Instance.startingAppleCount;

        for(int i = 0; i < startingAppleCount; i++)
        {
            SpawnApple();
        }

        StartCoroutine("SpawnAppleTimer");
    }

    void SpawnApple()
    {
        transform.localRotation = Quaternion.Euler(0, Random.Range(0f, 360f), 0);
        spawner.transform.localPosition = new Vector3(0, 0, Random.Range(2f, 35f));
        Instantiate(apple, spawner.transform.position, Quaternion.Euler(Random.Range(0,360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    IEnumerator SpawnAppleTimer()
    {
        yield return new WaitForSeconds(Random.Range(Configs.Instance.appleMinSeconds, Configs.Instance.appleMaxSeconds));
        SpawnApple();
        StartCoroutine("SpawnAppleTimer");
    }
}
