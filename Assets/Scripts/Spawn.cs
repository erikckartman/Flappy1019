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
    private Quaternion pumpQ;

    [SerializeField] private GameObject rocket;
    private Vector3 spawnRocket;
    private float rocketX;
    private float rocketY;

    [SerializeField] private Transform player;

    private void Start()
    {
        InvokeRepeating("Spawning", 0f, 4f);
        InvokeRepeating("Rockets", 0f, 6f);
    }

    private void Spawning()
    {
        pumpPos = Random.Range(-7f, -1f);
        pumpPos2 = pumpPos + pump.transform.localScale.y + 2;
        
        pumpQ = Quaternion.Euler(0f, 0f, Random.Range(-20f, 20f));
        spawnPosition = new Vector2(10f, pumpPos);
        Instantiate(pump, spawnPosition, pumpQ);

        spawnPosition = new Vector2(10f, pumpPos2);
        Instantiate(pump, spawnPosition, pumpQ);
    }

    private void Rockets()
    {
        rocketX = Random.Range(-9f, 9f);
        rocketY = Random.Range(-5f, 5f);

        spawnRocket = new Vector3(rocketX, rocketY, player.position.z + 50f);
        GameObject rocketClone = Instantiate(rocket, spawnRocket, Quaternion.identity);

        Vector3 direction = (player.position - rocketClone.transform.position).normalized;

        rocketClone.GetComponent<Rigidbody>().velocity = direction * 5f;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rocketClone.transform.rotation = rotation * Quaternion.Euler(90f, 0f, 0f);
    }
}
