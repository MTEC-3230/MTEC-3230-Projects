using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassEvents : MonoBehaviour
{
    
    private Glass m;
    public delegate void OnPourDelegate(GameObject a, GameObject b);
    public static OnPourDelegate OnPour;
    public delegate void OnStopPourDelegate(GameObject a, GameObject b);
    public static OnStopPourDelegate OnStopPour;

    public delegate void OnPickupDelegate(GameObject a);
    public static OnPickupDelegate OnPickup;

    private ParticleSystem pourParticles;
    private bool isPouring = false;

    private GameObject pourTarget = null;
    void Start()
    {
        m = GetComponent<Glass>();
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
            isPouring = true;
            if (m.currentDrinks.Count != 0)
            {
                pourParticles.enableEmission = true;
            }

            Transform cap = this.gameObject.transform.GetChild(0);
            if (cap.name != "Cap")
            {
                cap = this.gameObject.transform;
            }
            
            if (Physics.Raycast(cap.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag.Equals("Bottle") && !hit.transform.gameObject.Equals(this.gameObject))
                {
                        pourTarget = hit.transform.gameObject;
                        OnPour(this.gameObject, pourTarget);
                }
                
            }
        }
        else
        {
            if (isPouring && pourTarget != null)
            {
                Debug.Log("Pour test: " + pourTarget.name);
                OnStopPour(this.gameObject, pourTarget);
                pourTarget = null;
            }
            isPouring = false;
            pourParticles.enableEmission = false;
        }
    }
}
