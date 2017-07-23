using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public Text scoreText;

    public Sprite soundOnSprite;
    public Sprite soundOffSprite;
    public Image soundButtonImg;

    public void SetScore(int newScore)
    {
        scoreText.text = "Левки: " + newScore;
    }

    public void SetSoundActive(bool isActive)
    {
        soundButtonImg.sprite = isActive ? soundOnSprite : soundOffSprite;
    }
}