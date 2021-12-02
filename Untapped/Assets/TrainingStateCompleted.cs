using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStateStep4 : TrainingState//: IState
{


    public TrainingState nextState; // Use this to assign the next state when this state is completed successfully. 


    [Multiline]
    public string step1 = "Step 4:\n";

    //public AudioClip audioClip;
    //private AudioSource audioSource;


    public TrainingStateStep4(TrainingManager manager)
    {
        _stateName = "Tutorial Step 4";
    }


    public override IEnumerator OnStateEnter()
    {

        Debug.Log("OnStateEnter ... " + _stateName.ToString());

        _manager.textDisplay.SetDialogText(step1);
        //audioSource = _manager.audioSource;
        //audioSource.Stop();
        //audioSource.clip = audioClip;
        //audioSource.Play();


        //yield return new WaitForSeconds(audioSource.clip.length);


        completedSuccesfully = true;

        Debug.Log("OnStateEnter completedSuccesfully " + _stateName.ToString());



        yield return StartCoroutine(base.OnStateEnter());

    }






    public override IEnumerator OnStateUpdate()
    {
        while (true)
        {


            // Check for condition here before moving on . 

            if (completedSuccesfully)
            {
                Debug.Log("OnStateUpdate completedSuccesfully " + _stateName.ToString());


                break;
            }


            yield return null;
        }
        yield return StartCoroutine(base.OnStateUpdate());

    }

    public override IEnumerator OnStateExit()
    {
        Debug.Log("OnStateExit : " + _stateName);
        yield return StartCoroutine(base.OnStateExit());

        Debug.Log("OnStateExit completedSuccesfully " + _stateName.ToString());


        Debug.Log("OnStateExit Setting next state to nextState. " + nextState.ToString());

        _manager.SetState(nextState);
    }

    public override IEnumerator Pause()
    {
        yield break;
    }

    public override IEnumerator Resume()
    {
        yield break;

    }
}