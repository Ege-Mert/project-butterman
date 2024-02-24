using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceseEnemey : MonoBehaviour
{ 
    public GameObject[] prefabs; // Prefabları bu diziye sürükleyip bırakın
    public float minSpawnTime = 1f; // Minimum spawn zamanı
    public float maxSpawnTime = 5f; // Maximum spawn zamanı

    void Start()
    {
        // Belirli bir aralıkta sürekli yeni prefablar çağırmak için InvokeRepeating kullanılır.
        InvokeRepeating("SpawnPrefab", Random.Range(minSpawnTime, maxSpawnTime), Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnPrefab()
    {
        // Rastgele bir prefab seçmek için Random.Range kullanılır.
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];
        // Prefabı kendi konumunda oluşturmak için Instantiate kullanılır.
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}
