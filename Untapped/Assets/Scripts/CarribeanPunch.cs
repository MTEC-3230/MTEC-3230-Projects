using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarribeanPunch : Drink
{
    public static string NAME = "Carribean Punch";
    private static Color COLOR = new Color(1f, 0.792f, 0.380f, 1f);
    
    void Start()
    {
        components = new List<Drink> {gameObject.AddComponent<OrangeJuice>(), gameObject.AddComponent<Rum>(), gameObject.AddComponent<PineappleJuice>()};
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
