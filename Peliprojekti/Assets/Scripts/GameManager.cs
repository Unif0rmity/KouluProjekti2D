using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager manager;

    public bool Level1;

    public bool Level2;
    private void Awake()
    {

        if (manager == null)
        {


            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
