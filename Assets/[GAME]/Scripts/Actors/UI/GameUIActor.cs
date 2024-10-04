using _GAME_.Scripts.Extensions;
using _GAME_.Scripts.GlobalVariables;
using _GAME_.Scripts.Managers;
using DG.Tweening;
using SoundlightInteractive.EventSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _GAME_.Scripts.Actors.UI
{
    public class GameUIActor : Actor
    {
        [Header("Components")] [SerializeField]
        private GameObject mainMenuPanel;

        [SerializeField] private GameObject endGamePanel;

        [SerializeField] private Button startGameButton;
        [SerializeField] private Button restartGameButton;
        [SerializeField] private TextMeshProUGUI tapToPlayText;
        [SerializeField] private TextMeshProUGUI tapToRestartText;
        [SerializeField] private TextMeshProUGUI gameCompleteStatusText;
        [SerializeField] private TextMeshProUGUI moneyText;

        [SerializeField] private Color gameFailedColor;
        [SerializeField] private Color gameCompletedColor;

        private Tween _bounceTween;

        private void Awake()
        {
            endGamePanel.SetActive(false);
            startGameButton.onClick.AddListener(OnClickStartGame);
            restartGameButton.onClick.AddListener(RestartGame);
            AnimateStartText(tapToPlayText.transform);
        }

        private void Start()
        {
            moneyText.text = MoneyManager.Instance.Money.ToShortString();
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnGameComplete, OnGameComplete);
                Register(CustomEvents.UpgradeMoneyText, UpgradeMoneyText);
            }

            else
            {
                Unregister(CustomEvents.OnGameComplete, OnGameComplete);
                Unregister(CustomEvents.UpgradeMoneyText, UpgradeMoneyText);
            }
        }

        private void UpgradeMoneyText(object[] arguments)
        {
            if (_bounceTween != null && _bounceTween.IsActive())
            {
                _bounceTween.Kill();
            }
            
            _bounceTween = moneyText.transform.DOScale(1.2f, 0.1f).SetLoops(2, LoopType.Yoyo).OnStepComplete(() =>
            {
                moneyText.text = MoneyManager.Instance.Money.ToShortString();
            });
        }

        private void OnGameComplete(object[] arguments)
        {
            bool status = (bool)arguments[0];
            endGamePanel.SetActive(true);

            if (status)
            {
                gameCompleteStatusText.text = "GAME COMPLETED!";
                gameCompleteStatusText.color = gameCompletedColor;
            }

            else
            {
                gameCompleteStatusText.text = "GAME FAILED!";
                gameCompleteStatusText.color = gameFailedColor;
            }

            AnimateStartText(tapToRestartText.transform);
        }

        private void OnClickStartGame()
        {
            Push(CustomEvents.OnGameStart, true);
            tapToPlayText.transform.DOKill(true);
            mainMenuPanel.SetActive(false);
        }

        private void AnimateStartText(Transform target)
        {
            target.DOScale(Vector3.one * 1.2f, .5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)
                .SetLink(target.gameObject);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }
    }
}