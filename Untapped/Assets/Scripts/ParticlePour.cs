using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePour : MonoBehaviour
{
    private ParticleSystem particle;

    // Callback signature
    // Has: Return of type 'void' and 1 parameter of type 'string'
    public delegate void PourDelgate();

    // Event declaration
    public static event PourDelgate OnPour;

    bool is_Pouring = false; 

    void Awake ()
    {
        //Transform cap = this.gameObject.transform.GetChild(0);
        particle = GetComponent<ParticleSystem>();
    }

    void Update ()
    {
        if(transform.parent.up.y < 0.0f)
        {
            particle.enableEmission = true;
            if(!is_Pouring) OnPour();
            is_Pouring = true; 
        }
        else
        {
            particle.enableEmission = false;
            is_Pouring = false;
        }
    }
}