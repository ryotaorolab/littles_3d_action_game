using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTableTest : MonoBehaviour
{
    // Start is called before the first frame update
    // The directions that the jump table can fly in.
    public enum Direction
    {
        North,
        South,
        East,
        West,
    }
    
    // The jump table itself.
    private Dictionary<Direction, Vector3> jumpTable = new Dictionary<Direction, Vector3>();

    // The current direction that the jump table is facing.
    private Direction currentDirection = Direction.North;

    // The speed of the jump table.
    private float speed = 100f;

    // The function that is called when the jump table is activated.
    public void OnActivate()
    {
        // Get the direction that the jump table is facing.
        Direction direction = currentDirection;

        // Fly in the specified direction.
        transform.position += jumpTable[direction] * Time.deltaTime * speed;
    }

    // Adds a new direction to the jump table.
    public void AddDirection(Direction direction, Vector3 vector)
    {
        jumpTable.Add(direction, vector);
    }

    // Sets the current direction of the jump table.
    public void SetDirection(Direction direction)
    {
        currentDirection = direction;
    }

    // Gets the current direction of the jump table.
    public Direction GetDirection()
    {
        return currentDirection;
    }

    // Gets the speed of the jump table.
    public float GetSpeed()
    {
        return speed;
    }

    // Sets the speed of the jump table.
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    private void Start()
    {
        jumpTable.Add(Direction.East, new Vector3(1,0,0));
    }
}
