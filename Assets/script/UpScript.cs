using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpScript : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
