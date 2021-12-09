using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

using UnityEngine.Playables;




public class TrainingManager : MonoBehaviour//: StateMachine
{

    // Treat the Training Manager like a FSM. 
    // We start off by running through each step of the tutorial. 
    // We can return to each step if the trainee is having difficulty with a particular stage. 


    //public PlayableDirector director;



    void OnEnable()
    {
        //director.played += OnPlayableDirectorPlayed;
    }

    void OnPlayableDirectorPlayed(PlayableDirector aDirector)
    {
        //if (director == aDirector)
        //    Debug.Log("PlayableDirector named " + aDirector.name + " is now playing.");
    }

    void OnDisable()
    {
        //director.played -= OnPlayableDirectorPlayed;
    }


    //public AudioSource audioSource;

    //public AudioClip introAudio1;
    //public AudioClip introAudio2;

    private Dictionary<TutorialSteps, TrainingState> dictionary = new Dictionary<TutorialSteps, TrainingState>();


    public int _currentStateIndex;


    public TrainingStateStep1 step1;
    public TrainingStateStep2 step2;
    public TrainingStateStep3 step3;
    public TrainingStateStep4 step4;
    public GameObject SelectedGlass;


    [SerializeField] private TextDisplay display;

    private TrainingState _currentState;
    private TrainingState _previousState;


    public TextDisplay textDisplay => display;


    public void NextState()
    {
        SetState(_currentStateIndex + 1);
    }

    public void SetState(int step_id)
    {
        bool valid_step = step_id >= 0 && step_id < Enum.GetValues(typeof(TutorialSteps)).Length;

        if (valid_step)
            SetState(dictionary[(TutorialSteps)step_id]);
    }

    public void PreviousState()
    {

        if (_previousState != null)
            SetState(_previousState); 
    }

    //IEnumerator PlayIntro()
    //{
    //    audioSource.clip = introAudio1;
    //    audioSource.Play();
    //    yield return new WaitForSeconds(audioSource.clip.length);

    //    audioSource.Stop();
    //    audioSource.clip = introAudio2;
    //    audioSource.Play();
    //    yield return new WaitForSeconds(audioSource.clip.length);

    //    SetupTraining();
    //}

    public void SetupTraining()
    {
        Debug.Log("TrainingManager SetupTraining");
        //Initialize(new TutorialDrillState(this));  // Step 1
        Initialize(step1);

    }
    // Start is called before the first frame update
    public void Start()
    {
        
        // Subscribe to events

        // Play Intro 
        //StartCoroutine(PlayIntro()); 
        SetupTraining();

    }
    
    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Setting State to step 1.");
            SetState(step1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Debug.Log("Setting State to step 2.");

            SetState(step2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            Debug.Log("Setting State to step 3.");

            SetState(step3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {


            Debug.Log("Setting State to step 4.");

            SetState(step4);
        }




    }


    public void Initialize(TrainingState startingState)
    {

        Debug.Log("TrainingManager : Initialize " + startingState._stateName.ToString());

        _currentState = startingState;
        _currentStateIndex = 0; 
        StartCoroutine(startingState.OnStateEnter());
    }

    public void SetState(TrainingState newState)
    {

        StopAllCoroutines(); 


        _previousState = _currentState;
        _currentStateIndex = newState.index;
        _currentState = newState;

        StartCoroutine(newState.OnStateEnter());
    }
    private void OnDestroy()
    {
        // Unsubscribe to events

 

    }




}



