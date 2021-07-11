using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }
}
