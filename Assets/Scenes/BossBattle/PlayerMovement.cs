using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private void FixedUpdate() {
        if (Input.GetKey("a")) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey("d")) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }
}
