using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MixerGlass : Mixer
{

    private Transform glassFill;
    private Renderer thisRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        glassFill = this.gameObject.transform.GetChild(0);
        thisRenderer = glassFill.GetComponent<Renderer>();
        Debug.Log(glassFill.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (mixerList.Count == 0)
        {
            this.ID = Drink.EMPTYNAME;
            this.color1 = Drink.EMPTYCOLOR;
        }
        else if (mixerList.Count == 1 || mixerList[0].getID().Equals(Screwdriver.NAME))
        {
            this.ID = (mixerList[0].getID());
            this.color1 = (mixerList[0].getColor());
        }

        if (thisRenderer != null)
        {
            thisRenderer.material.color = color1;
        }
    }
}