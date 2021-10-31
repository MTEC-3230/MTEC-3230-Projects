using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class MusicLibrary
{
    List<string> songs;
    List<string> artists;
    List<string> playlists;
    void listSongs()
    {
    }
    void listArtists()
    {
    }
    void listPlaylists()
    {
    }
}
class Songs : MusicLibrary
{
    void addSong(string song)
    {
        songs.Add(song);
    }
    void removeSong(string song)
    {
        songs.Remove(song);
    }
}
class Artists : MusicLibrary
{
}
class Playlists : MusicLibrary
{
}
