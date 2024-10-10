using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        rb.velocity = new Vector2(-2f, 0f);

        if(transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}
