using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Color defaultButtonColor = Color.white; // สีเริ่มต้นของปุ่ม
    public Color pressedButtonColor = Color.gray; // สีของปุ่มเมื่อถูกกด

    public AudioClip buttonPressSound; // เสียงที่จะเล่นเมื่อกดปุ่ม
    private AudioSource audioSource; // AudioSource ที่ใช้เล่นเสียง

    public Button[] keyboardButtons;

    void Start()
    {
        // สร้าง AudioSource และกำหนดให้เป็น Component ของ GameObject นี้
        audioSource = gameObject.AddComponent<AudioSource>();
        // กำหนดเสียงที่ต้องการให้เล่น
        audioSource.clip = buttonPressSound;
    }

    void Update()
    {
        foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                // เรียกเมทอดเปลี่ยนสีตัวแป้นพิมพ์บนหน้า UI
                ChangeKeyboardButtonColor(keyCode.ToString(), pressedButtonColor);
                // เล่นเสียงที่กำหนด
                audioSource.Play();
            }
            else if (Input.GetKeyUp(keyCode))
            {
                // เรียกเมทอดกลับสีตัวแป้นพิมพ์บนหน้า UI กลับมาสีเดิม
                ChangeKeyboardButtonColor(keyCode.ToString(), defaultButtonColor);
            }
        }
    }

    void ChangeKeyboardButtonColor(string buttonName, Color color)
    {
        foreach (Button button in keyboardButtons)
        {
            if (button.name == buttonName)
            {
                ColorBlock colors = button.colors;
                colors.normalColor = color;
                button.colors = colors;
                break;
            }
        }
    }
}
