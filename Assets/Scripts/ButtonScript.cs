/**
 * Script: ButtonScript
 * Description: This script changes the Image component of a Button 
 * It's capable of change the sprite of the source image.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject button;
    Image currentImage;
    public Sprite firstImage;
    public Sprite secondImage;

    public void OnButtonClick()
    {
        currentImage = button.GetComponent<Image>();
        
        if (currentImage.sprite == firstImage)
        {
            currentImage.sprite = secondImage;
        }
        else
        {
            currentImage.sprite = firstImage;
        }
    }
}
