using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathThree : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    [SerializeField] GameObject player;

    Vector2 targetPosition;
    bool reached = false;
   public static bool followPlayer, verticalMotion;

    void Start()
    {
        reached = false;
        verticalMotion = true;
        targetPosition = new Vector2(minX,transform.position.y);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(followPlayer) {
            var targetPosition = new Vector2(
            Mathf.Clamp(player.transform.position.x,minX,maxX),
                transform.position.y);
            var movementThisFrame = moveSpeed * Time.deltaTime;
            var currentPos = new Vector2(transform.position.x,transform.position.y);
            if(currentPos != targetPosition) {
                transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
            }
        }
        else {
            if(reached) {
            ////Debug.Log("HELLO 4");
            if(targetPosition == new Vector2(minX,transform.position.y)) {
                ////Debug.Log("HELLO 5");
                targetPosition = new Vector2( maxX, transform.position.y);
            }
            else if(targetPosition == new Vector2(maxX,transform.position.y)) {
                ////Debug.Log("HELLO 6");
                targetPosition = new Vector2( minX, transform.position.y);
            }
            reached = false;
        }
            if(!reached) {
            ////Debug.Log("HELLO 1");
            var movementThisFrame = moveSpeed * Time.deltaTime;
            var currentPos = new Vector2(transform.position.x,transform.position.y);
            if(currentPos != targetPosition) {
                ////Debug.Log("HELLO 2");
                transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
            }
            if(currentPos == targetPosition) {
                ////Debug.Log("HELLO 3");
                reached = true;
            }
        }
        }
    }
}
