using System.Threading.Tasks;
using Basket;
using DG.Tweening;
using StateMachine.Base;
using UnityEngine;

namespace Human.StateMachine
{
    public class DanceState : IState
    {
        private const string Dance = "Dance";
        private const float Duration = 0.3f;
        private const float FloorPosition = -0.6f;
        private Transform _human;
        private BasketContainer _basket;
        private Animator _animator;
        public DanceState(BasketContainer basket, Transform human, Animator animator)
        {
            _basket = basket;
            _human = human;
            _animator = animator;
        }

        public async void Enter()
        {
            await DoDanceAnimation();
        }

        private async Task DoDanceAnimation()
        {
            _animator.SetTrigger(Dance);
            await WaitForBasketFall();

            _basket.transform.parent = null;
            _basket.transform.DOMove(new Vector3(-0.534f, FloorPosition, _basket.transform.position.z), Duration);
            
            await WaitForDance();
            _human.DORotate(new Vector3(_human.rotation.x, 180, _human.rotation.z), 1);
        }

        private async Task WaitForDance()
        {
            await Task.Delay(700);
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