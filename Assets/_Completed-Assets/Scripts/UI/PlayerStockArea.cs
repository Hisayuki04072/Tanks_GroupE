using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStockArea : MonoBehaviour
{
    [SerializeField] private Image[] shell1s;       //�C�e�̃X�g�b�N��
    [SerializeField] private Image[] shell10s;
    public void UpdatePlayerStockArea(int stockCount) //HudManager.cs�Ŏg�p,�e�̕\����\��
    {
        for (int i = 0; i < shell1s.Length; i++)
        {
            if ((i < stockCount%10))
            {
                shell1s[i].gameObject.SetActive(true);
            }
            else
            {
                shell1s[i].gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < shell10s.Length; i++)
        {
            if ((i + 1) * 10 <= stockCount)
            {
                shell10s[i].gameObject.SetActive(true);
            }
            else
            {
                shell10s[i].gameObject.SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
