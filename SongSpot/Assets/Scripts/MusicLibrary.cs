using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLibrary : MonoBehaviour
{
   
    
    public MusicLibrary()
    {
        var songs = new List<string>();
        songs.Add("Stronger");
        songs.Add("Dance, Dance");
        songs.Add("Big Gansta");
        songs.Add("Dark Queen");
        songs.Add(null); // nulls are allowed for reference type list
    }

    public List<Song> playListSongs; 
    
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
