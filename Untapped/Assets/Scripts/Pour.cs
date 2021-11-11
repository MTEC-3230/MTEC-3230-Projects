using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pour : MonoBehaviour
{
    private RecipeList recipes;
    private Mixer m;
    public delegate void OnPourDelegate(GameObject a, GameObject b);
    public static OnPourDelegate OnPour;

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        
        if (Vector3.Dot(transform.up, Vector3.down) > 0.8)
        {
            //when pouring
            //todo- implement some sort of timer for pouring + particle system
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag.Equals("Bottle") && !hit.transform.gameObject.Equals(this.gameObject))
                {
                    OnPour(this.gameObject, hit.transform.gameObject);
                }
                
            }


        }

    }
}
