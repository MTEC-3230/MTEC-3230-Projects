using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TequilaSunrise : Drink
{
        public static string NAME = "Tequila Sunrise";
        private static Color COLOR = new Color(1f, 0.525f, 0.180f, 1f);
    
        void Start()
        {
            components = new List<Drink> {gameObject.AddComponent<OrangeJuice>(), gameObject.AddComponent<Tequila>(), gameObject.AddComponent<Grenadine>()};
            this.setID(NAME);
            this.setColor(COLOR);
        }
    }
