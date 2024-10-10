using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject pump;
    private Vector2 spawnPosition;
    private float pumpPos = -5f;
    private float pumpPos2;

    private void Start()
    {
        InvokeRepeating("Spawning", 0f, 1.5f);
    }

    private void Spawning()
    {
        pumpPos = Random.Range(-7f, -1f);
        pumpPos2 = pumpPos + pump.transform.localScale.y + 2;
        
        spawnPosition = new Vector2(10f, pumpPos);
        Instantiate(pump, spawnPosition, Quaternion.identity);

        spawnPosition = new Vector2(10f, pumpPos2);
        Instantiate(pump, spawnPosition, Quaternion.identity);
    }
}
