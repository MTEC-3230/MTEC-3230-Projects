using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VodkaCranberry : Drink
{
    public static string NAME = "Vodka Cranberry";
    private static Color COLOR = new Color(1f, 0.501f, 0.545f, 0.95f);
    
    void Start()
    {
        components = new List<Drink> {gameObject.AddComponent<CranberryJuice>(), gameObject.AddComponent<Vodka>()};
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
