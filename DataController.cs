using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataController : MonoBehaviour
{
    public Text sumText; // กล่องข้อความ UI ที่ใช้แสดงผลรวม

    void Start()
    {
        // เรียกฟังก์ชันสำหรับการบวกตัวเลขในไฟล์
        int sum = SumNumbersInFiles();

        // แสดงผลรวมในกล่องข้อความ UI
        if (sumText != null)
        {
            sumText.text = "พิมพ์ผิดทั้งหมด : " + sum.ToString();
        }
        else
        {
            Debug.LogError("Sum Text is not assigned!");
        }
    }

    int SumNumbersInFiles()
    {
        int sum = 0;

        // ชื่อไฟล์ที่ต้องการอ่านข้อมูล
        string[] fileNames = { "G1.txt", "G2.txt", "G3.txt", "G4.txt", "G5.txt" };

        foreach (string fileName in fileNames)
        {
            // หากใช้ Path.Combine(Application.dataPath, fileName) จะเข้าถึงไฟล์ในโฟลเดอร์ "Assets"
            string filePath = Path.Combine(Application.dataPath, fileName);

            if (File.Exists(filePath))
            {
                // อ่านข้อมูลจากไฟล์
                string fileContent = File.ReadAllText(filePath);

                // แยกตัวเลขออกมาและบวกกัน
                string[] numbers = fileContent.Split('\n'); // แบ่งข้อมูลตามบรรทัด
                foreach (string numStr in numbers)
                {
                    int number;
                    if (int.TryParse(numStr, out number))
                    {
                        sum += number;
                    }
                }
            }
            else
            {
                Debug.LogError("File not found: " + fileName);
            }
        }

        return sum;
    }
}