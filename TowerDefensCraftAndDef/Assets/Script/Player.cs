using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(1, 100)]
    private float _health;

    [SerializeField, Range(1, 10)]
    private float _moveSpeed;

    [SerializeField, Range(1, 100)]
    public float Experience;

    public GameObject GameOverPlaneUI;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GameOverPlaneUI.SetActive(true);
            Destroy(this);
        }
    }
    public void TakeExplore(float explore)
    {
        Experience += explore;
    }
    public void MoveToPoint(Vector3 pos)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, pos, _moveSpeed*Time.deltaTime);
    }


}
