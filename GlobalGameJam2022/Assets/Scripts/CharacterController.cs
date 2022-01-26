using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<Character> m_Characters = new List<Character>();

    void Update()
    {
        // get all inputs for controller first
        float translation = Input.GetAxis("Horizontal");
        bool tryJump = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        // apply all inputs to both characters
        foreach (var character in m_Characters)
        {
            Debug.Log(translation);
            character.ApplyMovement(translation);
            if (tryJump)
            {
                character.TryJump();
            }
        }
    }
}
