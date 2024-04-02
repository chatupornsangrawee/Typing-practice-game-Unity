using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
public class TextColorChanger : MonoBehaviour
{
    public Text[] textboxes;
    public string[] targetWords = { "HOME", "CAR", "TREE", "APPLE", "BEACH", "PIZZA", "MOON", "FLOWER" };
    public Text uiTextComponent;
    public Text bloodTextComponent;
    private int currentWordIndex = 0;
    private int currentLetterIndex = 0;
    private float startTime;
    private int totalTypedWords;
    private float totalElapsedTime;
    private int blood = 100;
    public string nextSceneName = "......";
    public AudioSource collisionSound;

    public int NumberOfTypos = 0; // ตัวแปรนับจำนวนข้อผิดพลาด
    public string fileName = "NumberOfTypos.txt"; // ตัวแปรเก็บชื่อไฟล์ที่จะเขียน
    private string filePath; // เก็บที่อยู่ของไฟล์


    void Start()
    {
        SetTextForWord();
        startTime = Time.time;
        UpdateBloodText();
        filePath = Application.dataPath + "/" + fileName;

    }

    void SetTextForWord()
    {
        string currentWord = targetWords[currentWordIndex];
        for (int i = 0; i < textboxes.Length; i++)
        {
            if (i < currentWord.Length)
            {
                textboxes[i].text = currentWord[i].ToString();
            }
            else
            {
                textboxes[i].text = "";
            }
            textboxes[i].color = Color.white;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)) // เพิ่มเงื่อนไขไม่ให้นับเมาส์ด้วย
        {
            if (currentLetterIndex < targetWords[currentWordIndex].Length)
            {
                if (Input.inputString.ToLower() == targetWords[currentWordIndex][currentLetterIndex].ToString().ToLower())
                {
                    textboxes[currentLetterIndex].color = Color.green;
                    currentLetterIndex++;

                    if (currentLetterIndex == targetWords[currentWordIndex].Length)
                    {
                        blood += 5; // เพิ่มเลือดเมื่อพิมพ์ถูกทั้งคำ
                        UpdateBloodText();
                    }
                }
                else
                {
                    textboxes[currentLetterIndex].color = Color.red;
                    blood -= 10;
                    UpdateBloodText();
                    NumberOfTypos++;
                }

                if (currentLetterIndex >= targetWords[currentWordIndex].Length)
                {
                    Debug.Log("You typed the word correctly!");
                    totalTypedWords++;
                    currentWordIndex++;
                    currentLetterIndex = 0;

                    if (currentWordIndex < targetWords.Length)
                    {
                        DestroyNextObjectWithTag("MS");
                        Invoke("SetTextForWord", 0.2f);
                    }
                    else
                    {
                        WriteToFile(filePath, NumberOfTypos.ToString());
                        Debug.Log("You completed all words!");
                        UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName); // โหลดฉากตามชื่อฉากที่กำหนด

                    }
                }
            }
        }

        if (totalTypedWords > 0)
        {
            totalElapsedTime = Time.time - startTime;
            float wpm = (totalTypedWords / totalElapsedTime) * 60f;
            uiTextComponent.text = "WPM : " + wpm.ToString("F2");
        }
    }

    void UpdateBloodText()
    {
        blood = Mathf.Clamp(blood, 0, 100);
        bloodTextComponent.text = "" + blood.ToString();
        if (blood <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GAMEOVER");
        }
    }

    void DestroyNextObjectWithTag(string tag)
    {
        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        if (obj != null)
        {
            Destroy(obj);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("MS"))
        {
                    Debug.Log("Collision with obstacle detected!");
                    collisionSound.Play();
                    blood -= 5;
                    UpdateBloodText();                    
        }
    }
     void WriteToFile(string filePath, string content)
    {
        // สร้าง StreamWriter เพื่อเขียนข้อมูลลงในไฟล์
        StreamWriter writer = new StreamWriter(filePath);

        // เขียนข้อมูลลงในไฟล์
        writer.WriteLine(content);

        // ปิด StreamWriter เพื่อบันทึกข้อมูลลงในไฟล์
        writer.Close();
    }

} 