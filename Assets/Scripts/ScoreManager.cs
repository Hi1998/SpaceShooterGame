using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshPro UI component
    /// </summary>
    public TMP_Text scoreText;  
    /// <summary>
    /// Initial score
    /// </summary>
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();  // Initialize the score display
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// incrementing the score
    /// </summary>
    public void IncrementScore()
    {
        score += 1;  // Increment the score by 1
        UpdateScoreText();  // Update the score display
    }

    /// <summary>
    /// Update the score display every time whenever score gets incremented
    /// </summary>
    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
