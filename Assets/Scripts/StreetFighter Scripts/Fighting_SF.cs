using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting_SF : MonoBehaviour
{
    bool blocking;
    public GameObject attack;
    void Update()
    {
        blocking = false;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(attack, transform.position, Quaternion.identity, transform);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            blocking = true;
        }
        
    }
}
