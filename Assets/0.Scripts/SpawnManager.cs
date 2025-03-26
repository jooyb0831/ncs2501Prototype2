using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] animalPrefabs;

    public GameObject panelGameOver;

    float xSpawnRange = 10f;
    float zSpawnPos = 20f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private void OnEnable()
    {
        //DestroyOutOfBounds.OnGameOver += DisplayGameOver;
    }

    private void OnDisable()
    {
        //DestroyOutOfBounds.OnGameOver -= DisplayGameOver;
    }
    // Start is called before the first frame update
    void Start()
    {
        //DestroyOutOfBounds.OnGameOver.AddListener(DisplayGameOver);
        panelGameOver.SetActive(false);
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        float x = Random.Range(-xSpawnRange, xSpawnRange);
        Vector3 spawnPos = new Vector3(x, 0, zSpawnPos);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    public void DisplayGameOver()
    {
        panelGameOver.SetActive(true);
        CancelInvoke(nameof(SpawnRandomAnimal));
    }
}
