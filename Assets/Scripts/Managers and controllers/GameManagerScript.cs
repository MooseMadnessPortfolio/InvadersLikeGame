using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int enemyCount;
    public int playerDamageCost;

    public UIControllerScript uiController;

    private static bool isGameEnd = false;

    private float timer = 0;
    [SerializeField]
    private int score;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void GameOver()
    {
        if (!isGameEnd)
        {
            isGameEnd = true;
            string jsCode = @"var token = sessionStorage.access_token;
                        var xmlhttp = new XMLHttpRequest(); 
                        xmlhttp.open('POST', 'https://api.sagaidachniepath.xyz/quests/checkpoint');
                        xmlhttp.setRequestHeader('Content-Type', 'application/json');
                        xmlhttp.setRequestHeader('authorization', 'Bearer ' + token);
                        xmlhttp.onreadystatechange = function() {
                            if (xmlhttp.readyState == 4) {
                                if(xmlhttp.status == 204) {
                                    window.location = 'https://sagaidachniepath.xyz/congratulations';
                                } 
                            }
                        };
                        xmlhttp.send(JSON.stringify({ points: '" + score + "', elapsedTime: '" + timer * 1000 + "' }));";
            Application.ExternalEval(jsCode);
            SceneManager.LoadScene("Scenes/WaitScene");
        }
    }

    public void OnEnemyDeath()
    {
        enemyCount--;
        if (enemyCount <= 0)
            GameOver();
    }

    public void OnPlayerDamage()
    {
        score -= playerDamageCost;
        if(score <= 0)
        {
            score = 0;
            GameOver();
            return;
        }

        if (uiController != null)
            uiController.SetScore(score);
    }

    public void OnEnterGameOverArea()
    {
        score = 0;
        GameOver();
    }
}
