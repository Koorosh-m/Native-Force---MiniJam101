using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvSpawner : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float meteorSpawnTimer;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds =         screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));    
        StartCoroutine(meteorSpawn());
    }

    private void spawnMeteor(){
        GameObject meteor = Instantiate(meteorPrefab) as GameObject;
        meteor.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 1.2f);
    }

    IEnumerator meteorSpawn() {
        while(true){
            yield return new WaitForSeconds(meteorSpawnTimer);
            spawnMeteor();
        }
        
    }
    void Update()
    {
        
    }
}
