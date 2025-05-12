using TMPro;
using UnityEngine;

namespace TZ_StemBAI.UI
{
    public class PanelMenuController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textResult;

        public void ResultGame(bool result)
        {
            _textResult.text = result ? "Вы победили" : "Вы проиграли";
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }
    }
}