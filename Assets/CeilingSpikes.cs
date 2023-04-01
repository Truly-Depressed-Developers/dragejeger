using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingSpikes : MonoBehaviour
{
    [SerializeField] private GameObject stalactitePrefab;
    [SerializeField] private float spacing = 20f;
    private List<GameObject> stalactiteList = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 100; i++) {
            GameObject s = Instantiate(stalactitePrefab);
            s.transform.parent = transform;
            s.transform.localPosition = new Vector3(i * spacing, Random.Range(-5, 0), 0);
            stalactiteList.Add(s);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
