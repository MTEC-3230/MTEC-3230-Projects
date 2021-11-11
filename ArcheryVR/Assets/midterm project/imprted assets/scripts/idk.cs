using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idk : MonoBehaviour
{
    public GameObject box;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "arrow")
        {
            Destroy(collision.gameObject);
            Debug.Log("destroyed");
        }
    }

}
