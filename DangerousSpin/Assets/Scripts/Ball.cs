using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject PlayerDeath;
    [SerializeField] GameObject SpecialBlockSpash;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("NormalBlock")){

            
            GameObject splash = Instantiate(PlayerDeath, transform.position, Quaternion.identity);
            gameObject.SetActive(false);

            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
        }

        else if(other.collider.CompareTag("SpecialBlock")){

            GameObject splash = Instantiate(SpecialBlockSpash, other.transform.position, Quaternion.identity);
            other.gameObject.SetActive(false);

            Debug.Log("Nice!!! ");
            GameManager.Instance.AddScore();
        }

    }
}
