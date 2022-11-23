using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class InteractiveObjects:MonoBehaviour
{
    [SerializeField]
    protected bool _onClick = false;

    public Player Player;
    public Game Game;
    public Canvas Menu;
    public TextMeshProUGUI _viewOfInteractiveObject;
    public GameObject Detector;
    private bool _onTriggerEnter=false;
    private Color mat;

    private void Awake()
    {
        Game= GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _viewOfInteractiveObject = Game.ViewInteractiveObject;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        mat = Detector.GetComponent<Renderer>().material.color;
    }
    public void OnClick(bool onClick)

    {
        _onClick = onClick;
        if (_onClick)
        {
            DoItOfInteractiveObject();
        }
    }
    public void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            OnClick(true);
        }
    }

    public virtual void DoItOfInteractiveObject()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
       
        
        Debug.Log("OnTriggrEnter-work");
        Detector.GetComponent<Renderer>().material.color = Color.white;
            
        
        

    }
     public void OnTriggerExit (Collider other)
    {
        Detector.GetComponent<Renderer>().material.color = mat;
        Debug.Log("OnTriggrExit-work");

    }
   
}
