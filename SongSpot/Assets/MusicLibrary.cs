using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLibrary : MonoBehaviour
{

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

}
