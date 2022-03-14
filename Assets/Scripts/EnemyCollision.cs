using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    void OnParticleCollision(GameObject other) 
    {
        Debug.Log($"{this.name} is hit by {other.gameObject.name}");    
        Destroy(gameObject);    
    }
}
