﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame.PresentationLayer;

namespace TBQuestGame.Models
{
    public class Player : Character
    {
        public enum AttackType {
            BasicAttack, SkillOneAttack, SkillTwoAttack, SkillThreeAttack, ThirdEyeAttack
        }
        public enum ClassType
        {
            Warrior, Archer, Mage
        }
        #region FIELDS
        private double _shield;
        //private double _basicAttack = 3.2;
        private double _basicAttack = 50.0;
        private double _skillOneAttack;
        private double _skillTwoAttack;
        private double _skillThreeAttack;
        private double _thirdEyeAttack;
        private int _gold;
        private AttackType attackType;
        private ClassType classType;
        private Enemy _currentlyAttacking;
        // May remove quest points in the future
        private int _questPoints;

        #endregion

        #region PROPERTIES
        public AttackType AttackTypeProp
        {
            get { return attackType; }
            set { attackType = value;  }
        }
        public ClassType ClassTypeProp
        {
            get { return classType; }
            set { classType = value; }
        }
        public int QuestPoints
        {
            get { return _questPoints; }
            set { _questPoints = value; }
        }
        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }
        public double Shield
        {
            get{ return _shield; }
            set { _shield = value; }
        }
        public double BasicAttack
        {
            get { return _basicAttack; }
            set { _basicAttack = value; }
        }
        public double SkillOneAttack
        {
            get { return _skillOneAttack; }
            set { _skillOneAttack = value; }
        }
        public double SkillTwoAttack
        {
            get { return _skillTwoAttack; }
            set { _skillTwoAttack = value; }
        }
        public double SkillThreeAttack
        {
            get { return _skillThreeAttack; }
            set { _skillThreeAttack = value; }
        }
        public double ThirdEyeAttack
        {
            get { return _thirdEyeAttack; }
            set { _thirdEyeAttack = value; }
        }
        public Enemy currentlyAttacking
        {
            get{ return _currentlyAttacking; }
            set { _currentlyAttacking = value; }
        }
        #endregion

        #region METHODS 
        public override string GetName()
            {
                return base.GetName();
            }
        
            public override bool Alive()
            {
                return IsAlive ? true : false;
            }
        public void setClassTypeSkillDamage()
        {
            switch (classType)
            {
                case ClassType.Warrior:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                case ClassType.Archer:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                case ClassType.Mage:
                    //SkillOneAttack = 
                    //SkillTwoAttack =
                    //SkillThreeAttack = 
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region CONSTRUCTORS 
       
        public void AttackEnemy(GameSessionViewModel gsm, GameSessionView GSV, AttackType typeOfAttack)
        {
            // setting fightingEnemy to the enemy with position in currentEnemies of 
            // Send id of currentfightingenemy and set fightingenemy to currentenemieswiththat position
            // What if current fighting id is 15 and the list is only 4 big, then it would be out of bounds error
            // Need to look for enemy with a specific listPlacement 
            Enemy fightingEnemy = currentlyAttacking;
            attackType = typeOfAttack;
            //If current enemy is alive/has more than 0 health
            fightingEnemy.Alive(GSV,gsm, fightingEnemy); 
            if (fightingEnemy.IsAlive == true)
            {
                switch (attackType)
                {
                    case AttackType.BasicAttack:
                        fightingEnemy.Health -= BasicAttack;
                        GSV.DialogueBox.Text = fightingEnemy.Health.ToString();
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy);
                            GSV.DialogueBox.Text = fightingEnemy.Health.ToString();
                        }
                        break;
                    case AttackType.SkillOneAttack:
                        fightingEnemy.Health -= SkillOneAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy); 
                        }
                        break;
                    case AttackType.SkillTwoAttack:
                        fightingEnemy.Health -= SkillTwoAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy); 
                        }
                        break;
                    case AttackType.SkillThreeAttack:
                        fightingEnemy.Health -= SkillThreeAttack;
                        if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy); 
                        }
                        break;
                    case AttackType.ThirdEyeAttack:
                 

                        if (fightingEnemy.IsAlive == true) {
                            fightingEnemy.Health -= ThirdEyeAttack;
                        }
                            if (fightingEnemy.Health <= 0)
                        {
                            fightingEnemy.Health = 0;
                            fightingEnemy.Alive(GSV, gsm, fightingEnemy); 
                        }
                        break;
                    default:
                        break;
                }

            }
            
        }
        #endregion

        
    }
}
