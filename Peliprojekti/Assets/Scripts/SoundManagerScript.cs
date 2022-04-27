using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, jumpSound, enemyDeathSound, diamondSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        diamondSound = Resources.Load<AudioClip>("itemSound");

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
        }
    }
}
