using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [Tooltip("Color when the flower is full")]
    public Color fullFlowerColor = new Color(1f, 0f, 0.3f);
    [Tooltip("Color when the flower is empty")]
    public Color emptyFlowerColor = new Color(0.5f, 0f, 1f);

    /// <summary>
    /// The trigger collider representing the nectar
    /// </summary>
    [HideInInspector]
    public Collider nectarCollider;

    // Solid collider representing the flower petals
    private Collider flowerCollider;

    // The flower's material
    private Material flowerMaterial;

    /// <summary>
    /// A vector pointing straight out the flower
    /// </summary>
    public Vector3 FlowerUpVector
    {
        get { return nectarCollider.transform.up; }
    }

    /// <summary>
    /// The center position of the nectar collider
    /// </summary>
    public Vector3 FlowerCenterPosition
    {
        get { return nectarCollider.transform.position };

    /// <summary>
    /// The amount of nectar remaining in the flower
    /// </summary>
    public float nectarAmount { get; private set; }

    /// <summary>
    /// Returns if flower has any nectar
    /// </summary>
    public bool HasNectar
    {
        get { return nectarAmount > 0f; }
    }

    /// <summary>
    /// Attempts to remove nectar from the flower
    /// </summary>
    /// <param name="amount">The amount of nectar to remove</param>
    /// <returns>The amount successfully removed</returns>
    public float Feed(float amount)
    {
        float nectarTaken = Mathf.Clamp(amount, 0f, nectarAmount);
        nectarAmount -= amount;

        if(nectarAmount <= 0f)
        {
            nectarAmount = 0f;

            flowerCollider.gameObject.SetActive(false);
            nectarCollider.gameObject.SetActive(false);

            flowerMaterial.SetColor("_BaseColor", emptyFlowerColor);
        }

        return nectarTaken;
    }

    public void ResetFlower()
    {
        nectarAmount = 1f;

        flowerCollider.gameObject.SetActive(true);
        nectarCollider.gameObject.SetActive(true);

        flowerMaterial.SetColor("_BaseColor", fullFlowerColor);
    }

    private void Awake()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        flowerMaterial = meshRenderer.material;

        flowerCollider = transform.Find("FlowerCollider").GetComponent<Collider>();
        nectarCollider = transform.Find("FlowerNectarCollider").GetComponent<Collider>();
    }
}
