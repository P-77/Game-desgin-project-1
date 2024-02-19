using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false); //I have died
        }
        StartCoroutine(Die());
        
    }
    private IEnumerator Die()
    {
        //topple over
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        //die
        Destroy(this.gameObject);
    }
}
