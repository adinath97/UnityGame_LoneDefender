using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave5Manager : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;

    Vector2 targetPosition;
    bool reached = false;

    void Start()
    {
        reached = false;
        targetPosition = new Vector2(minX,transform.position.y);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(reached) {
            //Debug.Log("HELLO 4");
            if(targetPosition == new Vector2(minX,transform.position.y)) {
                //Debug.Log("HELLO 5");
                targetPosition = new Vector2( maxX, transform.position.y);
            }
            else if(targetPosition == new Vector2(maxX,transform.position.y)) {
                //Debug.Log("HELLO 6");
                targetPosition = new Vector2( minX, transform.position.y);
            }
            reached = false;
        }
        if(!reached) {
            //Debug.Log("HELLO 1");
            var movementThisFrame = moveSpeed * Time.deltaTime;
            var currentPos = new Vector2(transform.position.x,transform.position.y);
            if(currentPos != targetPosition) {
                //Debug.Log("HELLO 2");
                transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
            }
            if(currentPos == targetPosition) {
                //Debug.Log("HELLO 3");
                reached = true;
            }
        }
    }
}
