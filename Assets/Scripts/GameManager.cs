using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    private Blade blade;
    private Spawner spawner;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void Explode()
    {
        spawner.enabled = false;
        blade.enabled = false;
    }
}