using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject DeathVFX;
    [SerializeField] GameObject HitVFX;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int hitPoints = 3;
    
    GameObject ParentGameObject;
    ScoreBoard scoreBoard;
    Rigidbody rb;

    void Start()
    {
        //using FindObjectOfType<>() to find data of type ScoreBoard and storing it in scoreBoard
        scoreBoard = FindObjectOfType<ScoreBoard>();
        ParentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddingRigidbody();
    }

    void AddingRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }


    void OnParticleCollision(GameObject other)
    {
        ProccessScore();
        if(hitPoints<1)
        {
            ProccessKillEnemy();
        }
    }

    void ProccessScore()
    {
        GameObject vfx = Instantiate(HitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform;
        hitPoints--;
        //calling function ScoreCount from ScoreBoard Script and incrementing score
        scoreBoard.ScoreCount(scorePerHit);
    }
    void ProccessKillEnemy()
    {
        
        //remember to turn on play on awake
        //this means it will play the moment its brought into existence
        GameObject vfx = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform;
        Destroy(gameObject);
    }
}
