using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;

namespace HenryMod.Modules.SurvivorComponents
{
    public class RocketJumpComponent : MonoBehaviour
    {
        public bool isRocketJumping = false;
        public CharacterMotor characterMotor;

        private void Awake()
        {
            characterMotor.onHitGround += characterMotor_onHitGround;
        }

        private void characterMotor_onHitGround(ref CharacterMotor.HitGroundInfo hitGroundInfo)
        {
            isRocketJumping = false;
        }

        private void OnDestroy()
        {
            characterMotor.onHitGround -= characterMotor_onHitGround;
        }
    }
}
