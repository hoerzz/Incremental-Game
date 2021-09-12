using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 

public class AchievementController : MonoBehaviour

{

    // Instance ini mirip seperti pada GameManager, fungsinya adalah membuat sistem singleton

    // untuk memudahkan pemanggilan script yang bersifat manager dari script lain

    private static AchievementController _instance = null;

    public static AchievementController Instance

    {

        get

        {

            if (_instance == null)

            {

                _instance = FindObjectOfType<AchievementController> ();

            }

 

            return _instance;

        }

    }

 

    [SerializeField] private Transform _popUpTransform;

    [SerializeField] private Text _popUpText;

    [SerializeField] private float _popUpShowDuration = 3f;

    [SerializeField] private List<AchievementData> _achievementList;

    public GameObject kucingGarong,kucingSeleb,kucingSultan;

    private float _popUpShowDurationCounter;

 

    private void Update ()

    {

        if (_popUpShowDurationCounter > 0)

        {

            // Kurangi durasi ketika pop up durasi lebih dari 0

            _popUpShowDurationCounter -= Time.unscaledDeltaTime;

            // Lerp adalah fungsi linear interpolation, digunakan untuk mengubah value secara perlahan

            _popUpTransform.localScale = Vector3.LerpUnclamped (_popUpTransform.localScale, Vector3.one, 0.5f);

        }

        else

        {

            _popUpTransform.localScale = Vector2.LerpUnclamped (_popUpTransform.localScale, Vector3.right, 0.5f);

        }

    }

 

    public void UnlockAchievement (AchievementType type, string value)

    {

        // Mencari data achievement

        AchievementData achievement = _achievementList.Find (a => a.Value == value);

        if (achievement != null && !achievement.IsUnlocked)

        {
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

            achievement.IsUnlocked = true;

            ShowAchivementPopUp (achievement);

        }

    }

 

    private void ShowAchivementPopUp (AchievementData achievement)

    {

        _popUpText.text = achievement.Title;

        _popUpShowDurationCounter = _popUpShowDuration;

        _popUpTransform.localScale = Vector2.right;

    }

}

 

// System.Serializable digunakan agar object dari script bisa di-serialize

// dan bisa di-inputkan dari Inspector, jika tidak terdapat ini, maka variable tidak akan muncul di inspector

[System.Serializable]

public class AchievementData

{

    public string Title;

    public AchievementType Type;

    public string Value;

    public bool IsUnlocked;

}

 

public enum AchievementType

{

    KucingGarong,
    Kucingseleb,
    kucingSultan

}