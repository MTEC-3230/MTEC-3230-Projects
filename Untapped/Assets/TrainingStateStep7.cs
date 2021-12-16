using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStateStep7 : TrainingState
{
    
    public TrainingState nextState; // Use this to assign the next state when this state is completed successfully. 
    public GameObject selectedGlass = null;
    
    [Multiline]
    public string step1 = "Step 6:\n";

    //public AudioClip audioClip;
    //private AudioSource audioSource;


    private void Start()
    {
        GlassEvents.OnStopPour += Pour;
    }

    public void Pour(GameObject a, GameObject b)
    {
        if (_manager._currentStateIndex == this.index)
        {

            if (a.name == "Grenadine" && _manager.SelectedGlass.Equals(b))
            {
                completedSuccesfully = true;
            }
            else
            {
                if (a.name != "Grenadine")
                {
                    completedSuccesfully = false;
                    _manager.SetState(_manager.step4);
                    _manager.step4.step1 = "Try again. Pick another empty Coupe Glass.";
                    _manager.textDisplay.SetDialogText(_manager.step4.step1);
                }
                else if (!_manager.SelectedGlass.Equals(b))
                {
                    step1 = "Pour into the prepared glass.";
                    _manager.textDisplay.SetDialogText(step1);
                }
            }
        }
    }
    
    public void CompleteStep()
    {
        completedSuccesfully = true; 
    }

    public TrainingStateStep7(TrainingManager manager)
    {
        _stateName = "Tutorial Step 7";
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


        //completedSuccesfully = true;

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
    public void Update()
    {
        if (_manager.devMode)
        {
            if (Input.GetKeyUp(KeyCode.Keypad7))
            {
                this.completedSuccesfully = true;
            }
        }
    }
}
