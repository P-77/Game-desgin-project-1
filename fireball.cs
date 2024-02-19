using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private int damage = 1;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime); //move forward
    }
    //collision detection
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject); //fireball goes bye-bye
    }
}


