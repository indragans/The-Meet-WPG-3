using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    [SerializeField] GameObject objFX;

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Burn")
        {
            Destroy(gameObject);
            GameObject explosion = Instantiate(objFX, transform.position, transform.rotation);
            Destroy(explosion, 0.75f);
        }
    }
}
