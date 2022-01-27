using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public List<Character> m_Characters = new List<Character>();

    private void Start()
    {
        m_Characters = new List<Character>(GameObject.FindObjectsOfType<Character>());
    }

    void Update()
    {
        // get all inputs for controller first
        float translation = Input.GetAxis("Horizontal");
        bool tryJump = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        // apply all inputs to both characters
        bool warpable = true;
        foreach (var character in m_Characters)
        {
            character.ApplyMovement(translation);
            if (tryJump)
            {
                character.TryJump();
            }

            if (!character.Warpable)
            {
                warpable = false;
            }
        }

        if (warpable && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)))
        {
            Debug.Log("WARPABLE!");
            SwapCharacters();
        }
    }

    private void SwapCharacters()
    {
        if (m_Characters == null || m_Characters.Count < 2)
        {
            // something has gone wrong
            Debug.LogWarning("Trying to swap 0 or 1 wolves");
            return;
        }

        var temp = m_Characters[0].transform.position;

        m_Characters[0].transform.position = m_Characters[1].transform.position;
        m_Characters[1].transform.position = temp;
    }

    public int GetCharacterScore(WorldEnum type)
    {
        foreach (var character in m_Characters)
        {
            if (type == character.world)
            {
                return character.collectables;
            }
        }
        
        return -1;
    }
}
