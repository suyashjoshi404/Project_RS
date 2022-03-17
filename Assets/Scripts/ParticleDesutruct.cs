using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDesutruct : MonoBehaviour
{
    //applying this script to enemyExplosionVFX prefab in order to clear explosion vfx to improve visbility
    [SerializeField] float timeTillDestroy = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);   
    }
}
