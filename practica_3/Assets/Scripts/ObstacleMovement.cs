using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public enum MovementPattern { upDown, side, circle }
    public MovementPattern moveType;

    public float moveSpeed = 2f;  
    public float rangeX = 0f;     
    public float rangeY = 0f;    
    public float rangeZ = 0f;     

    private Vector3 centerPoint;  
    private float timeCounter;    

    private void MovementState()
    {
            timeCounter += Time.deltaTime * moveSpeed;

            switch (moveType)
            {
                case MovementPattern.upDown:
                    MoveUpDown();
                    break;

                case MovementPattern.side:
                    MoveSideToSide();
                    break;

                case MovementPattern.circle:
                    MoveInCircle();
                    break;
            }
    }


    private void MoveUpDown()
    {
        float yOffset = Mathf.Abs(Mathf.Sin(timeCounter)) * rangeY;
        transform.position = new Vector3(centerPoint.x, centerPoint.y + yOffset, centerPoint.z);
    }

    private void MoveSideToSide()
    {
        Vector3 localRight = transform.right;
        float sideMovement = Mathf.Sin(timeCounter) * rangeX;

        Vector3 offset = localRight * sideMovement;
        transform.position = centerPoint + offset;
    }

    private void MoveInCircle()
    {
        float xOffset = Mathf.Cos(timeCounter) * rangeX;
        float zOffset = Mathf.Sin(timeCounter) * rangeZ;
        float yOffset = Mathf.Sin(timeCounter) * rangeY; // Optional vertical bounce while circling
        transform.position = new Vector3(centerPoint.x + xOffset, centerPoint.y + yOffset, centerPoint.z + zOffset);
    }


    void Start()
    {
        centerPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementState();
    }
}
