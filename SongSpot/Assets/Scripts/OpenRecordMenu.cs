using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRecordMenu : MonoBehaviour
{

    public bool StateOpen, StateClose;



    // Update is called once per frame
    void Update()
    {



        if (StateOpen)
        {

               // GetComponent<Animation>().CrossFade("ButtonSelected_1");
                StartCoroutine(PlayOpen());




            StateOpen = false;
        }

        if (StateClose)
        {


              GetComponent<Animation>()["mainMenuCanvas_Level_1"].normalizedTime = 1f;
              GetComponent<Animation>()["mainMenuCanvas_Level_1"].speed = -1;
              GetComponent<Animation>().Play("mainMenuCanvas_Level_1");

                




            StateClose = false;
        }

    }


    IEnumerator PlayOpen()
    {
        yield return new WaitForSeconds(1);




            GetComponent<Animation>().Play("mainMenuCanvas_Level_1");
            GetComponent<Animation>()["mainMenuCanvas_Level_1"].speed = 1.0f;
            yield return new WaitForSeconds(2);




    }


}
