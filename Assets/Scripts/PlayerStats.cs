using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        public int health = 5;
        private SpriteRenderer[] heartsSprites = new SpriteRenderer[5];
        private Transform heartsContainer;
        [SerializeField] private GameObject heartPrefab;


        public int points;
        private TMPro.TextMeshProUGUI textBox;

        private GameObject EndScreen;

        private void Awake()
        {
            EndScreen = GameObject.Find("EndScreen");
            setEndScreen(false);
            
            float xPos = -8.2f;
            heartsContainer = GameObject.Find("Hearts").transform;
            for (int i = 0; i < health; i++)
            {
                Instantiate(heartPrefab, new Vector3(xPos, 4.3f, -9)
                    , Quaternion.identity, heartsContainer);
                xPos += 1.4f;
            }
            textBox = GameObject.Find("PointsStored").GetComponentInChildren<TMPro.TextMeshProUGUI>();
        }
        void Start()
        {
            int i = 0;
            foreach (Transform component in heartsContainer)
            {
                heartsSprites[i] = component.GetComponent<SpriteRenderer>();
                i++;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void GetDamage()
        {
            if (health > 0)
            {
                heartsSprites[health - 1].enabled = false;
                health--;
                StartCoroutine(gameObject.GetComponent<Invulnerable>()
                    .InvulnerableStart());
                if(health == 0)
                {
                    setEndScreen(true);
                    Destroy(gameObject);
                }
            }
        }
        public void getPoints(int pointsAmount)
        {
            points += pointsAmount;
            textBox.text = points.ToString("000000");

        }
        public void setEndScreen(bool active)
        {
            EndScreen.active = active;
        }
    }
}

