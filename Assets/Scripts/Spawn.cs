using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject pump;
    private Vector2 spawnPosition;
    private float pumpPos = -5f;
    private float pumpPos2;

    [SerializeField] private GameObject rocket;
    private Vector3 spawnRocket;
    private float rocketX;
    private float rocketY;

    [SerializeField] private Transform player;


    private void Start()
    {
        InvokeRepeating("Spawning", 0f, 1.5f);
        InvokeRepeating("Rockets", 0f, 4f);
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

    private void Rockets()
    {
        rocketX = Random.Range(-9f, 9f);
        rocketY = Random.Range(-5f, 5f);

        spawnRocket = new Vector3(rocketX, rocketY, 40f);
        GameObject rocketClone = Instantiate(rocket, spawnRocket, Quaternion.identity);

        Vector3 direction = new Vector3(player.position.x, player.position.y, 0f);
        transform.rotation = Quaternion.LookRotation(direction);

        rocketClone.GetComponent<Rigidbody>().velocity = direction * 5f;
    }
}
