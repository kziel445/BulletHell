using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using BulletFury.Data;

public class Laser : MonoBehaviour
{
    [SerializeField] private LaserHitEvent OnLaserHit;
    private void LateUpdate()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {          
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().GetDamage();
            OnLaserHit?.Invoke(collision.gameObject
                .GetComponent<Collider2D>().ClosestPoint(transform.position));
        }
    }
    [Serializable]
    public class LaserHitEvent : UnityEvent<Vector3>
    {
    }
}
