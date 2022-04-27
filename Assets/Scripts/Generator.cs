using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // [SerializeField] GameObject gun;
    public BulletFury.Data.BulletSettings bulletSeting;
    public BulletFury.Data.SpawnSettings spawnSeting;
    Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            SpawnTurret();
            BulletsRandom();
        }
    }
    void BulletsRandom()
    {
        float yPos, xPos;
        int axis = Random.Range(0, 2);
        int side = Random.Range(0, 2);
        if (axis == 1)
        {
            yPos = Random.Range(screenBounds.y * -1, screenBounds.y);
            if (side == 1) xPos = screenBounds.x * -1;
            else xPos = screenBounds.x;
        }
        else
        {
            if (side == 1) yPos = screenBounds.y * -1;
            else yPos = screenBounds.y;
            xPos = Random.Range(screenBounds.x * -1, screenBounds.x);
            
        }

        //gun.AddComponent<BulletFury.Demo.TestWeapon>();
        //gun.GetComponent<BulletFury.BulletManager>().enabled = true;
        //gun.GetComponent<BulletFury.BulletManager>().SetBulletSettings(bulletSeting);
        //gun.GetComponent<BulletFury.BulletManager>().SetSpawnSettings(spawnSeting);
        //gun.GetComponent<BulletFury.Demo.TestWeapon>().bulletManager = gun.GetComponent<BulletFury.BulletManager>();

    }
    void SpawnTurret()
    {
        GameObject gun = new GameObject();
        gun.AddComponent<BulletFury.BulletManager>();
        gun.AddComponent<BulletFury.Demo.TestWeapon>();
        
        gun.GetComponent<BulletFury.BulletManager>().SetBulletSettings(bulletSeting);
        gun.GetComponent<BulletFury.BulletManager>().SetSpawnSettings(spawnSeting);
        gun.GetComponent<BulletFury.BulletManager>().enabled = true;
        gun.GetComponent<BulletFury.Demo.TestWeapon>().bulletManager = gun.GetComponent<BulletFury.BulletManager>();
    }
}
