using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{//Code repris des �l�ments vu du cours 

    Rigidbody2D rigid;
    Vector2 dir = new Vector2();
    public float speed = 300f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        dir = context.ReadValue<Vector2>();//new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void Animate()
    {
        anim.SetFloat("Magnitude", rigid.velocity.magnitude);
        anim.SetFloat("Hor", dir.x);
        anim.SetFloat("Ver", dir.y);
    }

    private void Movement()
    {
        Vector2 pos = new Vector2();
        pos += (dir.normalized * speed) * Time.fixedDeltaTime;
        rigid.velocity = pos;
    }

    // Update is called once per frame
    void Update()
    {
        //OnMove();
    }

    private void FixedUpdate()
    {
        Animate();
        Movement();
    }
}
