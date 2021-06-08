using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveAtAngle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up*-15f*Time.deltaTime;
    }
}
