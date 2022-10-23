using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    public float speed = 500 ;

    public bool isJump = false;

    public Rigidbody2D rb;

    public Animator anim;
    public Vector2 jumpForce = new Vector2(0, 5f);

    public Text scoreText;

    public static int scoreNum = 1;

    public Animator[] chestAnim;

    
    private int chestNum=0;

    public GameObject winPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        scoreText.text = scoreNum.ToString();
        WinPanel();
    }

    private void FixedUpdate()
    {
        Movement();
        
    }

    void WinPanel()
    {
        if (chestNum==2)
        {
            winPanel.gameObject.SetActive(true);
            
        }
    }

    void Movement()
    {
        
        float faceDirection = Input.GetAxisRaw("Horizontal");
        
        float xMove = Input.GetAxis("Horizontal");
        
        float xSpeed = xMove * speed;
        anim.SetFloat("isRunning", Mathf.Abs(xMove));
        
        
        if (faceDirection != 0)
        {
            rb.transform.localScale = new Vector3(faceDirection, 1, 1);
            rb.velocity = new Vector2(xSpeed*Time.fixedDeltaTime, rb.velocity.y);
            
        }
        
        
    }

    void Jump()
    {
        //跳跃
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce.y);
            anim.SetBool("isJumping",true);
        }

        if (rb.velocity.y < 0)
        {
            isJump = false;
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling",true);
            isJump = false;
            

        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isFalling",false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.tag == "Coins")
        {
            
            scoreNum++;
            
            other.gameObject.SetActive(false);
            
        }
        if (other.tag == "Chest")
        {
            
            chestAnim[chestNum].SetBool("openChest",true);
            StartCoroutine(DestroyChest());
            
            
            
            //Debug.Log("Get The Key");
        }
    }

    IEnumerator DestroyChest()
    {
        yield return new WaitForSeconds(2);
        chestAnim[chestNum].SetBool("isDestroy",true);
        yield return new WaitForSeconds(0.3f);
        
        Destroy(chestAnim[chestNum].gameObject);
        chestNum++;
    }
}
