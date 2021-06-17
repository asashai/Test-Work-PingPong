using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public SpriteRenderer ball;

    public Text textCurrentValue;
    public Text textBestValue;

    public Button buttonMenu;
    public GameObject panelMenu;
    public Dropdown dropdownBallColor;

    public static int hitsCurrent;
    public static int hitsBest;

    private void OnEnable()
    {
        dropdownBallColor.onValueChanged.AddListener(SetNewColor);
        Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonMenu.onClick.AddListener(() =>
        {
            panelMenu.SetActive(!panelMenu.activeSelf);
        });
    }

    // Update is called once per frame
    void Update()
    {
        textCurrentValue.text = hitsCurrent.ToString();
        textBestValue.text = hitsBest.ToString();

        //is pause ?
        Time.timeScale = panelMenu.activeSelf ? 0 : 1;
    }

    void Load()
    {
        if (PlayerPrefs.HasKey("BestHits"))
        {
            hitsBest = PlayerPrefs.GetInt("BestHits");

            //set dropdown
            dropdownBallColor.value = PlayerPrefs.GetInt("BallColor");
        }
    }

    void Save()
    {
        PlayerPrefs.SetInt("BestHits", hitsBest);
        PlayerPrefs.SetInt("BallColor", dropdownBallColor.value);
    }

    private void SetNewColor(int id)
    {
        switch (id)
        {
            case 0:
                ball.color = Color.white;
                break;
            case 1:
                ball.color = Color.red;
                break;
            case 2:
                ball.color = Color.green;
                break;
            case 3:
                ball.color = Color.blue;
                break;
        }
    }

    private void OnApplicationPause(bool pause)
    {
        Save();
    }
}
