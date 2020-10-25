using AscendedRPG.Skill_Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscendedRPG.GUIs
{
    // shared componenets and functions of a IDungeonGUI
    public class DGPComponents
    {
        private PictureBox picture;
        // one line textboxes
        private TextBox currentFights, remainingFights, nameBox, turnBox;
        // multi-line textbox
        private TextBox combatLog;
        // the three target radio buttons
        private RadioButton[] targetButtons;
        // the Player Health bar
        private ProgressBar playerHealth;
        // the player's skills
        private ListBox skillBox;
        // buttons
        private Button useSkillButton, leftPartyMember, rightPartyMember;
        // timer
        private Timer timer;
        
        public DGPComponents(PictureBox picture, TextBox currentFights, TextBox remainingFights, TextBox nameBox, TextBox turnBox, TextBox combatLog, RadioButton[] targetButtons, ProgressBar playerHealth, ListBox skillBox, Button useSkillButton, Button leftPartyMember, Button rightPartyMember, Timer timer)
        {
            this.picture = picture;
            this.currentFights = currentFights;
            this.remainingFights = remainingFights;
            this.nameBox = nameBox;
            this.turnBox = turnBox;
            this.combatLog = combatLog;
            this.targetButtons = targetButtons;
            this.playerHealth = playerHealth;
            this.skillBox = skillBox;
            this.useSkillButton = useSkillButton;
            this.leftPartyMember = leftPartyMember;
            this.rightPartyMember = rightPartyMember;
            this.timer = timer;
        }

        #region General Setters
        public void SetPicture(string imageLocation) => picture.ImageLocation = imageLocation;
        public void SetPlayerHealth(int value) => playerHealth.Value = value;
        public void SetPlayerHealthMax(int value) => playerHealth.Maximum = value;
        public void SetPlayerName(string name) => nameBox.Text = name;
        public void SetTurnText(string text) => turnBox.Text = text;
        public void SetCurrentFight(string text) => currentFights.Text = "Current fight: " + text;
        public void SetRemainingFights(string text) => remainingFights.Text = "Remaining fights: " + text;
        public void SetTargetEnabled(int index, bool value) => targetButtons[index].Enabled = value;
        public void SetUseSkillButtonEnabled(bool value) => useSkillButton.Enabled = value;
        #endregion

        public void InitializePlayerHealth(int value)
        {
            playerHealth.Maximum = value;
            playerHealth.Value = playerHealth.Maximum;
        }

        public void ReducePlayerHealth(int value)
        {
            if (playerHealth.Value - value >= playerHealth.Maximum)
                playerHealth.Value = playerHealth.Maximum;
            else if (playerHealth.Value - value <= 0)
                playerHealth.Value = 0;
            else
                playerHealth.Value -= value;
        }

        public bool IsPlayerDead() => (playerHealth.Value == 0);

        public void UpdateCombatLog(string text)
        {
            combatLog.AppendText(text);

            for (int i = 0; i < 2; i++)
                combatLog.AppendText(Environment.NewLine);
        }

        public void UpdateSkillBoxSkills(BattleMember bm)
        {
            var skills = bm.Skills.FindAll(s => s.S_Type == SkillType.OFFENSIVE ||
                                                s.S_Type == SkillType.HEALING || 
                                                s.S_Type == SkillType.OFFENSIVE_BUFF);

            skills.Sort((a,b) => a.GetDamage().CompareTo(b.GetDamage()));
            skills.Reverse();
            skillBox.Items.Clear();
            skillBox.Items.Add("~ Skills ~");
            skills.ForEach(s => skillBox.Items.Add(s));
            skillBox.Items.Add(bm.Weapon.DisplayString());
        }

        public int FindTarget()
        {
            int index = 0;
            for(int i = 0; i < targetButtons.Length; i++)
            {
                if (targetButtons[i].Enabled)
                    if (targetButtons[i].Checked)
                    {
                        index = i;
                        break;
                    }
            }
            return index;
        }

        // Is the item selectable?
        public bool IsSelectable() => (skillBox.SelectedIndex > 0);

        // Is the item a weapon?
        public bool IsWeapon() => (skillBox.SelectedIndex == skillBox.Items.Count - 1);

        // Return the skill
        public Skill GetSelectedSkill() => skillBox.SelectedItem as Skill;

        public void FindNextEnabled()
        {
            for(int i = 0; i < targetButtons.Length; i++)
                if(targetButtons[i].Enabled)
                {
                    targetButtons[i].Checked = true;
                    break;
                }      
        }

        public void StartTimer() => timer.Start();
        public void StopTimer() => timer.Stop();
    }
}
