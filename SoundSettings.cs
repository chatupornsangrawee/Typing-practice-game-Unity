using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource audioSource; // อ็อบเจ็กต์ AudioSource ที่ต้องการควบคุมระดับเสียง
    public Scrollbar scrollbar; // อ็อบเจ็กต์ Scrollbar ที่ใช้ในการปรับระดับเสียง

    void Start()
    {
        // ตั้งค่าค่าเริ่มต้นของ scrollbar ตามระดับความดังปัจจุบันของ AudioSource
        scrollbar.value = audioSource.volume;
        // เชื่อมโยงเมธอด OnValueChanged() ของ scrollbar เข้ากับเมธอด AdjustVolume()
        scrollbar.onValueChanged.AddListener(AdjustVolume);
    }

    void AdjustVolume(float value)
    {
        // ปรับระดับเสียงของ AudioSource ตามค่าที่ถูกปรับจาก scrollbar
        audioSource.volume = value;
    }
}