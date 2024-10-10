using App;
using TMPro;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TimerView : MonoBehaviour
    {
        private TextMeshProUGUI textMP;

        private void Awake() => textMP = GetComponent<TextMeshProUGUI>();

        public void UpdateTimerText(string text) => textMP.text = text;

        private void OnEnable() => TimerController.OnTimerUpdated += UpdateTimerText;

        private void OnDisable() => TimerController.OnTimerUpdated -= UpdateTimerText;
    }
}