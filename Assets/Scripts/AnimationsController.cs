using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController {

    private Animator _animator;
    private PhysicsController _physicsController;

    private int _zMovementAnimationParameter = Animator.StringToHash("ZMovement");
    private int _xMovementAnimationParameter = Animator.StringToHash("XMovement");

    private int _isGroundedAnimationParameter = Animator.StringToHash("IsGrounded");
    private int _distanceFromGroundParameter = Animator.StringToHash("DistanceFromGround");
    private int _verticalVelocityAnimationParameter = Animator.StringToHash("VerticalVelocity");

    private int _attackParameter = Animator.StringToHash("Attack");
    private int _specialAttackParameter = Animator.StringToHash("SpecialAttack");
    private int _takeDamageAnimationParameter = Animator.StringToHash("TakeDamage");
    private int _recoverParameter = Animator.StringToHash("Recover");

    private int _deathParameter = Animator.StringToHash("Die");
    private int _resetParameter = Animator.StringToHash("Reset");


    public AnimationsController(Animator animator, PhysicsController physicsController)
    {
        _animator = animator;
        _physicsController = physicsController;
    }

    public void Update()
    {
        _animator.SetFloat(_zMovementAnimationParameter, _physicsController.InputMovement.z);
        _animator.SetFloat(_xMovementAnimationParameter, _physicsController.InputMovement.x);

        _animator.SetBool(_isGroundedAnimationParameter, _physicsController.IsGrounded());
        _animator.SetFloat(_distanceFromGroundParameter, _physicsController.GetDistanceFromGround());
        _animator.SetFloat(_verticalVelocityAnimationParameter, _physicsController.Velocity.y);
    }

    public void Attack()
    {
        _animator.SetTrigger(_attackParameter);
    }

    public void SpecialAttack()
    {
        _animator.SetTrigger(_specialAttackParameter);
    }

    public void TakeDamage()
    {
        _animator.SetTrigger(_takeDamageAnimationParameter);
    }

    public void Recover()
    {
        _animator.SetTrigger(_recoverParameter);
    }

    public void Die()
    {
        _animator.SetTrigger(_deathParameter);
    }

    public void SetLayerWeight(int layerIndex, float weight)
    {
        _animator.SetLayerWeight(layerIndex, weight);
    }

    public void ResetAnimations()
    {
        _animator.SetTrigger(_recoverParameter);
        _animator.SetTrigger(_resetParameter);
        //other parameters are reset on update
    }

    public void ApplyRootMotion(bool apply)
    {
        _animator.applyRootMotion = apply;
    }
}
