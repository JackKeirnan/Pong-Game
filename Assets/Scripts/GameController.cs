using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject PowerUpSpeed;
    public GameObject PowerUpSlow;
    public GameObject ScoreSound;

    public GameObject PowerUps;

    public static GameController instance;
    public GameObject Borders;

    public int scoreWin = 5;
    public int scorePlayer;
    public int scoreEnemy;

    public Text textPlayer;
    public Text textEnemy;

    private void OnEnable()
    {
            instance = this;
            SetUpGame();
    }

    public void EnemyScore()
    {
        scoreEnemy ++;
        Instantiate(ScoreSound, transform.position, transform.rotation);
        if(scoreEnemy == scoreWin)
            {
                SceneManager.LoadScene(7);
            }
        else
            {
                textEnemy.text = scoreEnemy.ToString();
                StartCoroutine(ActivateEnemyScoreFX());
                SetUpGame();
            }
    }
    
    public void PlayerScore()
    {
        scorePlayer ++;
        Instantiate(ScoreSound, transform.position, transform.rotation);
        if(scorePlayer == scoreWin)
            {
                if(SceneManager.GetActiveScene().name == "Level 1")
                {
                    SceneManager.LoadScene(2);
                }
                else if(SceneManager.GetActiveScene().name == "Level 2")
                {
                    SceneManager.LoadScene(4);
                }
                else if(SceneManager.GetActiveScene().name == "Level 3")
                {
                    SceneManager.LoadScene(10);
                }
            }
        else
            {
                textPlayer.text = scorePlayer.ToString();
                StartCoroutine(ActivatePlayerScoreFX());
                SetUpGame();
            }
    }
    
    public void PlayerScoreFX()
    {
        foreach(var spriteRenderer in Borders.GetComponentsInChildren<SpriteRenderer>(true))
        {
            spriteRenderer.color = new Color(0, 1, 0, 1);
        }
    }

    public void ReturnToNormal()
    {
        foreach(var spriteRenderer in Borders.GetComponentsInChildren<SpriteRenderer>(true))
        {
            spriteRenderer.color = new Color(0, 0, 1, 1);
        }
    }

    public void EnemyScoreFX()
    {
        foreach(var spriteRenderer in Borders.GetComponentsInChildren<SpriteRenderer>(true))
        {
            spriteRenderer.color = new Color(1, 0, 0, 1);
        }
    }

    IEnumerator ActivatePlayerScoreFX()
    {
        PlayerScoreFX();
        yield return new WaitForSeconds(1);
        ReturnToNormal();
    }

    IEnumerator ActivateEnemyScoreFX()
    {
        EnemyScoreFX();
        yield return new WaitForSeconds(1);
        ReturnToNormal();
    }

    public void SetUpGame()
    {
        if(scorePlayer != 0 || scoreEnemy != 0)
        {
            foreach(Transform child in PowerUps.transform)
            {
                Destroy(child.gameObject);
            }
        }
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            Vector3 slowposition1 = new Vector3((float)0, (float)-3.5, 0);
            Vector3 speedposition1 = new Vector3((float)0, (float)3.5, 0);
            GameObject PU1 = Instantiate(PowerUpSlow, slowposition1, Quaternion.identity);
            PU1.transform.parent = GameObject.Find("PowerUps").transform;
            GameObject PU2 = Instantiate(PowerUpSpeed, speedposition1, Quaternion.identity);
            PU2.transform.parent = GameObject.Find("PowerUps").transform;
        }
        else if(SceneManager.GetActiveScene().name  == "Level 2")
        {
            Vector3 slowposition1 = new Vector3((float)3, (float)4, 0);
            Vector3 slowposition2 = new Vector3((float)-3, (float)-4, 0);
            Vector3 speedposition1 = new Vector3((float)-3, (float)4, 0);
            Vector3 speedposition2 = new Vector3((float)3, (float)-4, 0);
            GameObject PU1 = Instantiate(PowerUpSlow, slowposition1, Quaternion.identity);
            PU1.transform.parent = GameObject.Find("PowerUps").transform;
            GameObject PU2 = Instantiate(PowerUpSlow, slowposition2, Quaternion.identity);
            PU2.transform.parent = GameObject.Find("PowerUps").transform;
            GameObject PU3 = Instantiate(PowerUpSpeed, speedposition1, Quaternion.identity);
            PU3.transform.parent = GameObject.Find("PowerUps").transform;
            GameObject PU4 = Instantiate(PowerUpSpeed, speedposition2, Quaternion.identity);
            PU4.transform.parent = GameObject.Find("PowerUps").transform;

        }
        else if(SceneManager.GetActiveScene().name  == "Level 3")
        {
            Vector3 speedposition = new Vector3((float)-0.05, (float)4.3, 0);
            Vector3 slowposition = new Vector3((float)-0.04, (float)-4.2, 0);
            GameObject PU1 = Instantiate(PowerUpSpeed, speedposition, Quaternion.identity);
            PU1.transform.parent = GameObject.Find("PowerUps").transform;
            GameObject PU2 = Instantiate(PowerUpSlow, slowposition, Quaternion.identity);
            PU2.transform.parent = GameObject.Find("PowerUps").transform;
        }
    }
}