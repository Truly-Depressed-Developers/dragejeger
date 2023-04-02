using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingGenerator : MonoBehaviour
{
    [SerializeField] private float spacing = 17.5f;
    [SerializeField] private GameObject ceilingPrefab;
    void Start()
    {
        for (int i = 0; i < 30; i++) {
            GameObject s = Instantiate(ceilingPrefab);
            s.transform.parent = transform;
            s.transform.localPosition = new Vector3(i * spacing, 0, 0);
        }
    }
}
