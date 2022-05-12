using System;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public GameObject Cube;
    public GameObject DestroyedCubes;
    public Rigidbody InnerLeftCube;
    public Rigidbody InnerRightCube;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(GameManager.Instance.Settings.KnifeTag))
            DestroyObject();
    }

    void DestroyObject()
    {
        Cube.SetActive(false);
        DestroyedCubes.SetActive(true);
        InnerLeftCube.AddForce(new Vector3(0,0,2));
        InnerRightCube.AddForce(new Vector3(0,0,-2));
    }
}
