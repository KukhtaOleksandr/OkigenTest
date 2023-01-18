using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;
namespace Animations.Human
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private TwoBoneIKConstraint _constraint;
        [SerializeField] private Animator _animator;
        [SerializeField] private RigBuilder _rigBuilder;
        public async void GrabProduct(Transform target)
        {
            _constraint.data.target = target;
            _rigBuilder.Build();
            _animator.SetTrigger("GrabProduct");
        }
    }
}