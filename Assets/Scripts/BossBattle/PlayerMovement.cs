using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] SpriteRenderer spriteRenderer_;
   [SerializeField] private GameObject spearPrefab_;
   [SerializeField] private float speed_ = 10f;
   int positionInd = 2;


   float height;
   float lastChange;
   float lastShoot;



   private void Start()
   {
      height = spriteRenderer_.bounds.size.y;
      lastChange = Time.time;

      lastShoot = Time.time;
   }


   private void Update()
   {
      Movement();
      CheckShooting();
   }

   private void Movement(){
      if (Time.time - lastChange < 0.1f) return;

      lastChange = Time.time;

      if (Input.GetKey("a"))
      {
         // transform.Translate(Vector3.left * Time.deltaTime * speed);

         positionInd = Mathf.Clamp(positionInd - 1, 0, LaneManager.instance.laneCount - 1);
         transform.position = new Vector3(
            LaneManager.instance.laneCordXList[positionInd],
            transform.position.y,
            transform.position.z
         );
      }
      if (Input.GetKey("d"))
      {
         // transform.Translate(Vector3.right * Time.deltaTime * speed);

         positionInd = Mathf.Clamp(positionInd + 1, 0, LaneManager.instance.laneCount - 1);
         transform.position = new Vector3(
            LaneManager.instance.laneCordXList[positionInd],
            transform.position.y,
            transform.position.z
         );
      }
   }

   private void CheckShooting(){
      if(!Input.GetKey("space") || Time.time - lastShoot < 0.3f) return;

      lastShoot = Time.time;
      var spear = Instantiate(spearPrefab_);

      spear.transform.position = new Vector2(transform.position.x, transform.position.y + height/2);
   }

   private void OnTriggerEnter2D(Collider2D other) 
   {
      if (other.transform.CompareTag("Fireball"))
      {
         // Destroy(gameObject);
      }
   }
}
