using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Meteor : MonoBehaviour
{
    private float size;
    private float direction;
    private Rigidbody rb;
    [SerializeField] private Transform player;

    private void Awake()
    {
        size = Random.Range(0.1f, 5f);
        transform.localScale = new Vector3(size, size, size);
        
        if(transform.position.y > player.position.y)
        {
            direction = Random.Range(-3f, -0.1f);
        }
        else
        {
            direction = Random.Range(0.1f, 3f);
        }

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float speed = Random.Range(1f, 3f);
        rb.velocity = new Vector3(-3f * speed, direction, 0f);
    }
}
