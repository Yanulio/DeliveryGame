using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] private Color32 hasPackageColor = new Color32(193, 15, 219, 255);
    [SerializeField] private Color32 normalColor = new Color32(15, 219, 219, 255);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package has been picked up");
            hasPackage = true;
            Destroy(col.gameObject);
            spriteRenderer.color = hasPackageColor;
        }
        if (col.tag == "Person" && !hasPackage)
        {
            Debug.Log("You don't have a package to deliver yet!");
        }
        if (col.tag == "Person" && hasPackage)
        {
            Debug.Log("Package has been delivered to a customer");
            hasPackage = false;
            spriteRenderer.color = normalColor;
        }
    }
}
