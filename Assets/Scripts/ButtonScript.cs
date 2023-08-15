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
