using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    // Start is called before the first frame update
    public List<Image> picList = new List<Image>();
    public float smoothing = .1f;
    public Text score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        //DontDestroyOnLoad(this);
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        picList[1].fillAmount = Mathf.Lerp(picList[1].fillAmount, picList[0].fillAmount, smoothing);
    }
    public void fillSet(int index, float fillAmount)
    {
        picList[index].fillAmount = fillAmount;
    }
    public void setText(string text)
    {
        score.text = text;
    }
}
