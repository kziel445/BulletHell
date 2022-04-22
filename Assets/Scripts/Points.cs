using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Points : MonoBehaviour
{
    [SerializeField] private PointsGet OnPointsGet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnPointsGet?.Invoke(100);
        Destroy(gameObject);
    }
}
[Serializable]
public class PointsGet : UnityEvent<int>
{

}