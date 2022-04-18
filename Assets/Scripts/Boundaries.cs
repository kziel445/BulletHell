using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    Vector2 screenBounds;
    Vector2 objectSize;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectSize = transform.GetComponent<SpriteRenderer>().bounds.size/2;
    }

    private void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x * -1 + objectSize.x, screenBounds.x - objectSize.x);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBounds.y * -1 + objectSize.y, screenBounds.y - objectSize.y);
        transform.position = viewPosition;
    }
}
