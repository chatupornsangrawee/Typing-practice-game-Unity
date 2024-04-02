using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad; // กำหนดชื่อฉากที่คุณต้องการโหลด

    private void Start()
    {
        // ค้นหาปุ่ม UI ในวัตถุปุ่ม
        Button button = gameObject.GetComponent<Button>();

        // เมื่อคลิกปุ่ม UI
        button.onClick.AddListener(LoadSceneOnClick);
    }

    private void LoadSceneOnClick()
    {
        // โหลดฉากเมื่อคลิกปุ่ม UI
        SceneManager.LoadScene(sceneToLoad);
    }
}
