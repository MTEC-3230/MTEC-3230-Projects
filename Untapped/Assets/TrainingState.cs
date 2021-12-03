using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrainingState : MonoBehaviour//: IState
{

    protected TrainingManager _manager;
    public int index = -1; 
    public string _stateName = "TraingingState" ;
    public bool completedSuccesfully;


    // Components don't call constructor :{
    //public TrainingState(TrainingManager manager)
    //{
    //    _manager = manager;
    //}

    public virtual TrainingState TrainingStateConstructor(TrainingManager manager)
    {
        _manager = manager;

        return this; 
    }


    // Do we need IState??
    //public override IEnumerator OnStateEnter()
    public virtual IEnumerator OnStateEnter() // Start()
    {

        Debug.Log("TrainingState Base : OnStateEnter : " + _stateName);
        // Change the Training Dialog and set the animation. 
        //yield return StartCoroutine(OnStateUpdate());

        yield return StartCoroutine(OnStateUpdate());

       // yield break;
    }






    public virtual IEnumerator OnStateUpdate()
    {
        Debug.Log("TrainingState Base : OnStateUpdate : " + _stateName);
        yield return StartCoroutine(OnStateExit());
        // yield break;
    }

    public virtual IEnumerator OnStateExit()
    {
        Debug.Log("TrainingState Base : OnStateExit : " + _stateName);
        completedSuccesfully = false; // reset the switch so you must complete again. 
        yield break;
    }

    public virtual IEnumerator Pause()
    {
        yield break;
    }

    public virtual IEnumerator Resume()
    {
        yield break;

    }
}