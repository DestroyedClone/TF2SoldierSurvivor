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
        public float groundedStopwatch = 0f;

        private void Start()
        {
            if (!characterMotor)
            {
                characterMotor = gameObject.GetComponent<CharacterMotor>();
            }

            characterMotor.onHitGround += CharacterMotor_onHitGround;
        }

        private void FixedUpdate() //todo: Add Leniency? GlobalEventManager l.549
        {
            if (characterMotor)
            {
                if (Run.FixedTimeStamp.now - characterMotor.lastGroundedTime > 0.2f)
                {
                    //isRocketJumping = false;
                }
            }
        }

        private void CharacterMotor_onHitGround(ref CharacterMotor.HitGroundInfo hitGroundInfo)
        {
            isRocketJumping = false;
        }

        private void OnDestroy()
        {
            characterMotor.onHitGround -= CharacterMotor_onHitGround;
        }
    }
}
