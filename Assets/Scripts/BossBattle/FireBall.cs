using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FireBallStatus
{
   MovingToMiddlePoint,
   MovingToEndPoint
}

public class FireBall : MonoBehaviour
{
   [SerializeField] SpriteRenderer spriteRenderer_;
   private float speed_ = 5f;
   float height;
   Vector3 middleFlyPoint;
   Vector3 directionVector;

   FireBallStatus fireBallStatus = FireBallStatus.MovingToMiddlePoint;

   // Start is called before the first frame update
   void Start()
   {
      transform.localPosition = new Vector2(
        MainCamera.instance.xPosition,
        MainCamera.instance.yPosition + MainCamera.instance.cameraHeight * 0.8f
      );

      height = spriteRenderer_.bounds.size.x;

      directionVector = (Vector3) middleFlyPoint - transform.position;
      directionVector = directionVector.normalized;

      float angle = Mathf.Atan2(directionVector.y, directionVector.x)* Mathf.Rad2Deg + 90f;
      spriteRenderer_.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
   }

   // Update is called once per frame
   void Update()
   {

      moveFireBall();

      if (transform.position.y < MainCamera.instance.yDownPosition - height / 2)
      {
         Destroy(gameObject);
      }
   }

   void moveFireBall()
   {
      transform.Translate(directionVector * Time.deltaTime * speed_);

      if (transform.position.y < middleFlyPoint.y && fireBallStatus == FireBallStatus.MovingToMiddlePoint)
      {
         transform.position = middleFlyPoint;
         spriteRenderer_.transform.eulerAngles = new Vector3(
            transform.eulerAngles.x,
            transform.eulerAngles.y,
            0.0f
         );

         directionVector = new Vector3(0,-1,0);

         fireBallStatus = FireBallStatus.MovingToEndPoint;
      }
   }

   public void setMiddleFlyPoint(Vector3 vector2)
   {
      middleFlyPoint = vector2;
   }
}
