using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class RandomNotes : MonoBehaviour
    {
        private static RandomNotes _objectPooler;
    
        [SerializeField] private GameObject pooledObject = null;
        [SerializeField] private int pooledAmount = 10;
        [SerializeField] private bool willGrow = true;

        [SerializeField] private List<GameObject> pooledObjects;

        public RandomNotes pooler;

        public GameObject[] spawnPoints;

        public float spawnTime = 2f;
        public float spawnBuffer = 3f;
        
        private void Awake() => _objectPooler = this; 

        private void Start()
        {
            pooledObjects = new List<GameObject>();
        
            for (var i = 0; i < pooledAmount; i++)
            {
                var obj = (GameObject)Instantiate(pooledObject);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
            InvokeRepeating(nameof(SpawnNotes), spawnBuffer, spawnTime);
        }
        public GameObject GetPooleObject()
        {
            foreach (var t in pooledObjects.Where(t => !t.activeInHierarchy))
            {
                return t;
            }
        
            if (!willGrow) return null;
        
            var obj = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(obj);
        
            return obj;
        }
        
        public static void ReturnToPool(GameObject obj)
        {
            obj.SetActive(false);
        }
        public void SpawnNotes()
        {
            var obj = pooler.GetPooleObject();
           
            obj.SetActive(true);
            obj.transform.position = spawnPoints[RandomSpawn()].transform.position;
        }

        private int RandomSpawn()
        {
            return Random.Range(0, spawnPoints.Length);
        }
    }


