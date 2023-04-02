using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] private float spacing = 12.1f;
    [SerializeField] private GameObject floorPrefab;
    void Start()
    {
        for (int i = 0; i < 50; i++) {
            GameObject s = Instantiate(floorPrefab);
            s.transform.parent = transform;
            s.transform.localPosition = new Vector3(i * spacing, 0, 0);
        }
    }
}
