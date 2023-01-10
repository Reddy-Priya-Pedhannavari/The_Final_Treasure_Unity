//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class parallex : MonoBehaviour
//{
//    private Transform cameraTransform;
//    private Vector3 lastcameraPos;
//    private void Start()
//    {
//        cameraTransform = Camera.main.transform;
//        lastcameraPos = cameraTransform.position;
//    }

//    private void LateUpdate()
//    {
//        float speed = .5f;
//        Vector3 deltaPos = cameraTransform.position - lastcameraPos;
//        transform.position += deltaPos*speed;
//        lastcameraPos = cameraTransform.position;
//    }
//}
