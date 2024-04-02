using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f; // ความเร็วของการเคลื่อนที่
    private GameObject targetObject; // เก็บตำแหน่งของวัตถุที่เป็นเป้าหมาย

    void Start()
    {
        // ค้นหาวัตถุที่มี TAG ชื่อ "BOX" และเก็บไว้ในตัวแปร targetObject
        targetObject = GameObject.FindWithTag("BOX");
    }

    void Update()
    {
        if (targetObject != null)
        {
            // ดึงตำแหน่งปัจจุบันของวัตถุ
            Vector3 currentPosition = transform.position;

            // คำนวณเส้นทางที่จะเคลื่อนที่ไปหาวัตถุ
            Vector3 direction = targetObject.transform.position - currentPosition;
            direction.y = 0; // ไม่สนใจการเคลื่อนที่ขึ้น-ลงในแนวแกน Y

            // หาความยาวของเส้นทาง
            float distanceToTarget = direction.magnitude;

            // ตรวจสอบว่าเราอยู่ใกล้วัตถุเป้าหมายหรือไม่
            if (distanceToTarget > 0.1f)
            {
                // คำนวณแรงเร่งเพื่อเคลื่อนที่ไปหาวัตถุ
                Vector3 moveDirection = direction.normalized * speed * Time.deltaTime;

                // หาตำแหน่งใหม่ของวัตถุ
                Vector3 newPosition = currentPosition + moveDirection;

                // กำหนดตำแหน่งใหม่ให้กับวัตถุ
                transform.position = newPosition;
            }
        }
    }
}