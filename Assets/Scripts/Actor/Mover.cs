using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected Vector2 moveDelta;

    public float moveSpeed;
    public bool isMoving;
}
