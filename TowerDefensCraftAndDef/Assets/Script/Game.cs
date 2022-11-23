using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Vector2Int _planeSize;

    [SerializeField]
    private GamePlane _plane;

    public Player Player;
    public TextMeshProUGUI ViewInteractiveObject;
    public GenerateOfInteractiveObjects GenerateOfInteractiveObjects;
    


    public InteractiveObjects _interactiveObject;
    public Vector3 pos;
    private void Start()
    {
        _plane.Initialize(_planeSize);
        _interactiveObject = FindObjectOfType<InteractiveObjects>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GenerateOfInteractiveObjects= GameObject.FindGameObjectWithTag("Game").GetComponent<GenerateOfInteractiveObjects>();
       // GenerateOfInteractiveObjects.RandomInitializeInreacriveObjects();


    }
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
           
        }
        Player.MoveToPoint(pos);
        
    }
    
}
