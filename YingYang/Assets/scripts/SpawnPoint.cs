using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Rigidbody2D characterBody;
    public CharacterController controller;
    // Start is called before the first frame update
    void Awake()
    {
        this.characterBody.transform.position = gameObject.transform.position;
        this.controller.setSpawnPoint(gameObject.transform.position);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
