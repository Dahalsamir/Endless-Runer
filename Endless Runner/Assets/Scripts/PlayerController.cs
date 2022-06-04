using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController charactercControll;
    private Vector3 direction;
    public float moveSpeed;
    private int desireLand = 1; //0 is left 1 is middle and 2 is right
    // Start is called before the first frame update
    public float landDistance; //Distance between two land
    public float jumpForce = 2;
    public float gravity = -20;
    public Animator playerAnimation;
    public float maxSpeed;
    public static int coin;
    public Text coinText;
    void Start()
    {
        charactercControll = GetComponent<CharacterController>();
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = moveSpeed;
        if(moveSpeed < maxSpeed)
        {
            moveSpeed += 0.1f * Time.deltaTime;
        }
        if (charactercControll.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKey(KeyCode.Space)|| SwipeManager.swipeUp)
            {
                jump();
                playerAnimation.SetBool("againGround", true);
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }


        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeManager.swipeRight) 
        {
            desireLand++;
            if(desireLand == 3)
            {
                desireLand = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeManager.swipeLeft)
        {
            desireLand--;
            if (desireLand == -1)
            {
                desireLand = 0;
            }
        }
        //calculate the position 
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(desireLand == 0)
        {
            targetPosition += Vector3.left * landDistance;
        }
        else if(desireLand == 2)
        {
            targetPosition += Vector3.right * landDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, 250*Time.deltaTime);
        charactercControll.center = charactercControll.center;
        coinText.text = "coins: " + coin;
    }
    private void FixedUpdate()
    {
        if (!PlayerManager.gameIsActivated)
        return;
        
        charactercControll.Move(direction * Time.fixedDeltaTime);
        playerAnimation.SetBool("isGamwStart", true);



    }
    void jump()
    {
        direction.y = jumpForce;
        playerAnimation.SetBool("isGamwStart",false);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacles")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioSound>().PlaySound("GameOver");
          
        }
    }
    IEnumerator Slide()
    {
        playerAnimation.SetBool("isSliding", true);
        charactercControll.center = new Vector3(0, -0.5f, 0);
        charactercControll.height = 1;
        yield return new WaitForSeconds(2);
        playerAnimation.SetBool("isSliding", false);
        charactercControll.center = new Vector3(0, 0, 0);
        charactercControll.height = 2;
    }
    
}
