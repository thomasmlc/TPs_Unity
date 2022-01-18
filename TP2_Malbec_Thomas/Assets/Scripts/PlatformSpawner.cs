using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    
    IEnumerator Start()
    {
        GameObject firstPlatform = Instantiate(platform);
        firstPlatform.transform.position = new Vector2(0,0);
        
        GameObject secondPlatform = Instantiate(platform);
        secondPlatform.transform.position = new Vector2(8, 2);
        
        yield return StartCoroutine("SpawnPlatform");
    }

    IEnumerator SpawnPlatform()
    {
        while (true)
        {
            GameObject newPlatform = Instantiate(platform);
            newPlatform.transform.position = new Vector2(16.0f + Random.Range(-1.0f, 4.0f),  Random.Range(-3.0f, 3.0f));
            yield return new WaitForSeconds(2.0f);
        }
        
    }
}
