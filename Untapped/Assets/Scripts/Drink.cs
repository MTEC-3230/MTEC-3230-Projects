    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drink : MonoBehaviour
{
    public string ID;
    public Color thisColor;
    public static string EMPTYNAME = "Empty";
    public static Color EMPTYCOLOR = new Color(0f, 0f, 0f, 0f);

    public abstract Drink Mix();

    public Color getColor()
    {
        return thisColor;
    }

    public void setColor(Color c)
    {
        thisColor = c;
    }
    
    public string getID()
    {
        return ID;
    }

    public void setID(string s)
    {
        ID = s;
    }

}
