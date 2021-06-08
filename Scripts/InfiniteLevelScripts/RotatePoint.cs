using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePoint : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D Rb;
    
    // Start is called before the first frame update
    void Start()
    {
        Rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Mathf.Atan2(direction.x,direction.y) * Mathf.Rad2Deg;
        Rb.rotation = -angle + 180f;
    }
}
