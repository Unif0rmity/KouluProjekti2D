using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed;
    public GameObject detectionPoint;
    public Animator animator;


    [SerializeField]
    private float direction;

    [SerializeField]
    private bool changeDir;

    [SerializeField]
    private LayerMask groundLayer;




    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * direction, 0, 0);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    private void LateUpdate()
    {

        Debug.DrawRay(detectionPoint.transform.position, Vector2.down, Color.green);

        RaycastHit2D hit = Physics2D.Raycast(detectionPoint.transform.position, Vector2.down, 1, groundLayer);

        if (hit.collider == null)
        {
            ChangeDirection();
        }

        Debug.DrawRay(detectionPoint.transform.position, Vector2.right * direction * 0.2f, Color.blue);

        RaycastHit2D hit2 = Physics2D.Raycast(detectionPoint.transform.position, Vector2.right * direction, 0.2f, groundLayer);

        if (hit2.collider != null)
        {
            ChangeDirection();
        }



    }

    void ChangeDirection()
    {
        Debug.Log("Suunnanvaihto");
        direction *= -1;

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
