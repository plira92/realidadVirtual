using UnityEngine;
using UnityEngine.UI;

public class IncreaseScoreButton : MonoBehaviour
{
    public ScoreManager scoreManager; // Reference to the ScoreManager script

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        scoreManager.IncreaseScore();
    }
}
