using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(57, 166, 62, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    bool hasPackage;
    [SerializeField] float pickPackageTime = 0.1f;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Boom!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, pickPackageTime);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
