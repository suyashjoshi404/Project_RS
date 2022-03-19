using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject DeathVFX;
    [SerializeField] Transform ParentObject;
    ScoreBoard scoreBoard;
    [SerializeField] int scorePerHit = 10;

    void Start()
    {
        //using FindObjectOfType<>() to find data of type ScoreBoard and storing it in scoreBoard
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProccessScore();
        ProccessKillEnemy();
    }

    private void ProccessKillEnemy()
    {
        //remember to turn on play on awake
        //this means it will play the moment its brought into existence
        GameObject vfx = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentObject;
        Destroy(gameObject);
    }

    private void ProccessScore()
    {
        //calling function ScoreCount from ScoreBoard Script and incrementing score
        scoreBoard.ScoreCount(scorePerHit);
    }
}
