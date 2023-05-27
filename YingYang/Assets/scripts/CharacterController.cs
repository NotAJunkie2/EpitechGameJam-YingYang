using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D body;
    public float movementSpeed = 275f;
    public float speedMultiplier = 1f;

    public float rotationSpeed = 1f;

    public int side = 0;

    // Private
    private Vector2 movementDirection;
    private Vector2 rotationDirection;
    private Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.processInputs();
    }

    void FixedUpdate() {
        this.Move();
    }

    // Methods
    void processInputs()
    {
        this.getRespawnInput();
        this.computeMovementDirection();
    }

    void computeMovementDirection()
    {
        float moveAxisX = Input.GetAxisRaw("Horizontal");
        float moveAxisY = Input.GetAxisRaw("Vertical");

        this.movementDirection = new Vector2(moveAxisX, moveAxisY);
        this.movementDirection.Normalize();
    }

    void getRespawnInput()
    {
        if (Input.GetKey(KeyCode.Space)) {
            this.respawn();
        }
    }

    void Move()
    {
        float velocityX = this.movementDirection.x * this.movementSpeed * this.speedMultiplier;
        float velocityY = this.movementDirection.y * this.movementSpeed * this.speedMultiplier;

        Vector2 newVelocity = new Vector2(velocityX * Time.fixedDeltaTime, velocityY * Time.fixedDeltaTime);
        this.body.velocity = newVelocity * this.side;
    }

    void respawn()
    {
        gameObject.transform.position = this.spawnPoint;
    }

    // Setters
    public void setMovementSpeed(float newMovementSpeed)
    {
        if (newMovementSpeed < 0) {
            newMovementSpeed = 0;
        }
        this.movementSpeed = newMovementSpeed;
    }

    public void setSpeedMultiplier(float newSpeedMultiplier)
    {
        if (newSpeedMultiplier < 0) {
            newSpeedMultiplier = 0;
        }
        this.speedMultiplier = newSpeedMultiplier;
    }

    public void setSpawnPoint(Vector2 position)
    {
        this.spawnPoint = position;
    }

    // Getters
    public float getMovementSpeed()
    {
        return this.movementSpeed;
    }

    public float getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
}
