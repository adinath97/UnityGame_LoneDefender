using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollisions : MonoBehaviour
{
    private float moveSpeed;
    private float VelXMax = 90, VelXMin = -90, VelYMax = -30, VelYMin = -40, VelX, VelY;
    Rigidbody2D Rb;
    void Awake()
    {
        moveSpeed = Random.Range(-8f,-13f);
        Rb = this.GetComponent<Rigidbody2D>();
        VelX = Random.Range(VelXMin,VelXMax);
        VelY = Random.Range(VelYMin,VelYMax);
        Rb.velocity = new Vector2(VelX * Time.fixedDeltaTime,VelY * Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        transform.position += transform.up*moveSpeed*Time.fixedDeltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PlayerLaser") {
            Destroy(other.gameObject);
        }
    }
}
