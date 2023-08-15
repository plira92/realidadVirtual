using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Image scoreImage; // Reference to the Image component displaying the score image
    public Sprite[] scoreSprites; // Array of sprites representing different score images
    private int currentScore = 0; // The current score

    public void IncreaseScore()
    {
        currentScore++; // Increase the score by 1

        if (currentScore >= scoreSprites.Length)
        {
            Debug.Log("Score exceeds available images.");
            return;
        }

        scoreImage.sprite = scoreSprites[currentScore]; // Change the image sprite

        // You can also perform any other actions or logic related to the score increase here
    }
}
