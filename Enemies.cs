using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private CharacterController enemyController;
    public GameObject player;
    public float speed = 10;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        


    }

    // Update is called once per frame
    void Update()
    {
        // Normal movement working
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        Vector3 playerPos = player.transform.position;
        Vector3 newPos = new Vector3(playerPos.x, 0, playerPos.z);
        transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        transform.LookAt(player.transform);


        // character controller movement

    }

 

}
