using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingStateStep4 : TrainingState
{
    
    public TrainingState nextState; // Use this to assign the next state when this state is completed successfully. 
    public GameObject selectedGlass = null;
    
    [Multiline]
    public string step1 = "Step 4:\n";

    //public AudioClip audioClip;
    //private AudioSource audioSource;


    private void Start()
    {
        GlassEvents.OnPickup += CheckPickup;
    }


    public void CompleteStep()
    {
        completedSuccesfully = true; 
    }

    public void CheckPickup(GameObject a)
    {
        if (_manager._currentStateIndex == this.index)
        {
            Glass thisGlass = a.GetComponent<Glass>();
            if (thisGlass == null)
            {
                Debug.Log("What the FUCK");
                return;
            }
            if (a.name == "Coupe Glass" && thisGlass.currentDrinks.Count == 0)
            {
                selectedGlass = a;
                completedSuccesfully = true;
            }
            else
            {
                if (thisGlass.currentDrinks.Count > 0)
                {
                    step1 = "Pick up an empty Coupe Glass. It's the glass with the widest brim.";
                    _manager.textDisplay.SetDialogText(step1);
                }
                else
                {
                    step1 = "Wrong glass! Pick up the Coupe Glass. It's the glass with the widest brim.";
                    _manager.textDisplay.SetDialogText(step1);
                }
            }
        }
    }
    
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
        _manager.SelectedGlass = selectedGlass;
        Debug.Log("OnStateExit : " + _stateName);
        yield return StartCoroutine(base.OnStateExit());

        Debug.Log("OnStateExit completed Succesfully " + _stateName.ToString());


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
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                this.completedSuccesfully = true;
            }
        }
    }
}
