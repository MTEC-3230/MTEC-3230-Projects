using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyGland : Drink
{
    public static string NAME = "Monkey Gland";
    private static Color COLOR = new Color(1f, 0.878f, 0.521f, 0.8f);
    
    void Start()
    {
        components = new List<Drink> {gameObject.AddComponent<Gin>(), gameObject.AddComponent<OrangeJuice>(), gameObject.AddComponent<Grenadine>()};
        this.setID(NAME);
        this.setColor(COLOR);
    }
}
