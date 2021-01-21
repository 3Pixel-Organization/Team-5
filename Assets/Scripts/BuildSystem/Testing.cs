using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private int value;

    private void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20, 0));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition), 10);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }
}