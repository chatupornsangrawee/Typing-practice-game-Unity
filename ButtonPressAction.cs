using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressAction : MonoBehaviour
{
    // กำหนดฟังก์ชันนี้ให้เรียกเมื่อมีการกดปุ่ม UI
    public void OnButtonPress()
    {
        // ใส่โค้ดที่ต้องการให้ทำงานเมื่อมีการกดปุ่ม UI ที่นี่
        Debug.Log("ปุ่มถูกกด!");

        // ตัวอย่างโค้ด: ทำการหยุดเกมทันทีเมื่อมีการกดปุ่ม UI
        // ควรใช้โค้ดนี้เฉพาะในการทดสอบหรือเหตุกระทบของโค้ดที่ไม่สามารถยอมรับได้
        // ในการเกมจริง ๆ ควรมีการจัดการเหตุการณ์ที่มีการกดปุ่มในวิธีที่มีความสมเหตุสมผลและไม่ทำให้ผู้เล่นสูญเสียสิทธิ์ในการเล่นเกม
        Application.Quit(); // หยุดเกม
    }
}