using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;
using System;

public class SoundFile : MonoBehaviour
{
    public Sounds sounds = new Sounds();

    public void ProblemSave()
    {
        

        // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
        string jsonData = JsonUtility.ToJson(sounds);
        // �����͸� ������ ��� ����
        string path = Path.Combine(Application.dataPath, "SoundControl.json");
        // ���� ���� �� ����
        File.WriteAllText(path, jsonData);
        Debug.Log(jsonData);
    }

    public void ProblemLoad()
    {
        // �����͸� �ҷ��� ��� ����
        string path = Path.Combine(Application.dataPath, "SoundControl.json");
        // ������ �ؽ�Ʈ�� string���� ����
        string jsonData = File.ReadAllText(path);
        // �� Json�����͸� ������ȭ�Ͽ� sounds�� �־���
        sounds = JsonUtility.FromJson<Sounds>(jsonData);
        Debug.Log(jsonData);
    }

    [ContextMenu("To Json Data")] // ������Ʈ �޴��� �Ʒ� �Լ��� ȣ���ϴ� To Json Data ��� ��ɾ ������
    void SavePlayerDataToJson()
    {
        // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
        string jsonData = JsonUtility.ToJson(sounds);
        // �����͸� ������ ��� ����
        string path = Path.Combine(Application.dataPath, "SoundControl.json");
        // ���� ���� �� ����
        File.WriteAllText(path, jsonData);

    }

}

public class Sounds
{
    public float BGM;
    public float SFX;
}
