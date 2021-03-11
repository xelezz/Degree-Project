using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    private Saber saberType;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = saberType.score.ToString() + "Score:";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
