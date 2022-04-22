using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public GameObject cat;

    // Start is called before the first frame update
    void Start()
    {
        cat = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cat.transform.position.x, transform.position.y, 0);
    }
}
