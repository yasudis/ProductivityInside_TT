using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlane : MonoBehaviour
{
    [SerializeField]
    private Transform _plane;

    private Vector2Int _size;

    public void Initialize(Vector2Int size)
    {
        _size = size;
        _plane.localScale = new Vector3(size.x, size.y, z:1f);
    }
}
