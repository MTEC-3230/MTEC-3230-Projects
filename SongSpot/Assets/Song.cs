using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Song : MonoBehaviour
{

    public string songName;
    //public int songID;

    [SerializeField]
    private string artistName;

    public AudioClip audioClip; 


    public Song Initialize(string songName, string artistName, AudioClip audioClip)
    {
        this.songName = songName;
        this.artistName = artistName;

        this.audioClip = audioClip;

        return this; 

    }

    private float TrackLength { get; set; }

}
