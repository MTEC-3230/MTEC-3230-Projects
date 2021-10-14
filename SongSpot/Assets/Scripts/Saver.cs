using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//checks for unblocked quests

public class Saver : MonoBehaviour {
    public GameObject[] Unlocked,Locked;
    public int level_num;

    // Use this for initialization
    void Start () {

       // level_num = PlayerPrefs.GetInt("Last_level");

        for (int i=0;i< Unlocked.Length; i++)
        {
            if (i <= level_num)
            {
                Locked[i].SetActive(false);
                Unlocked[i].SetActive(true);
            }
        }
		
	}
	
}
