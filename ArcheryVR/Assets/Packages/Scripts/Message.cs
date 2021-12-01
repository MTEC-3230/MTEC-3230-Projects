using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour
{

    public Text MessageBox;

    public enum MsgType
    {
        Near = 0,
        Lose = 1,
        SpawnLeft = 2,
        SpawnRight = 3,
        Level0_1 = 41,
        Level1_2 = 42,
        Level2_3 = 43,
        Level3_ = 44,
        Level99_ = 99
    }

    [SerializeField]
    private float interval = 5f;//Message display time is not set to 5 seconds
    private float timeCount = 5;//Timer
    private float ENDTime = -1;//last moment

    // Use this for initialization
    void Start()
    {
        //MessageBox.text = string.Format("The game begins, Sao years care ~");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //If the countdown is finished, clear the display
        if (timeCount > 0)
        {
            timeCount -= Time.deltaTime;
        }
        else
        {
            MessageBox.text = string.Format("");
            timeCount = interval;
        }

        if (ENDTime > 0)
        {
            Debug.Log("Declining, don't worry");
            ENDTime -= Time.deltaTime;
        }
        if (ENDTime > 0 && ENDTime < 1)
        {
            Debug.Log("This time should be closed");
            Application.Quit();
        }
    }

    public void Show(MsgType _MsgType)
    {
        Debug.Log("Called show function");
        //Let each message show interval seconds
        timeCount = interval;

        switch (_MsgType)
        {
            case MsgType.Near:
                {
                    MessageBox.text = string.Format("Zombie to your doorstep！");
                }
                break;
            case MsgType.Lose:
                {
                    MessageBox.text = string.Format("Zombies eat your brain! \n\nNext time");
                    ENDTime = 5;
                }
                break;
            case MsgType.SpawnLeft:
                {
                    MessageBox.text = string.Format("You switch to the next attack point!");
                }
                break;
            case MsgType.SpawnRight:
                {
                    MessageBox.text = string.Format("You switch to the previous attack point");
                }
                break;
            case MsgType.Level0_1:
                {
                    MessageBox.text = string.Format("Congratulations on passing the novice level\n below to enter the first level");
                }
                break;
            case MsgType.Level1_2:
                {
                    MessageBox.text = string.Format("Congratulations on passing the first pass\n below the second pass");
                }
                break;
            case MsgType.Level2_3:
                {
                    MessageBox.text = string.Format("Congratulations to you through the second level\n below to enter the third level");
                }
                break;
            case MsgType.Level3_:
                {
                    MessageBox.text = string.Format("Congratulations to you through the second level \n below to enter the fourth level");
                }
                break;
            case MsgType.Level99_:
                {
                    MessageBox.text = string.Format("Congratulations on sharing your game with the relevant cards\n~~");
                    timeCount = 10;
                    ENDTime = 10;
                }
                break;
        }
    }
}
