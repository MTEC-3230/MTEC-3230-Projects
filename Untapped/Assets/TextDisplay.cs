using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


public class TextDisplay : MonoBehaviour
{

    public TextMeshPro dialogText;

    public void SetDialogText(string text)
    {
        dialogText.text = text;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
