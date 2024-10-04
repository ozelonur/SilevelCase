using _GAME_.Scripts.Interfaces;
using _GAME_.Scripts.Managers;
using _GAME_.Scripts.ScriptableObjects;
using DG.Tweening;
using SoundlightInteractive.EventSystem;
using UnityEngine;

namespace _GAME_.Scripts.Actors.Collectable
{
    public class CollectableActor : Actor, ICollectable
    {
        [field: SerializeField] public CollectableScriptableObject collectableData { get; set; }

        private void Awake()
        {
            AnimateCollectable();
        }

        public void Collect(params object[] arguments)
        {
            transform.GetChild(0).DOScale(Vector3.zero, .1f).SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    MoneyManager.Instance.Money += collectableData.data.worth;
                })
                .SetLink(gameObject);
        }

        public override void ResetActor()
        {
        }

        public override void InitializeActor()
        {
        }

        private void AnimateCollectable()
        {
            transform.DOLocalRotate(Vector3.up * 360, 1f, RotateMode.LocalAxisAdd)
                .SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental)
                .SetLink(gameObject);
        }

    }
}