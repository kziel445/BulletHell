using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCollidersGenerator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D[] collidersList = new BoxCollider2D[4];
    Vector2 screenBounds;
    [SerializeField] float boundsSize = 0.1f;

    private void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
            collidersList[i] = collider;
        }
    }
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SetColliderSize(0, screenBounds.x, 0, boundsSize, screenBounds.y);
        SetColliderSize(1, 0, screenBounds.y, screenBounds.x, boundsSize);
        SetColliderSize(2, -screenBounds.x, 0, boundsSize, screenBounds.y);
        SetColliderSize(3, 0, -screenBounds.y, screenBounds.x, boundsSize);
    }
    private void SetColliderSize(
        int colliderNum, 
        float xOffset = 0, float yOffset = 0,
        float xSize = 0, float ySize = 0)
    {
        collidersList[colliderNum].offset = new Vector2(xOffset, yOffset);
        collidersList[colliderNum].size = new Vector2(xSize * 2, ySize * 2);
    }
}
