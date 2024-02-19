using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
public class PlayerCharacter : MonoBehaviour
{
    private int health;
    void Start()
    {
        health = 5;
    }
    public void Hurt(int damage)
    {
        health -= damage;
        //this syntax is called string interpolation:
        //the variable can be written in curly braces
        //inline inside a string literal with a $ in front
        Debug.Log($"Health: {health}");
    }
}

