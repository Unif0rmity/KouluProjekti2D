using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public Animator animator;
    public Rigidbody2D playerRB;

    public bool grounded;


    void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        GroundDetect();
        transform.Translate(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, 0);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk", true);

        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            SoundManagerScript.PlaySound("Bell");
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            animator.SetBool("Jump", true);
        }

        //youtube muunnos 
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            playerRB.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Debug.Log("Going to Main Menu");
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            SoundManagerScript.PlaySound("itemSound");
            SoundManagerScript.PlaySound("PlayerHit");

            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("LevelEnd"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (transform.position.y > collision.transform.position.y + collision.transform.localScale.y)
            {
                collision.gameObject.GetComponent<Enemy>().Die();
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce * 0.4f);
                SoundManagerScript.PlaySound("EnemyHit");
            }
            else
            {
                CatDie();

            }
        }
        if (collision.gameObject.CompareTag("Alien"))
        {

            if (transform.position.y > collision.transform.position.y + collision.transform.localScale.y)
            {

                collision.gameObject.GetComponent<Alien>().Die();
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce * 0.4f);
                SoundManagerScript.PlaySound("EnemyHit");
            }
            else
            {

                CatDie();
            }

        }

        if (collision.gameObject.CompareTag("FallDeath"))
        {
            CatDie();
        }
    }
    public void CatDie()
    {

        animator.SetTrigger("Die");
        playerRB.velocity = new Vector2(0, 9);
        Destroy(GetComponent<BoxCollider2D>());
        moveSpeed = 0;
        Destroy(gameObject, 6);
        StartCoroutine("ContinueTime");
        Time.timeScale = 0;
        SoundManagerScript.PlaySound("GameOver");

    }
    IEnumerator ContinueTime()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        yield return new WaitForSecondsRealtime(2);
        RestartLevel();
    }
    void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void GroundDetect()
    {
        Vector3 checkPosition = transform.position - new Vector3(0, transform.localScale.y / 2, 0);
        RaycastHit2D castHit = Physics2D.BoxCast(checkPosition, new Vector2(1.2f, 0.3f), 0, Vector2.zero, 0, LayerMask.GetMask("Ground"));
        if (castHit && playerRB.velocity.y <= 0)
        {
            grounded = true;
            animator.SetBool("Jump", false);

        }
        else
        {
            grounded = false;

        }
    }
}
