using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int CountForDiamond;
    [SerializeField]
    private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, _rotateSpeed * Time.deltaTime, 0f), Space.World);
    }
}
