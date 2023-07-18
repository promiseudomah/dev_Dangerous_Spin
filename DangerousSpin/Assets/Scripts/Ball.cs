using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("NormalBlock")){

            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
        }

        else if(other.collider.CompareTag("SpecialBlock")){

            Debug.Log("Nice!!! ");
            GameManager.Instance.AddScore();
        }

    }
}
