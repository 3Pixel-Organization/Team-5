using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] public bool mouseControlActive = true;
    [SerializeField] public bool touchControlActive = false;

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;
    private SceneController sceneController;

    // Start is called before the first frame update
    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();        
    }

    void Update()
    {
       
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            if (!touchControlActive)
                return;

            Touch touch = Input.GetTouch(0);
            //Debug.Log("Touch processing");

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Ended:

                    startPos = touch.position;
                    directionChosen = false;
                    Vector2 worldPos = Camera.main.ScreenToWorldPoint(touch.position);

                    /*
                    Collider2D coll = defenderSpawner.GetComponent<Collider2D>();
                    //TODO BUG on ensuring position is already occupied
                    if (coll.bounds.Contains(worldPos))
                    {
                        Debug.Log("Adding from touch drag (input controller)");
                        defenderSpawner.AttemptSpawnDefender(Utils.WorldToSnapGrid(touch.position.x, touch.position.y));
                    }
                    */

                    break;
            }
        }

    }

}
