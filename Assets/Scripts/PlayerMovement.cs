using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rigid;
    public float playerSpeed = 2f;
    private Vector2 v;
    //public bool didMove = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        v = new Vector2(horizontal, vertical);
        //anim.SetFloat("moveX", horizontal);
        //anim.SetFloat("moveY", vertical);
        //anim.SetFloat("Speed", v.magnitude);
        //if (horizontal == 1 || horizontal == -1 || vertical == 1 || vertical == -1)
        //{
            //anim.SetFloat("lastMoveX", horizontal);
            //anim.SetFloat("lastMoveY", vertical);
        //}
    }

    private void FixedUpdate()
    {
        rigid.velocity = playerSpeed * v;
    }
}
