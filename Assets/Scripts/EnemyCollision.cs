using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject DeathVFX;
    [SerializeField] Transform ParentObject;

    void OnParticleCollision(GameObject other) 
    {
        //remember to turn on play on awake
        //this means it will play the moment its brought into existence
        Debug.Log($"{this.name} is hit by {other.gameObject.name}");
        GameObject vfx = Instantiate(DeathVFX,transform.position,Quaternion.identity);
        vfx.transform.parent = ParentObject;   
        Destroy(gameObject);
    }
}
