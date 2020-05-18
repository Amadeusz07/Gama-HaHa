using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    private const string AIPlayerTag = "AIPlayer";

    void Start()
    {
        var aiPlayer = GameObject.FindGameObjectWithTag(AIPlayerTag);
        aiPlayer.GetComponent<Movement>().enabled = false;
    }
}
