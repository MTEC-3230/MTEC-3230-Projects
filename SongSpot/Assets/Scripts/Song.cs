using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
<<<<<<< Updated upstream
   
=======
>>>>>>> Stashed changes

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

<<<<<<< Updated upstream
    } 

    private float TrackLength { get; set; }


}

=======
    }

    private float TrackLength { get; set; }

}
>>>>>>> Stashed changes
