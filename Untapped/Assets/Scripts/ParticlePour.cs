using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    private ParticleSystem particle;

    void Awake ()
    {
        particle = GetComponent<ParticleSystem>();
    }

    void Update ()
    {
        if(transform.parent.up.y < 0.0f)
        {
            particle.enableEmission = true;
        }
        else
        {
            particle.enableEmission = false;
        }
    }
}