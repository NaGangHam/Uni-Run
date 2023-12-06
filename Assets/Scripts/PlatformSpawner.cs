using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject plarformPrefab;
    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMix = 2.25f;
    float timeBetSpawn;

    public float yMin = -4.0f;
    public float yMax = 1.5f;
    float xPos = 20f;

    GameObject[] platforms;
    int currentIndex = 0;

    Vector2 poolPosition = new Vector2(0, -25);
    float lastSpawnTime;

    // Start is called before the first frame update
    void Start(){

        platforms = new GameObject[count];

        for(int i = 0; i < count; i++) {
            platforms[i] = Instantiate(plarformPrefab, poolPosition, Quaternion.identity);
        }

        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
        
    }

    // Update is called once per frame
    void Update(){

        if(GameManager.Instance.isGameover) {
            return;
        }
        //Debug.Log(Time.time);

        if(Time.time >= lastSpawnTime + timeBetSpawn) {

            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMix);
            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if(currentIndex >= count) {
                currentIndex = 0;
            }

        }

    }
}
