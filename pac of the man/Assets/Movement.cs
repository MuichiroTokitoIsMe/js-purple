using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float speed;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    protected Rigidbody2D rb;
    protected Vector2 direction;
    protected Vector2 nextDirection;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = initialDirection;
        nextDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    // Update is called once per frame

    private bool Occupied(Vector2 NewDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, NewDirection, 1.5f, obstacleLayer);
        return hit.collider != null;
    }

    protected void Setdirection(Vector2 newDirection)
    {
        if (!Occupied(newDirection))
        {
            direction = newDirection;
            nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = newDirection;
        }
    }
    void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            Setdirection(nextDirection);
        }

        ChildUpdate();

    }
    abstract protected void ChildUpdate();
}
