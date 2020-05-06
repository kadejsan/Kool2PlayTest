using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Spawner EnemySpawner;
    public Player Player;
    public Text ScoreText;
    public Text HPText;

    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = EnemySpawner.GetEnemiesKilled().ToString();
        }
        if (HPText != null)
        {
            HPText.text = Player.GetHealth().ToString();
        }
    }
}
