using _GAME_.Scripts.GlobalVariables;
using DG.Tweening;
using SoundlightInteractive.EventSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _GAME_.Scripts.Actors.UI
{
    public class GameUIActor : Actor
    {
        [Header("Components")] [SerializeField]
        private GameObject mainMenuPanel;

        [SerializeField] private Button startGameButton;
        [SerializeField] private TextMeshProUGUI tapToPlayText;

        private void Awake()
        {
            startGameButton.onClick.AddListener(OnClickStartGame);
            AnimateStartText();
        }

        private void OnClickStartGame()
        {
            Push(CustomEvents.OnGameStart, true);
            tapToPlayText.transform.DOKill(true);
            mainMenuPanel.SetActive(false);
        }

        private void AnimateStartText()
        {
            tapToPlayText.transform.DOScale(Vector3.one * 1.2f, .5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)
                .SetLink(tapToPlayText.gameObject);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}