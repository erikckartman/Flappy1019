using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inout : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("That shit works!");

                rb.velocity = new Vector2(0f, 6f);
            }
        }
    }
}
