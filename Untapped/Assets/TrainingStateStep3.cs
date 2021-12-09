using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStateStep3 : TrainingState//: IState
{


    public TrainingState nextState; // Use this to assign the next state when this state is completed successfully. 


    [Multiline]
    public string step3 = "Step 3:\n";

    //public AudioClip audioClip;
    //private AudioSource audioSource;


    public TrainingStateStep3(TrainingManager manager)
    {
        _stateName = "Tutorial Step 3";
    }

    private void Start()
    {
        GlassEvents.OnPour += Pour;
    }

    public override IEnumerator OnStateEnter()
    {

        Debug.Log("OnStateEnter ... " + _stateName.ToString());

        _manager.textDisplay.SetDialogText(step3);
        //audioSource = _manager.audioSource;
        //audioSource.Stop();
        //audioSource.clip = audioClip;
        //audioSource.Play();


        //yield return new WaitForSeconds(audioSource.clip.length);


        //completedSuccesfully = true;

        Debug.Log("OnStateEnter completedSuccesfully " + _stateName.ToString());



        yield return StartCoroutine(base.OnStateEnter());

    }

    public void Pour(GameObject a, GameObject b)
    {
        if (_manager._currentStateIndex == this.index)
        {

            if (a.name == "Cranberry Juice" && _manager.SelectedGlass.Equals(b))
            {
                completedSuccesfully = true;
            }
            else
            {
                if (a.name != "Cranberry Juice")
                {
                    completedSuccesfully = false;
                    _manager.SetState(_manager.step1);
                    _manager.step1.step1 = "YOU FUCKED UP2. PICK A NEW GLASS";
                    _manager.textDisplay.SetDialogText(_manager.step1.step1);
                }
                else if (!_manager.SelectedGlass.Equals(b))
                {
                    step3 = "Pour into the selected whiskey glass.";
                    _manager.textDisplay.SetDialogText(step3);
                }
            }
        }
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