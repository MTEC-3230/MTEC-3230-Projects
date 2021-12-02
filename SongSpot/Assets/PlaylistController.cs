using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaylistController : MonoBehaviour
{
    public PlayList playlist;
    public PlaylistUI playlistView;


    public List<Song> songs;
    private void Start()
    {

        songs = new List<Song>();



        //var song1 = new GameObject().AddComponent<Song>().Initialize("Song1", "artist1", null);

        //var song2 = new GameObject().AddComponent<Song>().Initialize("Thriller", "artist2", null);
        //var song3 = new GameObject().AddComponent<Song>().Initialize("Song3", "artist3", null);
        //var song4 = new GameObject().AddComponent<Song>().Initialize("Song4", "artist4", null);

        //songs.Add(song1);
        //songs.Add(song2);
        //songs.Add(song3);
        //songs.Add(song4);


        //var go = new GameObject();
        //go.AddComponent<Playlist>();
        //go.name = "Playlist";

        //playlist = go.GetComponent<Playlist>();

        //playlist.playListSongs = songs;


        foreach(var song in playlist.playListSongs)
        {

            GameObject  songElement = Instantiate(playlistView.songElementUI, playlistView.content);
            songElement.GetComponent<SongElementUI>().label.text = song.songName.ToString(); 
        }




    }


    public void AddSongToPlaylist(Song song)
    {
        playlist.playListSongs.Add(song); 
    }

    public void RemoveSongFromPlaylist(Song song)
    {

        if(playlist.playListSongs.Contains(song))
        {
            playlist.playListSongs.Remove(song);
        }


    }


    public void  Shuffle()
    {

    }

}
