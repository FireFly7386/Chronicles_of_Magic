using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [HideInInspector]
    public bool canMove;

    public float speedMultiplier = 0.1f;

    float movementX;
    float movementY;

    void Move()
    {
        if (canMove)
        {
            movementX = Input.GetAxis("Horizontal");
            movementY = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(movementX, movementY) * speedMultiplier;
        transform.Translate(movement);
    }

    private void Awake()
    {
        canMove = true;
    }

    void FixedUpdate()
    {
        Move();
    }
}
