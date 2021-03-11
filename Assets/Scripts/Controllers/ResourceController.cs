using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    // Start is called before the first frame update
    LevelController levelController;
    int lastLevelTimeSeconds;

    [SerializeField] int creditsPerSecond = 5;
    [SerializeField] int staringCredits = 100;

    [SerializeField] int credits = 100; //TO DO Remove serialize

    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        lastLevelTimeSeconds = 0;

        credits = staringCredits;
        levelController.UpdateCreditsText(credits);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int currTimeSeconds = Mathf.FloorToInt(levelController.GetCurrentLevelTime());
        
        if (lastLevelTimeSeconds != currTimeSeconds)
        {
            //a second elapsed
            AddCredits(creditsPerSecond);
            levelController.UpdateCreditsText(credits);

            lastLevelTimeSeconds = currTimeSeconds;
        }
    }


    public int GetCredits()
    {
        return credits;
    }

    public void AddCredits(int quantity)
    {
        credits += quantity;

        levelController.UpdateCreditsText(credits);
    }

    public void SpendCredits(int quantity)
    {
        if (credits >= quantity)
            credits -= quantity;

        levelController.UpdateCreditsText(credits);
    }

    public bool EnoughCredits(int quantity)
    {
        return credits >= quantity;
    }
}


