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
        // Находим все элементы Image внутри Canvas
        Image[] images = GetComponentsInChildren<Image>();

        for (int i = 0; i < images.Length; i++)
        {
            // Формируем путь к изображению
            string imageURL = baseURL + (i + 1) + ".jpg";

            // Загружаем и присваиваем изображение
            StartCoroutine(LoadImage(images[i], imageURL));
        }
    }

    IEnumerator LoadImage(Image image, string url)
    {
        // Создаем UnityWebRequest для загрузки изображения
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            yield return www.SendWebRequest();

            // Проверяем наличие ошибок при загрузке
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Ошибка загрузки изображения: " + www.error);
                yield break;
            }

            // Получаем загруженное изображение
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

            // Присваиваем загруженное изображение элементу Image
            image.sprite = sprite;
        }
    }
}