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
    private LevelController levelController;

    // Start is called before the first frame update
    private void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        levelController = FindObjectOfType<LevelController>();
    }

    public void OnMouseDown()
    {
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("mouse down: " + worldPos);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("mouse click: " + worldPos);
        }

    }

}
