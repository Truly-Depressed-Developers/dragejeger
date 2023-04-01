using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField] int laneCount = 5; 
    [SerializeField] int laneWidth => 1920 / laneCount; 
    [SerializeField] Lane lanePrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
