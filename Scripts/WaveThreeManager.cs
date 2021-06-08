using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveThreeManager : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    
    // Update is called once per frame
    void Update()
    {
        var targetPosition = new Vector2(
            Mathf.Clamp(playerObject.transform.position.x,minX,maxX),
            transform.position.y);
        var movementThisFrame = moveSpeed * Time.deltaTime;
        var currentPos = new Vector2(transform.position.x,transform.position.y);
        if(currentPos != targetPosition) {
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,movementThisFrame);
        }
    }
}
