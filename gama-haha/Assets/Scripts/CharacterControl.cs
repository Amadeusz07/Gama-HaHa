using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private const string AI_PLAYER_TAG = "AIPlayer";
    private const string PLAYER_TAG = "Player";

    public float run = 0f;
    public bool blast = false;
    public bool punch = false;
    public bool jump = false;
    public bool crouch = false;
    public bool getDamage = false;
    public bool guard = false;
    public bool charge = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == PLAYER_TAG)
        {
            if (Input.GetKey(KeyCode.D))
            {
                run = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                run = -1;
            }
            run = Input.GetAxis("Horizontal");
            blast = Input.GetKeyDown(KeyCode.E);
            punch = Input.GetKeyDown(KeyCode.Q);
            jump = Input.GetButtonDown("Jump");
            crouch = Input.GetKey(KeyCode.S);
            guard = Input.GetKey(KeyCode.G);
            charge = Input.GetKey(KeyCode.R);
        }
        else if (gameObject.tag == AI_PLAYER_TAG)
        {
            
        }
    }

}
