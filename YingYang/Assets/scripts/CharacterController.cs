using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D body;
    public CharacterController other;
    public float movementSpeed = 275f;
    public float speedMultiplier = 1f;
    public float rotationSpeed = 1f;
    public int side = 0;

    // Private
    private Vector2 movementDirection;
    private Vector2 rotationDirection;
    private Vector2 spawnPoint;
    private bool canMove = true;

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

        if (!this.canMove) {
            return;
        }

        this.movementDirection = new Vector2(moveAxisX, moveAxisY);
        this.movementDirection.Normalize();
    }

    void getRespawnInput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
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
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        this.canMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Finish") {
            this.movementDirection = new Vector2(0, 0);
            this.canMove = false;
            this.body.transform.position = collider.transform.position;
            gameObject.transform.localScale *= 2;
        } else {
            this.respawn();
            this.other.respawn();
        }
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
