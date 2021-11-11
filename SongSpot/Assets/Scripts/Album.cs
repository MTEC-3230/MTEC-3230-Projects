using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Album : MonoBehaviour
{
    // Start is called before the first frame update
    public string albumName;

    [SerializeField]
    private string artistName;

    public List<Song> songs;
}
