using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private bool DetectedEnenmy;
    public float GaurdSight;
    public LayerMask Enemy;
    public Transform Origin;
    public Vector3 Direction;
    private GameObject Gaurd;
    public GameObject Gaurd1;

    void Update()
    {
        Detector();
    }

    public void Detector()
    {
        DetectedEnenmy = Physics2D.Raycast(Origin.position, Direction, GaurdSight, Enemy);
        if (DetectedEnenmy)
        {
            Instantiate(Gaurd1, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }

    }

}
