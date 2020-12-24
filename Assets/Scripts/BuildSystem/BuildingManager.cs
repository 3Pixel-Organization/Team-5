// building script
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Transform building;
    [SerializeField] private float resource1, resource2, resource3;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //! Check if player has enough resources to build
            if (resource1 >= 10 && resource2 >= 10 && resource3 >= 10)
            {
                Build();
                resource1 -= 10;
                resource2 -= 10;
                resource3 -= 10;
            }
            else
            {
                Debug.Log("Out of resources");
            }
        }
    }

    //! build function
    private void Build()
    {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        Instantiate(building, mouseWorldPosition, Quaternion.identity);
    }

    //!-----------------------------------------------------------------------
    //! get mouse world position
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    //! get mouse world position
    //!-----------------------------------------------------------------------
}