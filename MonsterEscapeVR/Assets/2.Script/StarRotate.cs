using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotate : MonoBehaviour
{
        public GameObject Planet;       //�����༺ (�伺)
        public float speed;             //ȸ�� �ӵ�

        private void Update()
        {
            OrbitAround();
        }

        void OrbitAround()
        {
            transform.RotateAround(Planet.transform.position, Vector3.down, speed * Time.deltaTime);
        }
        // RotateAround(Vector3 point, Vector3 axis, float angle)
    
}
