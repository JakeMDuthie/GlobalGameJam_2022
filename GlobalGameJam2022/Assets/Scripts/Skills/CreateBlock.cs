using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlock : ProximitySkill
{
    Transform topObject;
    public Material preSkillMaterial;
    public Material canActivateMaterial;
    public Material postSkillMaterial;
    // Start is called before the first frame update
    public override void OnStart()
    {
        world = WorldEnum.Green;
        topObject = this.transform.Find("top");
        topObject.GetComponent<BoxCollider2D>().enabled = false;
        OnCanActivateOut();
        GetComponent<Renderer>().enabled = false;
    }

    public override void OnCanActivateIn()
    {
        topObject.GetComponent<Renderer>().material = canActivateMaterial;
    }

    public override void OnCanActivateOut()
    {
        topObject.GetComponent<Renderer>().material = preSkillMaterial;
        
    }

    public override void OnPerformHability()
    {
        topObject.GetComponent<BoxCollider2D>().enabled = true;
        topObject.GetComponent<Renderer>().material = postSkillMaterial;
        GrowSeed();
    }

    public void GrowSeed()
    {
        topObject.GetComponent<Transform>().localPosition = new Vector3(
            0,
            0.427f,
            0
        );
    }
}
