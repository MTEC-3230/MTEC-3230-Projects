using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLibraryController : MonoBehaviour
{

    public MusicLibrary library;
    public MusicLibraryUI libraryView;


    public List<Song> songs;
    private void Start()
    {

        songs = new List<Song>();



        var song1 = new GameObject().AddComponent<Song>().Initialize("I Shot the Sherif", "Bob Marley", null);

        var song2 = new GameObject().AddComponent<Song>().Initialize("Thriller", "artist2", null);
        var song3 = new GameObject().AddComponent<Song>().Initialize("Song3", "artist3", null);
        var song4 = new GameObject().AddComponent<Song>().Initialize("Song4", "artist4", null);

        songs.Add(song1);
        songs.Add(song2);
        songs.Add(song3);
        songs.Add(song4);


        library =  MusicLibrary.Instance; 

        library.librarySongList = songs;


        foreach (var song in library.librarySongList)
        {

            GameObject songElement = Instantiate(libraryView.songElementUI, libraryView.content);
            songElement.GetComponent<SongElementUI>().label.text = song.songName.ToString();
        }




    }


    public void AddSongToPlaylist(Song song)
    {
        library.librarySongList.Add(song);
    }

    public void RemoveSongFromPlaylist(Song song)
    {

        if (library.librarySongList.Contains(song))
        {
            library.librarySongList.Remove(song);
        }


    }


    public void Shuffle()
    {

    }

}
