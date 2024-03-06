using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    private float bombCooldown;
    public float speed = 25f;
    private CharacterControllerMovement controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<CharacterControllerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isPlayerAlive)
        {
            ShootObject();
        }
        
    }

    public void ShootObject()
    {
        bombCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && bombCooldown < 0)
        {
           GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, bombPrefab.transform.rotation);
            bomb.GetComponent<Rigidbody>().velocity = bombSpawnPoint.forward * speed;
            bombCooldown = 0.7f;

        }
    }
}
