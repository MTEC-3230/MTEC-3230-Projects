using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

using UnityEngine.Playables;


public enum TutorialSteps
{

    //TutorialDrillState,         //  Step 1 How to use a drill
    //TutorialScrewDriverState,   //  Step 2 How to use a screwdriver
    //TutorialPickupWoodState,     // Step 3 How to pick up wood
    //TutorialAlignWoodState,
    //TutorialPickupDrillState,
    //TutorialUseDrillState,


    //TrainingPicksupWoodState,
    //TrainingAlignsWoodState,
    //TrainingDrillWoodState,
    //TrainingPlacesScrewState,
    //TrainingScrewDriverState,
    //TrainingTightenScrewState,
    //TrainingCompleted,

    Step1, // display ingredients ie. orange juice and vodka
    Step2, // grab a glass
    Step3, // wait for user to add ingredients
    Step4,
    Step5,
    Step6,
    Step7,
    Complete
    
};

public class BarTenderTraining : TrainingManager//: StateMachine
{

    // Treat the Training Manager like a FSM. 
    // We start off by running through each step of the tutorial. 
    // We can return to each step if the trainee is having difficulty with a particular stage. 


    public PlayableDirector director;


    void OnEnable()
    {
        director.played += OnPlayableDirectorPlayed;
    }

    void OnPlayableDirectorPlayed(PlayableDirector aDirector)
    {
        if (director == aDirector)
            Debug.Log("PlayableDirector named " + aDirector.name + " is now playing.");
    }

    void OnDisable()
    {
        director.played -= OnPlayableDirectorPlayed;
    }




    public AudioSource audioSource;

    public AudioClip introAudio1;
    public AudioClip introAudio2; 



    private Dictionary<TutorialSteps, TrainingState> dictionary = new Dictionary<TutorialSteps, TrainingState>();
    private int _currentStateIndex; 

    TrainingState step1 ;
    TrainingState step2 ;
    //TrainingState step3 ;
    //TrainingState step4 ;
    //TrainingState step5 ;



    [SerializeField] private TextDisplay display;

    private TrainingState _currentState;
    private TrainingState _previousState;


    public TextDisplay textDispay => display;


    // 
    public void OnEventDataRecieved(object sender, EventDataArgs e)
    {

        Debug.Log("Event data received. Update tutorial step to : " + e.step_id);

        // Test if step_id between min and max enum vals
        bool valid_step = e.step_id >= 0 && e.step_id < Enum.GetValues(typeof(TutorialSteps)).Length;

        if(valid_step)
            SetState(dictionary[(TutorialSteps) e.step_id]) ;
    }





    //public void NextState()
    //{
    //    SetState(_currentStateIndex + 1); 
    //}

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

    IEnumerator PlayIntro()
    {
        audioSource.clip = introAudio1;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        audioSource.Stop();
        audioSource.clip = introAudio2;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        SetupTraining();
    }

    public void SetupTraining()
    {
        Debug.Log("TrainingManager SetupTraining");
        //Initialize(new TutorialDrillState(this));  // Step 1
        Initialize(step1);

    }
    // Start is called before the first frame update
    public void Start()
    {

        // All Components must not be created with "new". Components always need to be created with AddComponent. 
        // Components can only "live" on GameObjects.
        step1 = this.GetComponent<ChoosingRecipe>().TrainingStateConstructor(this);
        step2 = this.GetComponent<SelectingGlass>().TrainingStateConstructor(this);
        //step3 = this.getcomponent<tutorialpickupwoodstate>().trainingstateconstructor(this);
        //step4 = this.getcomponent<tutorialalignwoodstate>().trainingstateconstructor(this);
        //step5 = this.getcomponent<tutorialpickupdrillstate>().trainingstateconstructor(this);
        //step6 = this.GetComponent<TutorialUseDrillState>().TrainingStateConstructor(this);
        //step7 = this.GetComponent<TrainingPicksupWoodState>().TrainingStateConstructor(this);
        //step8 = this.GetComponent<TrainingAlignsWoodState>().TrainingStateConstructor(this);
        //step9 = this.GetComponent<TrainingDrillWoodState>().TrainingStateConstructor(this);
        //step10 = this.GetComponent<TrainingPlacesScrewState>().TrainingStateConstructor(this);
        //step11 = this.GetComponent<TrainingScrewDriverState>().TrainingStateConstructor(this);
        //step12 = this.GetComponent<TrainingTightenScrewState>().TrainingStateConstructor(this);
        //step13 = this.GetComponent<TrainingCompleted>().TrainingStateConstructor(this);




        // --- Fill in keys and values

        dictionary.Add((TutorialSteps)0, step1);
        dictionary.Add((TutorialSteps) 1, step2);
        //dictionary.Add( (TutorialSteps) 2, step3);
        //dictionary.Add((TutorialSteps) 3, step4);
        //dictionary.Add((TutorialSteps) 4, step5);


        //for(int i= 0; i< (int) TutorialSteps.LastEnumState; i++ )
        //{

        //    dictionary.Add(i, List....
        //}

        // Subscribe to events


        StartCoroutine(PlayIntro()); 

    }

    // Update is called once per frame
    public void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Setting State to step 1.");
            SetState(step1); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

            Debug.Log("Setting State to step 2.");

            SetState(step2);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{

        //    Debug.Log("Setting State to step 3.");

        //    SetState(step3);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{


        //    Debug.Log("Setting State to step 4.");

        //    SetState(step4);
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{


        //    Debug.Log("Setting State to step 5.");

        //    SetState(step5);
        //}



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



       // Debug.Log("Setting State : " + newState._stateName);

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



