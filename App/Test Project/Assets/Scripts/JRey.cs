using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JRey : MonoBehaviour
{
    public float fuerzaSalto;
    public GameManager gameManager;

    public float FuerzadeLado;
    
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    public float FuerzadeAtaque;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("estaSaltando",true);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("FuerzadeLado",false);
            rigidbody2D.AddForce(new Vector2(FuerzadeLado, 0));
        } 
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("RunReyL",false);
            rigidbody2D.AddForce(new Vector2(-FuerzadeLado, 0));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("HitRey", true);
            rigidbody2D.AddForce(new Vector2(0, FuerzadeAtaque));
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando",false); 
        }

        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
        throw new NotImplementedException();
        
    }
}
