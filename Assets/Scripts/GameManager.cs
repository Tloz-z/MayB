using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private string[] refugeesName = new string[4] { "JungSang", "Yeolna", "HwePi", "AeMae" };
    private int refugeeIndex = 0;

    public GameObject currentRefugee;
    public bool isInfo = false;                // 정보창 작동 시 특정 장치 작동 불가 용도 (true면 작동 불가)
    public bool isPassOrOut = false;           // 난민 퇴장 도중 특정 장치 작동 불가 용도 (true면 작동 불가)

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static GameManager getInstance()
    {
        return instance;
    }

    public void setRefugee()
    {
        if(currentRefugee == null)
        {
            currentRefugee = (GameObject)Instantiate(Resources.Load(refugeesName[refugeeIndex]));
            currentRefugee.transform.position = currentRefugee.GetComponent<refugee>().getOriginalPos();
            refugeeIndex++;
        }
    }

    public void setInfo()
    {
        isInfo = true;
    }

    public void resetInfo()    {
        if (isInfo)
        {
            if (currentRefugee != null)
            {
                currentRefugee.GetComponent<refugee>().sprRen.sortingLayerName = "Refugee";
            }
            GameObject info = GameObject.Find("Information");
            info.GetComponent<ScrollInfo>().ScrollUp();
        }
    }

}
