using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private int mScore;
    public Text ScoreText;
    public Text ClearText;

    // Start is called before the first frame update
    void Start()
    {
        mScore = 0;
        ScoreText.text = "Score : " + mScore.ToString();
        //ClearText.gameObject.SetActive(false);
        ClearText.text = "";
    }

    public void AddScore(int amount)
    {
        mScore = mScore + amount;
        ScoreText.text = "Score : " + mScore.ToString();
        if (mScore >= 8)
        {
            ClearText.text = "Clear";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
