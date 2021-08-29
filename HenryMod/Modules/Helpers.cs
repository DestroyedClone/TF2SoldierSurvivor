using System;
using System.Collections.Generic;
using RoR2;
using UnityEngine;

namespace HenryMod.Modules
{
    internal static class Helpers
    {
        internal const string agilePrefix = "<style=cIsUtility>Agile.</style> ";

        internal static string ScepterDescription(string desc)
        {
            return "\n<color=#d299ff>SCEPTER: " + desc + "</color>";
        }

        public static T[] Append<T>(ref T[] array, List<T> list)
        {
            var orig = array.Length;
            var added = list.Count;
            Array.Resize<T>(ref array, orig + added);
            list.CopyTo(array, orig);
            return array;
        }

        public static Func<T[], T[]> AppendDel<T>(List<T> list) => (r) => Append(ref r, list);

        public static TeamIndex GetEnemyTeam(TeamIndex teamIndex)
        {
            if (teamIndex == TeamIndex.Monster) return TeamIndex.Player;
            else if (teamIndex == TeamIndex.Player) return TeamIndex.Monster;
            else return TeamIndex.Neutral;
        }

        public static Vector3 GetHeadPosition(CharacterBody characterBody)
        {
            var dist = Vector3.Distance(characterBody.corePosition, characterBody.footPosition);
            return characterBody.corePosition + Vector3.up * dist;
        }

        public static Animator GetModelAnimator(CharacterBody characterBody)
        {
            if (characterBody.modelLocator && characterBody.modelLocator.modelTransform)
            {
                return characterBody.modelLocator.modelTransform.GetComponent<Animator>();
            }
            return null;
        }
    }

    internal static class ArrayHelper
    {
        public static T[] Append<T>(ref T[] array, List<T> list)
        {
            var orig = array.Length;
            var added = list.Count;
            Array.Resize<T>(ref array, orig + added);
            list.CopyTo(array, orig);
            return array;
        }

        public static Func<T[], T[]> AppendDel<T>(List<T> list) => (r) => Append(ref r, list);
    }
}