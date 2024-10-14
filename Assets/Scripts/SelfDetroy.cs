using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDetroy : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.z < -10)
        {
            Destroy(gameObject);
        }        
    }
}
