using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class GalleryLoader : MonoBehaviour
{
    public string baseURL = "http://data.ikppbb.com/test-task-unity-data/pics/";
    public int imageCount = 66;

    void Start()
    {
        // ������� ��� �������� Image ������ Canvas
        Image[] images = GetComponentsInChildren<Image>();

        for (int i = 0; i < images.Length; i++)
        {
            // ��������� ���� � �����������
            string imageURL = baseURL + (i + 1) + ".jpg";

            // ��������� � ����������� �����������
            StartCoroutine(LoadImage(images[i], imageURL));
        }
    }

    IEnumerator LoadImage(Image image, string url)
    {
        // ������� UnityWebRequest ��� �������� �����������
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            // ��������� ������� ������ ��� ��������
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("������ �������� �����������: " + www.error);
                yield break;
            }

            // �������� ����������� �����������
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

            // ����������� ����������� ����������� �������� Image
            image.sprite = sprite;
        }
    }
}