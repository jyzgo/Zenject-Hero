﻿using UnityEngine;

namespace Code
{
    public class PlayerModel
    {
        public readonly Rigidbody2D _rigidBody;
        private readonly SpriteRenderer _spriteRenderer;
        public readonly Animator Animator;

        public PlayerModel(
            Rigidbody2D rigidbody2D,
            SpriteRenderer spriteRenderer,
            Animator animator)
        {
            _rigidBody = rigidbody2D;
            _spriteRenderer = spriteRenderer;
            Animator = animator;
        }

        public bool IsSpawning { get; set; }
        public bool HasMoved { get; set; }
        public bool IsGrounded { get; set; }
        public bool IsDead { get; set; }

        public void Spawn()
        {
            _rigidBody.bodyType = RigidbodyType2D.Static;
            IsSpawning = true;
            Animator.SetBool("IsSpawning", true);
        }
        
        public Vector2 Position
        {
            get { return _rigidBody.position; }
            set { _rigidBody.position = value; }
        }
        
        public void AddForce(Vector2 force)
        {
            _rigidBody.AddForce(force);
        }
        
        public bool IsFacingLeft { get; private set; }
        public void FaceLeft(bool isPlayerMovingToTheLeft)
        {
            _spriteRenderer.flipX = isPlayerMovingToTheLeft;
            IsFacingLeft = isPlayerMovingToTheLeft;
        }
    }
}