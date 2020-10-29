using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour, Eatable
{
    const float scaleMultiplayer = 15f;

    //Size is randomly generated, food is equal to size but shrinks as the apple is eaten
    //Once food reaches 0 the apple despawns
    float size;
    float food;

    void Start()
    {
        size = Random.Range(20f, 50f);
        food = size;

        float scale = food / scaleMultiplayer + 1f;
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public float GetEaten(float bite)
    {
        float biteAmount = bite * 2f * Time.deltaTime;
        food -= biteAmount;

        if(food <= 0)
        {
            biteAmount += food;
            Destroy(transform.parent.gameObject);
        }
        else
        {
            float scale = food / scaleMultiplayer + 1f;
            transform.localScale = new Vector3(scale, scale, scale);
        }

        return biteAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezePositionY;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            GetComponent<Rigidbody>().constraints -= RigidbodyConstraints.FreezePositionY;
        }
    }
}
