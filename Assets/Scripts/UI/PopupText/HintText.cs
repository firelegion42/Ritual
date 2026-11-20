using TMPro;
using UnityEngine;

public class HintText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hintText;

   public void ShowText()
    {
        _hintText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        _hintText.gameObject.SetActive(false);
    }
}
