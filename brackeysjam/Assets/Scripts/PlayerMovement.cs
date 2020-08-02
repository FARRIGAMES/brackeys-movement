using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float jumpSpeed = 5f;

    public bool isGround;
    public LayerMask groundLayers;

    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        //move
            float Horizontal = Input.GetAxisRaw("Horizontal");
            float Moving = Horizontal * playerSpeed;

            m_rb.velocity = new Vector2(Moving, m_rb.velocity.y);

        //jump
        
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                m_rb.velocity = new Vector2(m_rb.velocity.x, jumpSpeed);
            }
        

    }

    void Update()
    {
        isGround = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2(transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);
    }

}
