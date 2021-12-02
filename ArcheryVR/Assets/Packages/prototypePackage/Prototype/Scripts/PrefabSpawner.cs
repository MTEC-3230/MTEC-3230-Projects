using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PrefabSpawner : XRSocketInteractor
{
    [SerializeField] GameObject prefab = default;
    private Vector3 attachOffset = Vector3.zero;
    public Arrow currentArrow;

    [Header("Sound")]
    public AudioClip grabClip;

    protected override void Awake()
    {
        base.Awake();
        CreateAndSelectPrefab();
        SetAttachOffset();
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        CreateAndSelectPrefab();
    }


    //protected override void OnSelectExited(XRBaseInteractable interactable)
    //{
    //    base.OnSelectExited(interactable);
    //    CreateAndSelectPrefab();
    //}

    void CreateAndSelectPrefab()
    {
        Arrow interactable = CreatePrefab();
        SelectPrefab(interactable);

    }
    Arrow CreatePrefab()
    {
        currentArrow = Instantiate(prefab, transform.position - attachOffset, transform.rotation).GetComponent<Arrow>();
        return currentArrow;
    }
    void SelectPrefab(Arrow interactable)
    {

        SelectEnterEventArgs args = new SelectEnterEventArgs();
        args.interactableObject = interactable; 


        OnSelectEntered(args);
        //OnSelectEntered(interactable);
        interactable.OnSelectEnter(this);
    }

    void SetAttachOffset()
    {

        if (selectTarget.GetOldestInteractorSelecting() is XRGrabInteractable interactable)
        {
            attachOffset = interactable.attachTransform.localPosition;
        }


        //if (selectTarget is XRGrabInteractable interactable)
        //{
        //    attachOffset = interactable.attachTransform.localPosition;
        //}
    }

    public void ForceDeinteract(XRBaseInteractable interactable)
    {
        //OnSelectExited(interactable);
        SelectExitEventArgs args = new SelectExitEventArgs();
        args.interactableObject = interactable; 
        OnSelectExited( args);
    }
}
