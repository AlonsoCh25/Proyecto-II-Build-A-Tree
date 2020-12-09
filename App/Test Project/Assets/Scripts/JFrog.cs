using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JFrog : MonoBehaviour
{
    //Variables para movimiento 
    public float runFrog = 2;
    public float JumpFog = 3;
    private Rigidbody2D rigidbody2D;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D
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

