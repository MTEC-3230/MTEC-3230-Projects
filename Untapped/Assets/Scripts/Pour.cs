using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    
    private Glass m;
    public delegate void OnPourDelegate(GameObject a, GameObject b);
    public static OnPourDelegate OnPour;
    private ParticleSystem pourParticles;

    void Start()
    { 
        Transform cap = this.gameObject.transform.GetChild(0);
        pourParticles = cap.GetComponent<ParticleSystem>();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Vector3.Dot(transform.up, Vector3.down) > 0.8)
        {
            //when pouring
            pourParticles.enableEmission = true;

            Transform cap = this.gameObject.transform.GetChild(0);
            if (cap.name != "Cap")
            {
                cap = this.gameObject.transform;
            }
            
            if (Physics.Raycast(cap.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag.Equals("Bottle") && !hit.transform.gameObject.Equals(this.gameObject))
                {
                    OnPour(this.gameObject, hit.transform.gameObject);
                }
                
            }


        }
        else
        {
            pourParticles.enableEmission = false;
        }

    }
}
