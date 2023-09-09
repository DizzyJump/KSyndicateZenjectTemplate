using System;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Vector3 rotationAxis;
        [SerializeField] private float rotationSpeed;

        private void Update() => 
            transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}