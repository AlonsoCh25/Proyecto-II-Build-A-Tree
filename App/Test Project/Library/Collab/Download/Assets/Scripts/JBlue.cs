using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JBlue : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetBool("JumpBlue", true);
            _rigidbody2D.AddForce(new Vector2(0, FuezadeSalto));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.SetBool("RunBlue", true);
            _rigidbody2D.AddForce(new Vector2(FuerzadeLado, 0));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("RunBlueL", true);
            _rigidbody2D.AddForce(new Vector2(-FuerzadeLado, 0));
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            animator.SetBool("HitBlue", true);
            _rigidbody2D.AddForce(new Vector2(0, FuerzadeAtaque));
        }
    }
}
