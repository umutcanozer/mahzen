using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BGCore
{
    public class FollowingCamera : MonoBehaviour
    {
        Vector3 _offset;
        Transform target;
        [SerializeField] GameManager manager;
        [SerializeField] float smoothTime;
        Vector3 _currentVelocity = Vector3.zero;

        private void Start()
        {
            target = manager.Prefab.transform;
            _offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            Vector3 targetPosition = target.position + _offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        }
    }
}
