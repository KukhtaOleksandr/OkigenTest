using System.Threading.Tasks;
using Basket;
using DG.Tweening;
using StateMachine.Base;
using UnityEngine;

namespace Human.StateMachine
{
    public class DefeatState : IState
    {
        private const string Defeat = "Defeat";
        private const float Duration = 0.3f;
        private const float FloorPosition = -0.6f;
        private Transform _human;
        private BasketContainer _basket;
        private Animator _animator;
        public DefeatState(BasketContainer basket, Transform human, Animator animator)
        {
            _basket = basket;
            _human = human;
            _animator = animator;
        }

        public async void Enter()
        {
            await DoDefeatAnimation();
        }

        private async Task DoDefeatAnimation()
        {
            _animator.SetTrigger(Defeat);
            await WaitForBasketFall();
            _basket.transform.parent = null;
            _basket.transform.DOMove(new Vector3(-0.534f, FloorPosition, _basket.transform.position.z), Duration);
            await WaitForDefeat();
            _human.DORotate(new Vector3(_human.rotation.x, 180, _human.rotation.z), 1);
        }

        private async Task WaitForDefeat()
        {
            await Task.Delay(1100);
        }

        private async Task WaitForBasketFall()
        {
            await Task.Delay(260);
        }

        public void Exit()
        {

        }
    }
}