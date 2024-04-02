using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCon : MonoBehaviour
{
    // ประกาศตัวแปรสำหรับปุ่ม 2 ปุ่ม
    public Button openButton;
    public Button closeButton;

    // ประกาศตัวแปรสำหรับเก็บวัตถุที่ต้องการควบคุม
    public GameObject targetObject;

    void Start()
    {
        // เชื่อมต่อเมท็อดปุ่มกับฟังก์ชันที่ต้องการเรียก
        openButton.onClick.AddListener(OpenObject);
        closeButton.onClick.AddListener(CloseObject);
    }

    // เมื่อกดปุ่ม "เปิดการทำงาน"
    void OpenObject()
    {
        // ตรวจสอบว่าวัตถุถูกปิดใช้งานอยู่หรือไม่
        if (!targetObject.activeSelf)
        {
            // เปิดใช้งานวัตถุ
            targetObject.SetActive(true);
        }
    }

    // เมื่อกดปุ่ม "ปิดการทำงาน"
    void CloseObject()
    {
        // ตรวจสอบว่าวัตถุถูกเปิดใช้งานอยู่หรือไม่
        if (targetObject.activeSelf)
        {
            // ปิดใช้งานวัตถุ
            targetObject.SetActive(false);
        }
    }
}