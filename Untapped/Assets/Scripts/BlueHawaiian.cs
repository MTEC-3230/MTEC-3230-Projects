using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHawaiian : Drink
{
    public static string NAME = "Blue Hawaiian";
    private static Color COLOR = new Color(0.423f, 0.827f, 0.937f, 1f);
    
    void Start()
    {
        components = new List<Drink> {gameObject.AddComponent<PineappleJuice>(), gameObject.AddComponent<Rum>(), gameObject.AddComponent<Curacao>()};
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
