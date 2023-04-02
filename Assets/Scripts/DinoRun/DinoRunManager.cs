using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoRunManager : MonoBehaviour
{
    [SerializeField] private Camera camera_;
    [SerializeField] private float speed_ = 2.0f;

    private bool playerIsAlive_ = true;

    public static DinoRunManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();   
    }

    void MoveCamera(){
        if(!playerIsAlive_) return;

        

        camera_.transform.Translate(Vector2.right * Time.deltaTime * speed_);
    }

    public bool PlayerIsAlive_ {
        get {
            return playerIsAlive_;
        }

        set {
            playerIsAlive_ = value;
        }
    }    
}
