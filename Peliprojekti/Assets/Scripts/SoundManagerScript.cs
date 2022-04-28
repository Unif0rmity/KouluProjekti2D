using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, enemyDeathSound, diamondSound, gameOverSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        diamondSound = Resources.Load<AudioClip>("itemSound");
        playerHitSound = Resources.Load<AudioClip>("PlayerHit");
        enemyDeathSound = Resources.Load<AudioClip>("EnemyHit");
        gameOverSound = Resources.Load<AudioClip>("GameOver");
        jumpSound = Resources.Load<AudioClip>("Bell");


        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "itemSound":
                audioSrc.PlayOneShot(diamondSound);
                break;
            case "PlayerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "EnemyHit":
                audioSrc.PlayOneShot(enemyDeathSound);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "Bell":
                audioSrc.PlayOneShot(jumpSound);
                break;

        }
    }
}
