using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Notch : XRSocketInteractor
{
    private PullInteraction pullInteraction;
    private Arrow currentArrow;

    [Header("Sound")]
    public AudioClip attatchClip;
    protected override void Awake()
    {
        base.Awake();
        pullInteraction = GetComponent<PullInteraction>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        //pullInteraction.onSelectExited.AddListener(TryToReleaseArrow);
        pullInteraction.selectExited.AddListener(TryToReleaseArrowNew);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        //pullInteraction.onSelectExited.AddListener(TryToReleaseArrow);
        pullInteraction.selectExited.AddListener(TryToReleaseArrowNew);

    }

    //protected override void OnSelectEntered(XRBaseInteractable interactable)
    //{
    //    // FIXME

    //    base.OnSelectEntered(interactable);
    //    StoreArrow(interactable);
    //}

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {       
        base.OnSelectEntered(args);
        StoreArrow(args.interactable);
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        XRBaseInteractable interactable = args.interactable; 

        if (interactable is Arrow arrow && arrow.selectingInteractor is HandInteractor hand)
        {
            
            //arrow.OnSelectExit(hand);
            arrow.SelectExit(hand); 
            hand.ForceDeinteract(arrow);
            pullInteraction.ForceInteract(hand);
            hand.ForceInteract(pullInteraction);

            NotchSounds(attatchClip, 3, 3.3f, 5);
        }
    }

    private void StoreArrow(XRBaseInteractable interactable)
    {
        if (interactable is Arrow arrow)
            currentArrow = arrow;
    }

    private void TryToReleaseArrowNew(SelectExitEventArgs args)
    {
        if (currentArrow)
        {
            ForceDeselect(args.interactor);
            ReleaseArrow();
        }
    }


    private void TryToReleaseArrow(XRBaseInteractor interactor)
    {
        if (currentArrow)
        {
            ForceDeselect(interactor);
            ReleaseArrow();
        }
    }

    private void ForceDeselect(XRBaseInteractor interactor)
    {
        //base.OnSelectExit(currentArrow);
        SelectExitEventArgs args = new SelectExitEventArgs();
        //args.interactorObject = interactor;  // For XRI 2.0
        //args.interactableObject = currentArrow;
        args.interactor = interactor;
        args.interactable = currentArrow;

        //args.manager = null;
        args.isCanceled = false; 
        base.OnSelectExited(args);

        
        //currentArrow.OnSelectExit(this);
        currentArrow.SelectExit(this); 
    }

    private void ReleaseArrow()
    {
        currentArrow.Release(pullInteraction.PullAmount);
        currentArrow = null;
    }

    public override XRBaseInteractable.MovementType? selectedInteractableMovementTypeOverride
    {
        get { return XRBaseInteractable.MovementType.Instantaneous; }
    }

    void NotchSounds(AudioClip clip, float minPitch, float maxPitch, int id)
    {
        SFXPlayer.Instance.PlaySFX(clip, transform.position, new SFXPlayer.PlayParameters()
        {
            Pitch = Random.Range(minPitch, maxPitch),
            Volume = 1.0f,
            SourceID = id
        });
    }

}