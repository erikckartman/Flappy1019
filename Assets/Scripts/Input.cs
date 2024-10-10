using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inout : MonoBehaviour
{
    [SerializeField] private Controls joystick;
    private float speed = 15f;

    void Update()
    {
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();

        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * speed * Time.deltaTime;
    }
}
