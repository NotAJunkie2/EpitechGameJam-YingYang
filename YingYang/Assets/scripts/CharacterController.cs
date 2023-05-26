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

    private Vector2 movementDirection;
    private Vector2 rotationDirection;

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
        // this.Rotate();
        this.Move();
    }

    // Methods
    void processInputs()
    {
        // this.computeRotationDirection();
        this.computeMovementDirection();
    }

    // Get input data
    void computeMovementDirection()
    {
        float moveAxisX = Input.GetAxisRaw("Horizontal");
        float moveAxisY = Input.GetAxisRaw("Vertical");

        this.movementDirection = new Vector2(moveAxisX, moveAxisY);
        this.movementDirection.Normalize();
    }

    // void computeRotationDirection()
    // {
    //     float rotateLeft = System.Convert.ToInt32(Input.GetKey(KeyCode.Q));
    //     float rotateRight = System.Convert.ToInt32(Input.GetKey(KeyCode.E)) * -1;
    //     this.rotationDirection = new Vector2(rotateLeft, rotateRight);
    // }

    void Move()
    {
        float velocityX = this.movementDirection.x * this.movementSpeed * this.speedMultiplier;
        float velocityY = this.movementDirection.y * this.movementSpeed * this.speedMultiplier;

        Vector2 newVelocity = new Vector2(velocityX * Time.fixedDeltaTime, velocityY * Time.fixedDeltaTime);
        this.body.velocity = newVelocity * this.side;
    }

    // void Rotate()
    // {
    //     float rotationValue = (this.rotationDirection.x + this.rotationDirection.y) * this.rotationSpeed;
    //     this.body.rotation += (rotationValue * Time.deltaTime);
    // }

    // Setters
    void setMovementSpeed(float newMovementSpeed)
    {
        if (newMovementSpeed < 0) {
            newMovementSpeed = 0;
        }
        this.movementSpeed = newMovementSpeed;
    }

    void setSpeedMultiplier(float newSpeedMultiplier)
    {
        if (newSpeedMultiplier < 0) {
            newSpeedMultiplier = 0;
        }
        this.speedMultiplier = newSpeedMultiplier;
    }

    // Getters
    float getMovementSpeed()
    {
        return this.movementSpeed;
    }

    float getSpeedMultiplier()
    {
        return this.speedMultiplier;
    }
}
