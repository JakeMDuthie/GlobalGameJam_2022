using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public WorldEnum world;

    void Start()
    {

        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        var character = other.gameObject.GetComponent<Character>();
        if (character)
        {
            if (character.world == this.world)
            {
                samePick(character);
            }
        }
    }


    void samePick(Character character)
    {
        character.getCollectable();
        Destroy(this.gameObject);
    }
}
