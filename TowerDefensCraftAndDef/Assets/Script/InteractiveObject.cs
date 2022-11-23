using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using Newtonsoft.Json;

public class InteractiveObject : InteractiveObjects
{
   // [SerializeField]
   //private TextMeshProUGUI _viewOfInteractiveObject;

    [SerializeField]
    public bool _modOnOfView;

    [SerializeField]
    private bool _modOnDestroy;

    [SerializeField, Range(1, 10)]
    int _healthInteractiveObject;

    [SerializeField]
    private bool _modOnTakeExplore;

    [SerializeField, Range(1f, 10f)]
    private float _experience;

    [SerializeField]
    private bool _modOnTakeDamadge;

    [SerializeField, Range(1f, 10f)]
    private float _damadge;

    [SerializeField]
    private bool _modOnEnableUseInetactiveObject;

    [SerializeField, Range(1, 100)]
    private float _necessaryExperience;

    private void ViewOfInteractiveObject(bool modOnOfView)
    {
        modOnOfView = _modOnOfView;
        if (modOnOfView && _onClick)
        {
            Debug.Log("View-Its WOrk");
            _viewOfInteractiveObject.gameObject.SetActive(true);
        }
    }

    private void DestroyInteractiveObject(bool modOnDestroy)
    {
        modOnDestroy = _modOnDestroy;
        if (modOnDestroy && _onClick)
        {
            Debug.Log("Destroy-Its WOrk");
            _healthInteractiveObject -= 1;
            if (_healthInteractiveObject <= 0)
            {
                GameObject.Destroy(gameObject);
            }
            
        }
    }

    private void TakeExperienceToPlayer(bool explore)
    {
        if (explore && _onClick)
        {
            Debug.Log("TakeExplore-Its WOrk");
            Player.TakeExplore(_experience);
        }
    }

    private void TakeDamadgeToPlayer(bool modOnTakeDamadge)
    {
        if (modOnTakeDamadge && _onClick)
        {
            Debug.Log("TakeDamadge-Its WOrk");
            Player.TakeDamage(_damadge);
        }
    }
    private bool EnableUseInetactiveObject(bool modOnEnableUseInetactiveObject)
    {
        if (modOnEnableUseInetactiveObject)
        {
            if (_necessaryExperience > Player.Experience)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else 
        {
            return true;
        }
        
    }


    public override void DoItOfInteractiveObject()
    {
        if (EnableUseInetactiveObject(_modOnEnableUseInetactiveObject)) 
        {
            ViewOfInteractiveObject(_modOnOfView);
            DestroyInteractiveObject(_modOnDestroy);
            TakeExperienceToPlayer(_modOnTakeExplore);
            TakeDamadgeToPlayer(_modOnTakeDamadge);
            _onClick = false;
        }
    }
}




