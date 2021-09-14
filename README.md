Saya Menambahkan OnPointerUp pada [TapArea.cs](https://github.com/hoerzz/Incremental-Game/blob/main/Assets/Scripts/TapArea.cs) untuk menggunakan gambar kedua ketika mouse delepas dan akan mengembalikan ke gambar semula
```c#
public class TapArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject clickUp, clickDown;

    public void OnPointerDown (PointerEventData eventData)
    {
        GameManager.Instance.CollectByTap (eventData.position, transform);
        clickUp.SetActive(true);
        clickDown.SetActive(false);
    }
    public void OnPointerUp (PointerEventData eventData)
    {
        clickUp.SetActive(false);
        clickDown.SetActive(true);
    }
}
```
dan saya menambahkan Switch pada [AchievementController.cs](https://github.com/hoerzz/Incremental-Game/blob/main/Assets/Scripts/TapArea.cs) dan mengubah AchievementType untuk menambahkan reward  topi kepada player dan setiap Achievement kebuka akan mengubah warna topi
```c#
switch (achievement.Type)
            {
                case AchievementType.KucingGarong:
                    kucingGarong.SetActive(true);
                    kucingSeleb.SetActive(false);
                    kucingSultan.SetActive(false);
                    Debug.Log("Kucing Garong");
                    break;
                case AchievementType.Kucingseleb:
                    kucingGarong.SetActive(false);
                    kucingSeleb.SetActive(true);
                    kucingSultan.SetActive(false);
                    Debug.Log("Kucing Seleb");
                    break;
                case AchievementType.kucingSultan:
                    kucingGarong.SetActive(false);
                    kucingSeleb.SetActive(false);
                    kucingSultan.SetActive(true);
                    Debug.Log("Kucing Sultan");
                    break;
            } 
  ```
