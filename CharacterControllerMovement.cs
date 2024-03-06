using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControllerMovement : MonoBehaviour
{
    private Vector3 velocity;
    private Vector3 PlayerMovementInput;
    [SerializeField] private CharacterController Controller;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float turnSpeed;
    private Animator animator;
    public GameObject hasFlag;
    private GameManager gameManager;
    private SpawnManager spawnManager;
    private int enemiesToSpawn = 2;
    public bool isPlayerAlive = true;
    


    public bool playerFlag = false;
    

    
    

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput = new Vector3(0f, 0f, Input.GetAxis("Vertical"));

        if (isPlayerAlive)
        {
            MovePlayer();
            if (PlayerMovementInput != Vector3.zero && Controller.isGrounded)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        
      


       
    }


    void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);
        transform.Rotate(Vector3.up, turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);

        if (Controller.isGrounded)
        {             
                        
            velocity.y = -1f;
            

            if (Input.GetKeyDown(KeyCode.Space))
            {
                               
                velocity.y = jumpForce;
              
            }
        }
        else
        {
            velocity.y -= gravity * -2f * Time.deltaTime;
            

        }

        Controller.Move(MoveVector * speed * Time.deltaTime);
        Controller.Move(velocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Flag"))
        {
            hasFlag.gameObject.SetActive(true);
            Destroy(other.gameObject);
            playerFlag = true;
            
        }


        if (other.CompareTag("Goal") && playerFlag)
        {
            hasFlag.gameObject.SetActive(false);
            gameManager.UpdateScore();
            enemiesToSpawn++;
            spawnManager.SpawnEnemies(enemiesToSpawn);
            
            playerFlag = false;

        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            isPlayerAlive = false;
            animator.SetBool("isDying", true);
            gameManager.GameOver();
            hasFlag.gameObject.SetActive(false);
           


        }
    }

       
    
    
}
