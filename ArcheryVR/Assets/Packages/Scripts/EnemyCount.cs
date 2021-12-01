using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static int level=0;
    public GameObject[] enemmy_level;
    public static int[] enemyCount1= { 5, 10, 20, 30 };//5  10
    public GameObject[] Msg;
    // Use this for initialization
    void Start ()
    {
        //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // If the current level of enemmys is less than or equal to 0
        if (enemyCount1[level] <= 0)
        {
            // If the level has not finished yet
            if (level <= enemmy_level.Length - 1)
            {
                Debug.Log("OK");
                enemmy_level[level].SetActive(false);
                level++;
                if(level == 1)
                {
                    for (int i = 0; i < Msg.Length; i++)
                    {
                        Msg[i].GetComponent<Message>().Show(Message.MsgType.Level0_1);
                    }
                }
                else if(level == 2)
                {
                    for (int i = 0; i < Msg.Length; i++)
                    {
                        Msg[i].GetComponent<Message>().Show(Message.MsgType.Level1_2);
                    }
                }
                else
                {
                    for (int i = 0; i < Msg.Length; i++)
                    {
                        Msg[i].GetComponent<Message>().Show(Message.MsgType.Level99_);
                    }
                    //Application.Quit();
                }
                /*else if(level == 3)
                {
                    for (int i = 0; i < Msg.Length; i++)
                    {
                        Msg[i].GetComponent<Message>().Show(Message.MsgType.Level2_3);
                    }
                }*/
                if (level <= enemmy_level.Length - 1)
                    enemmy_level[level].SetActive(true);
            }
            else
            {
                for(int i = 0; i < Msg.Length; i++)
                {
                    Msg[i].GetComponent<Message>().Show(Message.MsgType.Level3_);
                }
            }
            
        }
	}
}
