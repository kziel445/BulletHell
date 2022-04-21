using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Invulnerable : MonoBehaviour
    {
        Collider2D collider;
        BulletFury.BulletCollider colliderBullets;
        public Color col = new Color(255, 0, 0, 255);
        private void Awake()
        {
            collider = gameObject.GetComponent<Collider2D>();
            colliderBullets = gameObject.GetComponent<BulletFury.BulletCollider>();
        }
        public IEnumerator InvulnerableStart()
        {
            collider.enabled = false;
            colliderBullets.enabled = false;
            gameObject.GetComponent<SpriteRenderer>().color = col;
            Debug.Log(gameObject.GetComponent<SpriteRenderer>().color.r);
            yield return new WaitForSeconds(3f);
            collider.enabled = true;
            colliderBullets.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        }


    }
}

