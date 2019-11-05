using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopupCard : Popup
{
    [SerializeField] GameObject m_cardPrefab;
    [SerializeField] RectTransform m_gotCardsButton;
    [SerializeField] Image m_newCardImage;
    [SerializeField] Text m_newCardText;

    public void ShowCard(int index)
    {
        switch(index)
        {
            case 1:
            m_cardPrefab.SetActive(true);
            m_newCardImage.color = new Color(255f, 216f, 0f, 255f);
            m_newCardText.text = "상급카드";
            StartCoroutine(HideCard());
                break;
            case 2:
            m_cardPrefab.SetActive(true);
            m_newCardImage.color = new Color(164f, 163f, 157f, 255f);
            m_newCardText.text = "중급카드";
            StartCoroutine(HideCard());
                break;
            case 3:
            default:
            m_cardPrefab.SetActive(true);
            m_newCardImage.color = new Color(224f, 86f, 0f, 255f);
            m_newCardText.text = "하급카드";
            StartCoroutine(HideCard());
                break;
            
        }
    }

    private IEnumerator HideCard()
    {
        // do {
        //     // m_newCardImage.transform.position = Vector3.Lerp();
        //     yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        // } while( m_gotCardsButton.position <= m_newCardImage.transform.position);
yield return new WaitForSeconds(1f);
        m_cardPrefab.SetActive(false);
    }

    public void XButton()
    {
        Destroy(this?.gameObject);
    }
}
