using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesGenerator : MonoBehaviour
{
    [SerializeField] private GameObject stalactitePrefab;
    [SerializeField] private GameObject stalactiteParent;
    [SerializeField] private GameObject stalagmitePrefab;
    [SerializeField] private GameObject stalagmiteParent;
    private float smallerSpacing => Random.Range(3, 6);
    private float biggerSpacing => Random.Range(5, 8);
    private List<GameObject> list = new List<GameObject>();
    private float spacingSum = 0;
    [SerializeField] private float stalagmiteChance = 0.5f;
    [SerializeField] private float stalactiteChance = 0.35f;
    [SerializeField] private float easySalactiteChance = 0.15f;
    enum Type { Stalactite, EasyStalactite, Stalagmite };
    private Type lastType;

    void Start()
    {
        for (int i = 0; i < 100; i++) {
            GameObject s;
            float newSpacing;
            if (Random.value <= stalagmiteChance) {
                if (lastType == Type.Stalagmite || lastType == Type.Stalactite) {
                    newSpacing = biggerSpacing;
                   } else {
                    newSpacing = smallerSpacing;
                   }                
                s = Instantiate(stalagmitePrefab);
                s.transform.parent = stalagmiteParent.transform;
                s.transform.localScale = new Vector3(Random.value > .5 ? 1 : -1, 1, 1);
                s.transform.localPosition = new Vector3(spacingSum + newSpacing, Random.Range(2f, 0f), 0);
                lastType = Type.Stalagmite;
            } else {
                s = Instantiate(stalactitePrefab);
                s.transform.parent = stalactiteParent.transform;
                Type type = Random.value < stalactiteChance / (stalactiteChance + easySalactiteChance) ? Type.Stalactite : Type.EasyStalactite;
                float h = type == Type.Stalactite ? -6 : Random.Range(-4, 0);
                if ((type == Type.Stalactite && lastType == Type.Stalagmite) ||
                    (type == Type.Stalactite && lastType == Type.Stalactite) ||
                    (type == Type.Stalagmite && lastType == Type.Stalactite)) {
                    newSpacing = biggerSpacing;
                   } else {
                    newSpacing = smallerSpacing;
                   }
                s.transform.localScale = new Vector3(Random.value > .5 ? 1 : -1, 1, 1);
                s.transform.localPosition = new Vector3(spacingSum + newSpacing, h, 0);
                lastType = type;
            }
            spacingSum += newSpacing;
            list.Add(s);
        }
    }
}
