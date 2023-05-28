using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D body;
    public CharacterController other;
    public float movementSpeed = 275f;
    public float speedMultiplier = 1f;
    public float rotationSpeed = 1f;
    public int side = 0;
    public GameObject pauseMenu;
    public GameObject game;

    // Private
    private bool isPaused = false;
    private Vector2 movementDirection;
    private Vector2 rotationDirection;
    private Vector2 spawnPoint;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        this.pauseMenu.SetActive(this.isPaused);
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
        if (Input.GetKeyDown(KeyCode.Escape)) {
            this.Pause();
        }

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // this.respawn();
        }
    }

    void Move()
    {
        float velocityX = this.movementDirection.x * this.movementSpeed * this.speedMultiplier;
        float velocityY = this.movementDirection.y * this.movementSpeed * this.speedMultiplier;

        Vector2 newVelocity = new Vector2(velocityX * Time.fixedDeltaTime, velocityY * Time.fixedDeltaTime);
        this.body.velocity = newVelocity * this.side;
    }

    void Pause()
    {
        if (this.isPaused) {
            this.isPaused = false;
            this.pauseMenu.SetActive(false);
            this.game.SetActive(true);
        } else {
            this.isPaused = true;
            this.pauseMenu.SetActive(true);
            this.game.SetActive(false);
        }
    }

    public void setPause(bool pause)
    {
        this.isPaused = pause;
        if (this.isPaused) {
            this.isPaused = true;
            this.pauseMenu.SetActive(true);
            this.game.SetActive(false);
        } else {
            this.isPaused = false;
            this.pauseMenu.SetActive(false);
            this.game.SetActive(true);
        }
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
            SceneManager.LoadScene("Victory");
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
