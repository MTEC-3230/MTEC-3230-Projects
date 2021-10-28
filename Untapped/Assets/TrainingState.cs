using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrainingState : MonoBehaviour//: IState
{

    protected BarTenderTraining _manager;
    public int index = -1; 
    public string _stateName = "TraingingState" ;
    public bool completedSuccesfully;


    // Components don't call constructor :{


    public virtual TrainingState TrainingStateConstructor(BarTenderTraining manager)
    {
        _manager = manager;

        return this; 
    }


    public virtual IEnumerator OnStateEnter() // Start()
    {

        Debug.Log("TrainingState Base : OnStateEnter : " + _stateName);

        yield return StartCoroutine(OnStateUpdate());

    }






    public virtual IEnumerator OnStateUpdate()
    {
        Debug.Log("TrainingState Base : OnStateUpdate : " + _stateName);
        yield return StartCoroutine(OnStateExit());

    }

    public virtual IEnumerator OnStateExit()
    {
        Debug.Log("TrainingState Base : OnStateExit : " + _stateName);
        completedSuccesfully = false; 
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