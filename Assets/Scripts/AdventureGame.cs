using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] State gameOverState;
    
    int statesEncountered;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        statesEncountered = 0;
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    void ManageState()
    {
        if (statesEncountered >= 5)
        {
            state = gameOverState;
            textComponent.text = state.GetStateStory();
            statesEncountered = -1;
        } 
        else
        {
            var nextStates = state.GetNextStates();
            for (int i = 0; i < nextStates.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    state = nextStates[i];
                    statesEncountered++;
                }
            }
            textComponent.text = state.GetStateStory();
        }
    }
}
