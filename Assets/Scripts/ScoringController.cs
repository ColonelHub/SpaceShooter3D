using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringController : MonoBehaviour
{
    public int multiplier;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
           Scoring.totalScore+=multiplier;
           scoreText.text = "SCORE:") + Scoring.totalScore;
           Debug.Log(Scoring.totalScore);
        }
    }
}
