using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject flagPrefab;
    public GameObject chickPrefab;
    public float minDistanceFromPlayer = 10f;
    private float spawnRangeX = 80;
    private float spawnZRange = 90;
    public CharacterControllerMovement playerScript;
    public GameObject player;

    

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(2);
        playerScript = GameObject.Find("Player").GetComponent<CharacterControllerMovement>();
        player = GameObject.FindGameObjectWithTag("Player");




    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Flag").Length == 0 && !playerScript.playerFlag) 
        {
            Instantiate(flagPrefab, GenerateSpawnPosition(), flagPrefab.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        Vector3 position = player.transform.position;
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnZRange, spawnZRange);
        Vector3 calculatedPosition = new Vector3(xPos, 0, zPos);
        if (Vector3.Distance(position,calculatedPosition) < minDistanceFromPlayer )
        {
            return GenerateSpawnPosition(); // recursive method calls itself 
        }
         return calculatedPosition; 
        
    }

    public void SpawnEnemies(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(chickPrefab, GenerateSpawnPosition(), chickPrefab.transform.rotation);
        }
    }
}
