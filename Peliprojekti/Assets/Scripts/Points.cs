using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public Text MyScoreText;
    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = "Score : " + ScoreNum;

    }
    private void OnTriggerEnter2D(Collider2D Diamond)
    {
        if (Diamond.tag == "Diamond")
        {
            ScoreNum += 1;
            Destroy(Diamond.gameObject);
            MyScoreText.text = "Score : " + ScoreNum;
        }

    }
    // Update is called once per frame

}
