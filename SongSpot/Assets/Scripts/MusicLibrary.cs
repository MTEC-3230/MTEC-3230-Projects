using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLibrary : MonoBehaviour
{
<<<<<<< Updated upstream
   
    
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
=======

    public List<Song> librarySongList;

    public Dictionary<string, Song> library;


    // Music Library is a Singleton for now. 
    private static MusicLibrary _instance;

    public static MusicLibrary Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicLibrary>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }



    public void AddSongToLibrary(Song song)
    {
        librarySongList.Add(song);
    }

    public void RemoveSongToLibrary(Song song)
    {
        if (librarySongList.Contains(song))
        {
            librarySongList.Remove(song);
        }
    }

>>>>>>> Stashed changes
}
