using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Spawner EnemySpawner;
    public Player Player;    

    public Text ScoreText;
    public Text HPText;
    public Text GunUsedText;

    void Update()
    {
        if (ScoreText != null && EnemySpawner != null)
        {
            ScoreText.text = EnemySpawner.GetEnemiesKilled().ToString();
        }
        if (HPText != null && Player != null)
        {
            HPText.text = Player.GetHealth().ToString();
        }
        if(GunUsedText != null && Player != null) 
        {
            GunUsedText.text = Player.GetGunController().GetGunName();
        }
    }
}
