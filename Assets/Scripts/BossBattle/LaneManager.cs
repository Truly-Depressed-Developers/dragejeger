using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
   /**
    * Lines Setup | Serialize Fields
    */
   public int laneCount = 5;
   [SerializeField] float laneWidth => (MainCamera.instance.cameraWidth * 2) / laneCount;


   /**
    * Prefabs
    */

   [SerializeField] GameObject lanePrefab;
   [SerializeField] GameObject fireBallPrefab;

   /**
    * Lists
    */
   // public List<Lane> laneList = new List<Lane>();
   public List<float> laneCordXList = new List<float>();
   public List<GameObject> fireBallsList = new List<GameObject>();


   public static LaneManager instance;

   void Start()
   {
      instance = this;
      SpawnLines();
      StartCoroutine(SpawnFireBalls());
   }

   void SpawnLines()
   {
      for (int i = 0; i < laneCount; i++)
      {
         // var newLaneGameObject = Instantiate(lanePrefab);
         // var laneScript = newLaneGameObject.GetComponent<Lane>();

         // laneList.Add(laneScript);

         // newLaneGameObject.transform.position = new Vector2(MainCamera.instance.xLeftWallPosition + laneWidth / 2 + laneWidth * i, MainCamera.instance.yPosition);
         // newLaneGameObject.transform.parent = transform;

         laneCordXList.Add(MainCamera.instance.xLeftWallPosition + laneWidth / 2 + laneWidth * i);
      }
   }


   private IEnumerator SpawnFireBalls()
   {
      while (true)
      {
         Debug.Log("Fucking Spawning");
         // var newFireBall = Instantiate(fireBallPrefab);

         // Lane randomLane = laneList[Random.Range(0, laneCount)];
         // newFireBall.transform.parent = randomLane.transform;

         // -----------------------------------------
         // newFireBall.transform.localPosition = new Vector2(0, newFireBall.transform.localPosition.y);

         List<int> exIndexes = new List<int>();

         exIndexes.Add(SpawnFireBall(exIndexes));
         exIndexes.Add(SpawnFireBall(exIndexes));
         exIndexes.Add(SpawnFireBall(exIndexes));
         

         yield return new WaitForSeconds(2f);

      }
   }

   int SpawnFireBall(List<int> exIndexes)
   {
      var newFireBall = Instantiate(fireBallPrefab);
      int index;
      do
      {
         index = Random.Range(0, laneCount);
      } while (exIndexes.Contains(index));

      float randomLaneXCords = laneCordXList[index];

      var newFireBallScript = newFireBall.GetComponent<FireBall>();

      newFireBallScript.setMiddleFlyPoint(new Vector3(
         randomLaneXCords,
         MainCamera.instance.yPosition + MainCamera.instance.cameraHeight * 0.3f,
         0
      ));


      return index;
   }
}
