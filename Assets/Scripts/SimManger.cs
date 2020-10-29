using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SimManger : MonoBehaviour
{
    [SerializeField]
    CreatureSpawner cSpawn;
    [SerializeField]
    AppleSpawner aSpawn;
    [SerializeField]
    GameObject environment;
    [SerializeField]
    FlyCamera cam;
    [SerializeField]
    GameObject simPanel;
    [SerializeField]
    TextMeshProUGUI simLog;


    public void SetupSim()
    {
        environment.transform.localScale = new Vector3(Configs.Instance.environmentSize, 1, Configs.Instance.environmentSize);
        cSpawn.Spawn();
        StartCoroutine("SpawnApples");
        StartCoroutine("StartSim");

        simPanel.SetActive(true);
        simLog.text = "The simulation will start shortly...";
    }

    private void Update()
    {
        if (Configs.Instance.simStarted && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator SpawnApples()
    {
        yield return new WaitForSeconds(3f);
        aSpawn.StartSpawner();
    }

    IEnumerator StartSim()
    {
        yield return new WaitForSeconds(6f);
        Configs.Instance.simStarted = true;
        cam.isActive = true;

        simLog.text = "Press \'ESC' to stop the simulation.";
    }
}
