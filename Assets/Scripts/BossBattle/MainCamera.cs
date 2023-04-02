using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
   public float cameraHeight; // half of real height
   public float aspectRatio;
   public float cameraWidth; // half of real width

   public float xPosition;
   public float yPosition;

   public float xLeftWallPosition;
   public float yUpPosition;
   public float yDownPosition;

   public static MainCamera instance;

   // Start is called before the first frame update
   void Awake()
   {
      cameraHeight = Camera.main.orthographicSize;
      aspectRatio = Screen.width / (float)Screen.height;
      cameraWidth = cameraHeight * aspectRatio;

      xPosition = Camera.main.transform.position.x;
      yPosition = Camera.main.transform.position.y;

      xLeftWallPosition = xPosition - cameraWidth;

      yUpPosition = yPosition + cameraHeight;
      yDownPosition = yPosition - cameraHeight;

      instance = this;
   }

   private void Update()
   {
      xPosition = Camera.main.transform.position.x;
      yPosition = Camera.main.transform.position.y;
   }
}