using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{




    public Animator animator;
    public Rigidbody2D rb2D;
    public float moveSpeed;







    public float jumpForce;
    public float jumpCounter;
    public float jumpMaxCounter;







    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



        if (jumpCounter > jumpMaxCounter)
        {
            jumpCounter = 0;
            jumpMaxCounter = Random.Range(3, 5);
            Jump();

        }
        else
        {
            jumpCounter += Time.deltaTime;
        }





    }



    void Jump()
    {
        rb2D.velocity = new Vector2(0, jumpForce);

    }




    public void Die()
    {
        animator.SetTrigger("Die");
        moveSpeed = 0;
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(gameObject, 6);

    }
}
