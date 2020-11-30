using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JFrog : MonoBehaviour
{
    private Animator animator;

    public float FuezadeSalto;

    public float FuerzadeLado;

    public float FuerzadeAtaque;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetBool("JumpFrog", true);
            _rigidbody2D.AddForce(new Vector2(0, FuezadeSalto));
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("RunFrog", true);
            _rigidbody2D.AddForce(new Vector2(FuerzadeLado, 0));
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetBool("RunFrogL", true);
            _rigidbody2D.AddForce(new Vector2(-FuerzadeLado, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("HitFrog", true);
            _rigidbody2D.AddForce(new Vector2(0, FuerzadeAtaque));
        }

    }

}    

