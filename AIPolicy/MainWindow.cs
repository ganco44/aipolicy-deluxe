using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using AIPolicy.Properties;

namespace AIPolicy
{
    public partial class MainWindow : DevComponents.DotNetBar.Office2007Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonItemExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonItemMenuExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearParams()
        {
            // Clear everything
            groupPanel_ProcParams.Text = Resources.ProcParams;
            labelX_Param1.Text = Resources.NULL;
            labelX_Param2.Text = Resources.NULL;
            labelX_Param3.Text = Resources.NULL;
            labelX_Param4.Text = Resources.NULL;
            labelX_Param5.Text = Resources.NULL;
            labelX_Param5.Text = Resources.NULL;
            labelX_Param6.Text = Resources.NULL;
            labelX_Param7.Text = Resources.NULL;
            textBoxX_Param1.Text = "";
            textBoxX_Param2.Text = "";
            textBoxX_Param3.Text = "";
            textBoxX_Param4.Text = "";
            textBoxX_Param5.Text = "";
            textBoxX_Param6.Text = "";
            textBoxX_Param7.Text = "";
            textBoxX_ParamTarget.Text = "";
        }
        
        private static Condition LoadCondition(BinaryReader br)
        {
            var condition = new Condition();
            condition.OperID = br.ReadInt32();
            condition.ArgBytes = br.ReadInt32();
            condition.Value = br.ReadBytes(condition.ArgBytes);
            condition.ConditionType = br.ReadInt32();

            if (condition.ConditionType == 1)
            {
                condition.ConditionLeft = LoadCondition(br);
                condition.SubNodeL = br.ReadInt32();
                condition.ConditionRight = LoadCondition(br);
                condition.SubNodeR = br.ReadInt32();
            }

            if (condition.ConditionType == 2)
            {
                condition.ConditionRight = LoadCondition(br);
                condition.SubNodeL = br.ReadInt32();
            }
            return condition;
        }

        //**********JADE DYNASTY*************

        private void JDProcList()
        {
            switch (comboBoxEx_Proc.SelectedIndex)
            {
                // Attack(int unk)
                case 0:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Atk;
                    labelX_Param1.Text = Resources.AtkParam1;
                    break;

                // Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CastSkill;
                    labelX_Param1.Text = Resources.Skill_ID;
                    labelX_Param2.Text = Resources.SkillLvl;
                    break;

                // Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Broadcast;
                    labelX_Param1.Text = Resources.ByteCount;
                    labelX_Param2.Text = Resources.Msg;
                    break;

                // Fade_Aggro()
                case 3:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeAggro;
                    break;

                // Exec_ActionSet(int actionset_id)
                case 4:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Exec_AS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Disable_ActionSet(int actionset_id)
                case 5:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DisableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Enable_ActionSet(int actionset_id)
                case 6:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.EnableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CreateTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    labelX_Param2.Text = Resources.Delay;
                    labelX_Param3.Text = Resources.Cycles;
                    break;

                // Delete_Timer(int timerID)
                case 8:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DelTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    break;

                // Flee()
                case 9:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Flee;
                    break;

                // Shift_Aggro()
                case 10:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.BeTaunted;
                    break;

                // Unknown11()
                case 11:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ELEVEN;
                    break;

                // Fade_Aggro()
                case 12:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeAggro;
                    break;

                // Unknown13()
                case 13:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.THIRTEEN;
                    break;

                // Trigger(int triggerID, int ctrlParam)
                case 14:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Trigger;
                    labelX_Param1.Text = Resources.TriggerID;
                    labelX_Param2.Text = Resources.CtrlParam;
                    break;

                // Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SummonMob;
                    labelX_Param1.Text = Resources.ElementsID;
                    labelX_Param2.Text = Resources.TimeInterval;
                    labelX_Param3.Text = Resources.Calls;
                    labelX_Param4.Text = Resources.Survival;
                    labelX_Param5.Text = Resources.MobName;
                    labelX_Param6.Text = Resources.RRange;
                    labelX_Param7.Text = Resources.Unk;
                    break;

                // Unknown16(int unknown)
                case 16:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.SIXTEEN;
                    labelX_Param1.Text = Resources.Unk;
                    break;

                // Set_Path(int pathID)
                // if version == 11 then Set_Path(int pathID, int v11Path)
                case 17:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SetPath;
                    labelX_Param1.Text = Resources.PathID;
                    break;

                // Disappear()
                case 18:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Disappear;
                    break;

                // N/A
                case 19:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // N/A
                case 20:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // Respawn()
                case 21:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Respawn;
                    break;

                // Set_Value(int oldValue, int newValue)
                case 22:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SetValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources._Equals;
                    break;

                // Add_Value(int value, int toAdd)
                case 23:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.AddValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources._Plus;
                    break;

                // N/A
                case 24: groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 25:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SetMobAttr;
                    labelX_Param1.Text = Resources.MobID;
                    labelX_Param2.Text = Resources.Cycles;
                    labelX_Param3.Text = Resources.Unk;
                    labelX_Param4.Text = Resources.Name;
                    labelX_Param5.Text = Resources.Unk;
                    break;

                // Drop_WarSoul(int itemID, int calls, int cycles)
                case 26:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Warsoul;
                    labelX_Param1.Text = Resources.ItemID;
                    labelX_Param2.Text = Resources.Calls;
                    labelX_Param3.Text = Resources.Cycles;
                    break;
            }
        }
        
        private static Condition JDGetCondition(string s)
        {
            var num = 1;
            var num2 = 0;
            var text = s.Substring(1);

            if (s[0] == '(')
            {
                var num3 = 1;
                while (num3 <= text.Length && num >= 0)
                {
                    if (s[num3] == ')')
                    {
                        num--;
                        num2 = num3;
                    }
                    if (s[num3] == '(') num++;
                    num3++;
                }
                if (num2 == 0 || num != 0) return null;

                if (num2 == text.Length)
                {
                    s = text.Substring(0, num2 - 1);
                    return JDGetCondition(s);
                }
            }
            var num4 = 0;
            var stack = new Stack();
            var stack2 = new Stack();
            var text2 = s.Substring(num4, 1);
            while (text2 != "" || stack.Count != 0)
            {
                if (Program.IsNumber(text2))
                {
                    text2 = Program.GetNumber(s.Substring(num4));
                    stack2.Push(text2);
                    num4 += text2.Length;
                }
                else
                {
                    string s2;
                    if (text2 == "(")
                    {
                        if (stack.Count != 0)
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition2 = new Condition { OperID = Program.IDOper(stack.Pop().ToString()) };
                            var tmpCond1 = condition2;
                            tmpCond1.ConditionType = Program.GetOperPrime(tmpCond1.OperID);
                            var tmpCond2 = condition2;
                            tmpCond2.ArgBytes = Program.GetOperArgBytes(tmpCond2.OperID);
                            var tmpCond3 = condition2;
                            tmpCond3.Value = new byte[tmpCond3.ArgBytes];
                            if (condition2.ConditionType == 1)
                            {
                                condition2.ConditionLeft = JDGetCondition(s2);
                                var tmpCond4 = condition2;
                                tmpCond4.SubNodeL = Program.GetSubNodeL(tmpCond4.OperID);
                                condition2.ConditionRight = JDGetCondition(text);
                                var tmpCond5 = condition2;
                                tmpCond5.SubNodeR = Program.GetSubNodeR(tmpCond5.OperID);
                            }
                            if (condition2.ConditionType == 2)
                            {
                                condition2.ConditionRight = JDGetCondition(text);
                                var tmpCond6 = condition2;
                                tmpCond6.SubNodeL = Program.GetSubNodeL(tmpCond6.OperID);
                            }
                            return condition2;
                        }
                        num4 = num2 + 1;
                    }
                    else
                    {
                        if (stack.Count != 0 && (text2 == "" || Program.GetOperPrime(Program.IDOper(stack.Peek().ToString())) <= Program.GetOperPrime(Program.IDOper(text2))))
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition3 = new Condition { OperID = Program.IDOper(stack.Pop().ToString()) };
                            var tmpCond7 = condition3;
                            tmpCond7.ConditionType = Program.GetOperPrime(tmpCond7.OperID);
                            var tmpCond8 = condition3;
                            tmpCond8.ArgBytes = Program.GetOperArgBytes(tmpCond8.OperID);
                            var value = new byte[condition3.ArgBytes];
                            switch (condition3.OperID)
                            {
                                case 0:
                                case 9:
                                case 10:
                                case 19:
                                case 20:
                                case 21:
                                case 23:
                                    value = BitConverter.GetBytes(Convert.ToInt32(stack2.Pop().ToString()));
                                    break;

                                case 1:
                                case 3:
                                case 11:
                                    value = BitConverter.GetBytes(Convert.ToSingle(stack2.Pop().ToString()));
                                    break;
                            }
                            condition3.Value = value;

                            if (condition3.ConditionType == 1)
                            {
                                condition3.ConditionLeft = JDGetCondition(s2);
                                var tmpCond9 = condition3;
                                tmpCond9.SubNodeL = Program.GetSubNodeL(tmpCond9.OperID);
                                condition3.ConditionRight = JDGetCondition(text);
                                var tmpCond10 = condition3;
                                tmpCond10.SubNodeR = Program.GetSubNodeR(tmpCond10.OperID);
                            }

                            if (condition3.ConditionType == 2)
                            {
                                condition3.ConditionRight = JDGetCondition(text);
                                var tmpCond11 = condition3;
                                tmpCond11.SubNodeL = Program.GetSubNodeL(tmpCond11.OperID);
                            }
                            return condition3;
                        }
                        stack.Push(text2);
                        num4++;
                    }
                }
                text2 = num4 < s.Length ? s.Substring(num4, 1) : "";
            }
            return null;
        }

        private Condition JDFixCondition(Condition c)
        {
            if (c.OperID == 22) return AI.ActionController[441].ActionSet[0].Condition;
            if (c.OperID > 22) return null;
            if (c.ConditionType == 1)
            {
                c.ConditionLeft = JDFixCondition(c.ConditionLeft);
                c.ConditionRight = JDFixCondition(c.ConditionRight);

                if (c.ConditionLeft != null && c.ConditionRight != null) return c;
                if (c.ConditionLeft == null && c.ConditionRight != null) return c.ConditionRight;
                if (c.ConditionLeft != null && c.ConditionRight == null) return c.ConditionLeft;
                if (c.ConditionLeft == null && c.ConditionRight == null) return null;
            }
            if (c.ConditionType == 2)
            {
                c.ConditionRight = JDFixCondition(c.ConditionRight);
                return c.ConditionRight != null ? c : null;
            }
            return c;
        }

        private object[] JDReadParameters(int type, BinaryReader br, int ver)
        {
            switch(type)
            {
                // Type 0 - Attack(int unk)
                case 0:
                    return new object[] { br.ReadInt32() };
                
                // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    var byteCount = br.ReadInt32();
                    return new object[] { byteCount, br.ReadBytes(byteCount) };

                // Type 3 - Fade_Aggro()
                case 3:
                    return new object[0];

                // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:
                    return new object[] { br.ReadInt32() };

                // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:
                    return new object[] { br.ReadInt32() };

                // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    return new object[] { br.ReadInt32() };

                // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 8 - Delete_Timer(int timerID)
                case 8:
                    return new object[] { br.ReadInt32() };

                // Type 9 - Flee()
                case 9:
                    return new object[0];

                // Type 10 - Be_Taunted()
                case 10:
                    return new object[0];

                // Type 11 - Unknown11()
                case 11:
                    return new object[0];

                // Type 12 - Fade_Aggro()
                case 12:
                    return new object[0];

                // Type 13 - Unknown13()
                case 13:
                    return new object[0];

                // Type 14 - Trigger(int triggerID, int ctrlParam)
                case 14:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadBytes(32), br.ReadInt32(), br.ReadInt32() };

                // Type 16 - Unknown16()
                case 16:
                    return new object[] { br.ReadInt32() };

                // Type 17 - Set_Path(int pathID, int v11) for version 11 else Set_Path(int pathID)
                case 17:
                    if (ver == 11) return new object[] {br.ReadInt32(), br.ReadInt32()};
                    if (ver < 11) return new object[] {br.ReadInt32()};
                    break;

                // Type 18 - Disappear()
                case 18:
                    return new object[0];

                // // Type 19 - N/A
                //case 19:

                // Type 20 - N/A
                //case 20:

                // Type 21 - Respawn()
                case 21:
                    return new object[0];

                // Type 22 - Set_Value(int oldValue, int newValue)
                case 22:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 23 - Add_Value(int value, int toAdd)
                case 23:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 24 - N/A
                //case 24:

                // Type 25 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 25:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 26 - Drop_WarSoul(int itemID, int calls, int cycles)
                case 26:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };
            }
            
            Cursor = Cursors.Default;
            MessageBox.Show(Resources.UnkType + type.ToString(CultureInfo.InvariantCulture) + Resources.CRLF);
            return new object[0];
        }

        private static string JDProcedureTarget(int target)
        {
            switch (target)
            {
                case 0:
                    return "AGGRO_MOST";
                case 1:
                    return "AGGRO_LEAST";
                case 2:
                    return "AGGRO_LEAST_RAND";
                case 3:
                    return "MOST_HP";
                case 4:
                    return "MOST_MP";
                case 5:
                    return "LEAST_HP";
                case 6:
                    return "TEAM";
                case 7:
                    return "SELF";
                default:
                    return "?";
            }
        }

        private static string JDProcedureExpression(Procedure p, int ver)
        {
            var str = "";

            if (p.Type == 0)
            {
                str = "Attack(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 1)
            {
                str = "Cast_Skill(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 2)
            {
                str = "Broadcast_Message(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + "\"" + Encoding.Unicode.GetString((byte[])p.Parameter[1]).Replace("\0", "") + "\"";
                str += ")";
            }
            if (p.Type == 3)
            {
                str = "Fade_Aggro()";
            }
            if (p.Type == 4)
            {
                str = "Exec_ActionSet(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 5)
            {
                str = "Disable_ActionSet(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 6)
            {
                str = "Enable_ActionSet(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 7)
            {
                str = "Create_Timer(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 8)
            {
                str = "Delete_Timer(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 9)
            {
                str = "Flee()";
            }
            if (p.Type == 10)
            {
                str = "Be_Taunted()";
            }
            if (p.Type == 11)
            {
                str = "Unknown11()";
            }
            if (p.Type == 12)
            {
                str = "Fade_Aggro()";
            }
            if (p.Type == 13)
            {
                str = "Unknown13()";
            }
            if (p.Type == 14)
            {
                str = "Trigger(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 15)
            {
                str = "Summon_Mob(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[3]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + "\"" + Encoding.Unicode.GetString((byte[])p.Parameter[4]).Replace("\0", "") + "\",";
                str = str + ((int)p.Parameter[5]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[6]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 16)
            {
                str = "Unknown16(";
                str = str + ((int) p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 17)
            {
                str = "Set_Path(";
                str += ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture);
                if (ver == 11)
                {
                    str = str + ", " + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture);
                }
                str += ")";
            }
            if (p.Type == 18)
            {
                str = "Disappear()";
            }
            if (p.Type == 21)
            {
                str = "Respawn()";
            }
            if (p.Type == 22)
            {
                str = "Set_Value(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 23)
            {
                str = "Add_Value(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 25)
            {
                str = "Set_Mob_Attribute(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[3]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[4]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }
            if (p.Type == 26)
            {
                str = "Drop_WarSoul(";
                str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                str += ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture);
                str += ")";
            }

            str = str + " Target(" + JDProcedureTarget(p.Target);
            if (p.Target == 6)
            {
                var extra = p.TargetParams;
                str = str + ", " + extra;
            }
            return str + ")";
        }

        private string JDConditionName(int operID)
        {
            switch (operID)
            {
                case 0:
                    return "Is_Timer_Ticking";
                case 1:
                    return "Is_HP_Less";
                case 2:
                    return "Is_Combat_Started";
                case 3:
                    return "Randomize";
                case 4:
                    return "Is_Target_Dead";
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return "Is_Dead";
                case 9:
                    return "Path_To";
                case 10:
                    return "More_Than";
                case 11:
                    return "Distance_To";
                case 12:
                    return "Unknown12";
                case 13:
                    return "Unknown13";
                case 14:
                    return "Unknown14";
                case 15:
                    return "Unknown15";
                case 16:
                    return ">";
                case 17:
                    return "<";
                case 18:
                    return "=";
                case 19:
                    return "Variable";
                case 20:
                    return "Variable_Value";
                case 21:
                    return "Rank";
                case 22:
                    return "NPC_Vent";
                case 23:
                    return "Skill_Cast";
                default:
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(Resources.UnkCondType + operID.ToString(CultureInfo.InvariantCulture));
                        return "?";
                    }
            }
        }

        private string JDConditionValue(Condition c)
        {
            switch (c.OperID)
            {
                case 0:
                case 9:
                case 10:
                case 19:
                case 20:
                case 21:
                case 23:
                    return BitConverter.ToInt32(c.Value, 0).ToString(CultureInfo.InvariantCulture);
                case 1:
                case 3:
                case 11:
                    return BitConverter.ToSingle(c.Value, 0).ToString("F2");
                case 2:
                case 4:
                case 6:
                case 7:
                case 8:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 22:
                    return "";
                case 5:
                    return "NOT";
                default:
                    {
                        Cursor = Cursors.Default;
                        var operID = c.OperID;
                        MessageBox.Show(Resources.UnkCondType + operID.ToString(CultureInfo.InvariantCulture));
                        return "?";
                    }
            }
        }

        private string JDConditionExpression(Condition c)
        {
            var text = "";
            if (c.ConditionType == 1)
            {
                text += "(";
                text += JDConditionExpression(c.ConditionLeft);
                text = text + " " + JDConditionName(c.OperID) + " ";
                text += JDConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType == 2)
            {
                text += JDConditionName(c.OperID);
                text += "(";
                text += JDConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType > 2)
            {
                text += JDConditionName(c.OperID);
                text += "[";
                if (c.ArgBytes > 0) text += JDConditionValue(c);
                text += "]";
            }
            return text;
        }

        private static void JDSaveCondition(Condition c, BinaryWriter bw)
        {
            bw.Write(c.OperID);
            bw.Write(c.ArgBytes);
            bw.Write(c.Value);
            bw.Write(c.ConditionType);
            if (c.ConditionType == 1)
            {
                JDSaveCondition(c.ConditionLeft, bw);
                bw.Write(c.SubNodeL);
                if (c.SubNodeL == 2)
                {
                    JDSaveCondition(c.ConditionRight, bw);
                    bw.Write(c.SubNodeR);
                }
            }
            if (c.ConditionType != 2) return;
            JDSaveCondition(c.ConditionRight, bw);
            bw.Write(c.SubNodeL);
        }

        private object[] JDGetParameters(int type, int ver)
        {
            // Type 0 - Attack(int unk)
            if (type == 0 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
            if (type == 1 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 2 - Broadcast_Message(int byteCount, byte[] message)
            if (type == 2 && textBoxX_Param2.Text != "")
            {
                var unicode = Encoding.Unicode;
                var bytes = unicode.GetBytes(textBoxX_Param2.Text);
                var param1 = bytes.Length + 2;
                var message = new byte[param1];
                Array.Copy(bytes, message, bytes.Length);
                message[bytes.Length] = 0;
                message[bytes.Length + 1] = 0;
                return new object[] { param1, message };
            }

            // Type 3 - Reset_Aggro()
            if (type == 3) return new object[0];

            // Type 4 - Exec_ActionSet(int actionset_id)
            if (type == 4 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 5 - Disable_ActionSet(int actionset_id)
            if (type == 5 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 6 - Enable_ActionSet(int actionset_id)
            if (type == 6 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 7 - Create_Timer(int timerID, int delay, int cycles)
            if (type == 7 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                return new object[] { param1, param2, param3 };
            }

            // Type 8 - Delete_Timer(int timerID)
            if (type == 8 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 9 - Flee()
            if (type == 9) return new object[0];

            // Type 10 - Be_Taunted()
            if (type == 10) return new object[0];

            // Type 11 - Unknown11()
            if (type == 11) return new object[0];

            // Type 12 - Fade_Aggro()
            if (type == 12) return new object[0];

            // Type 13 - Unknown13()
            if (type == 13) return new object[0];

            // Type 14 - Trigger(int triggerID, int ctrlParam)
            if (type == 14 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return
                    new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
            if (type == 15 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" &&
                textBoxX_Param3.Text != "" && textBoxX_Param4.Text != "" && textBoxX_Param5.Text != "" &&
                textBoxX_Param6.Text != "" && textBoxX_Param7.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                var param4 = Convert.ToInt32(textBoxX_Param4.Text);
                var param6 = Convert.ToInt32(textBoxX_Param6.Text);
                var param7 = Convert.ToInt32(textBoxX_Param7.Text);
                var message = new byte[32];
                var msgSize = Encoding.Unicode.GetBytes(textBoxX_Param5.Text);
                if (msgSize.Length < 32)
                {
                    Array.Copy(msgSize, message, msgSize.Length);
                    for (var i = msgSize.Length; i < 32; i++) message[i] = 0;
                }
                else Array.Copy(msgSize, message, 32);
                return new object[] { param1, param2, param3, param4, message, param6, param7 };
            }

            // Type 16 - Unknown16(int unkInt string unkStr)
            if (type == 16 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 17 - Set_Path(int pathID)
            //      if version = 11 then Set_Path(int pathID, int v11Path)
            if (type == 17 && textBoxX_Param1.Text != "")
            {
                return ver == 11 ? new object[] {Convert.ToInt32(textBoxX_Param1.Text),
                    Convert.ToInt32(textBoxX_Param2.Text)} : new object[] { Convert.ToInt32(textBoxX_Param1.Text) };
            }

            // Type 18 - Disappear()
            if (type == 18) return new object[0];

            // Type 19 - N/A

            // Type 20 - N/A

            // Type 21 - Respawn()
            if (type == 21) return new object[0];

            // Type 22 - Set_Value(int oldValue, int newValue)
            if (type == 22 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 23 - Add_Value(int value, int toAdd)
            if (type == 23 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 24 - N/A

            // Type 25 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
            if (type == 25 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" &&
                textBoxX_Param3.Text != "" && textBoxX_Param4.Text != "" && textBoxX_Param5.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                var param4 = Convert.ToInt32(textBoxX_Param4.Text);
                var param5 = Convert.ToInt32(textBoxX_Param5.Text);
                return new object[] { param1, param2, param3, param4, param5 };
            }

            // Type 26 - Drop_WarSoul(int itemID, int calls, int cycles)
            if (type == 26 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                return new object[] { param1, param2, param3 };
            }

            // Type Error
            Cursor = Cursors.Default;
            MessageBox.Show(Resources.ErrParams);
            return null;
        }

        private static void JDWriteParameters(int type, object[] parameters, BinaryWriter bw, int ver)
        {
            switch (type)
            {
                // Type 0 - Attack(int unk)
                case 0:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    var value = (int)parameters[0];
                    bw.Write(value);
                    bw.Write((byte[])parameters[1]);
                    break;

                // Type 3 - Reset_Aggro()
                // no parameters...
                case 3:
                    break;

                // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    break;

                // Type 8 - Delete_Timer(int timerID)
                case 8:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 9 - Flee()
                // no parameters...
                case 9:

                // Type 10 - Be_Taunted()
                // no parameters...
                case 10:

                // Type 11 - Unknown11()
                // no parameters...
                case 11:

                // Type 12 - Fade_Aggro()
                // no parameters...
                case 12:

                // Tpye 13 - Unknown13()
                // no parameters...
                case 13:
                    break;

                // Type 14 - Trigger(int triggerID, int ctrlParam)
                case 14:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    bw.Write((int)parameters[3]);
                    bw.Write((byte[])parameters[4]);
                    bw.Write((int)parameters[5]);
                    bw.Write((int)parameters[6]);
                    break;

                // Type 16 - Unknown16(int unk)
                case 16:
                    bw.Write((int)parameters[0]);
                    break;

                    // Type 17 - Set_Path(int pathID)
                    // if version = 11 then Set_Path(int pathID, int v11Path)
                case 17:
                    bw.Write((int)parameters[0]);
                    if (ver == 11) bw.Write((int)parameters[1]);
                    break;

                // Type 18 - Disappear()
                case 18:
                
                // Type 19 - N/A
                case 19:

                // Type 20 - N/A
                case 20:

                // Type 21 - Respawn()
                case 21:
                    break;

                // Type 22- Set_Value(int oldValue, int newValue)
                case 22:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 23- Add_Value(int value, int toAdd)
                case 23:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 24-  N/A
                case 24:
                    break;

                // Type 25 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 25:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    bw.Write((int)parameters[3]);
                    bw.Write((int)parameters[4]);
                    break;

                // Type 26 - Drop_WarSoul(int itemID, int calls, int cycles)
                case 26:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    break;
            }
        }

        //**********PERFECT WORLD*************

        private void PWProcList()
        {
            switch (comboBoxEx_Proc.SelectedIndex)
            {
                // Attack(int unk)
                case 0:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Atk;
                    labelX_Param1.Text = Resources.AtkParam1;
                    break;

                // Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CastSkill;
                    labelX_Param1.Text = Resources.Skill_ID;
                    labelX_Param2.Text = Resources.SkillLvl;
                    break;

                // Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Broadcast;
                    labelX_Param1.Text = Resources.ByteCount;
                    labelX_Param2.Text = Resources.Msg;
                    break;

                // Reset_Aggro()
                case 3:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.ResetAggro;
                    break;

                // Exec_ActionSet(int actionset_id)
                case 4:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Exec_AS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Disable_ActionSet(int actionset_id)
                case 5:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DisableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Enable_ActionSet(int actionset_id)
                case 6:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.EnableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CreateTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    labelX_Param2.Text = Resources.Delay;
                    labelX_Param3.Text = Resources.Cycles;
                    break;

                // Delete_Timer(int timerID)
                case 8:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DelTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    break;

                // Flee()
                case 9:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Flee;
                    break;

                // Be_Taunted()
                case 10:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.BeTaunted;
                    break;

                // Fade_Target()
                case 11:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeTarget;
                    break;

                // Fade_Aggro()
                case 12:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeAggro;
                    break;

                // Break()
                case 13:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Break;
                    break;

                // NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NPCGenerator;
                    labelX_Param1.Text = Resources.TriggerID;
                    labelX_Param2.Text = Resources.CtrlParam;
                    break;

                // Initialize_Public_Counter
                case 15:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.InitPubCount;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    break;

                // Increment_Public_Counter
                case 16:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.IncPubCount;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    break;

                // Player_Aimed_NPC_Spawn
                case 17:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NPCSpawn;
                    labelX_Param1.Text = Resources.ElementsID;
                    labelX_Param2.Text = Resources.TimeInterval;
                    labelX_Param3.Text = Resources.Calls;
                    labelX_Param4.Text = Resources.Survival;
                    labelX_Param5.Text = Resources.MobName;
                    labelX_Param6.Text = Resources.RRange;
                    labelX_Param7.Text = Resources.Unk;
                    break;

                // Change_Path
                case 18:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.ChangePath;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    labelX_Param4.Text = Resources.Unk;
                    break;

                // Play_Action
                case 19:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.PlayAction;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    labelX_Param4.Text = Resources.Unk;
                    break;
            }
        }

        private static object[] PWReadParameters(int type, BinaryReader br)
        {
            switch (type)
            {
                // Type 0 - Attack(int unk)
                case 0:
                    return new object[] { br.ReadInt32() };

                // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    var byteCount = br.ReadInt32();
                    return new object[] { byteCount, br.ReadBytes(byteCount) };

                // Type 3 - Reset_Aggro()
                case 3:
                    return new object[0];

                // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:
                    return new object[] { br.ReadInt32() };

                // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:
                    return new object[] { br.ReadInt32() };

                // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    return new object[] { br.ReadInt32() };

                // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 8 - Delete_Timer(int timerID)
                case 8:
                    return new object[] { br.ReadInt32() };

                // Type 9 - Flee()
                case 9:
                    return new object[0];

                // Type 10 - Be_Taunted()
                case 10:

                // Type 11 - Fade_Target()
                case 11:

                // Type 12 - Fade_Aggro()
                case 12:

                // Type 13 - Break()
                case 13:
                    return new object[0];

                // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 15 - Initialize_Public_Counter(int x, int y, int z)
                case 15:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 16 - Increment_Public_Counter(int x, int y)
                case 16:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 17 - Player_Aimed_NPC_Spawn(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 17:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 18 - Change_Path(int w, int x, int y, int z)
                case 18:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 19 - Play_Action(sting w, int x, int y, int z)
                case 19:
                    return new object[] { br.ReadBytes(128), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };
                case 62:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // default - unknown Type
                default:
                    if (type > 19) MessageBox.Show(Resources.UnkType + type);
                    return new object[0];
            }
        }
        
        private static string PWProcedureTarget(int target, object[] targetParameters)
        {
            switch (target)
            {
                case 0:
                    return "AGGRO_FIRST";
                case 1:
                    return "AGGRO_SECOND";
                case 2:
                    return "AGGRO_SECOND_RAND";
                case 3:
                    return "MOST_HP";
                case 4:
                    return "MOST_MP";
                case 5:
                    return "LEAST_HP";
                case 6:
                    return "CLASS_COMBO," + targetParameters[0];
                case 7:
                    return "SELF";
                default:
                    return "?";
            }
        }
        
        private static object[] PWReadTargetParameters(int type, BinaryReader br)
        {
            switch (type)
            {
                case 6:
                    return new object[] {br.ReadInt32()};
                default:
                    return new object[0];
            }
        }

        private static string PWConditionExpression(Condition c)
        {
            var text = "";
            if (c.ConditionType == 1)
            {
                text += "(";
                text += PWConditionExpression(c.ConditionLeft);
                text += " " + PWConditionName(c.OperID) + " ";
                text += PWConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType == 2)
            {
                text += PWConditionName(c.OperID);
                text += "(";
                text += PWConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType > 2)
            {
                text += PWConditionName(c.OperID);
                text += "(";
                if (c.ArgBytes > 0)
                {
                    text += PWConditionValue(c);
                }
                text += ")";
            }
            return text;
        }

        private static string PWConditionName(int operID)
        {
            switch (operID)
            {
                case 0:
                    return "Is_Timer_Ticking";
                case 1:
                    return "Is_HP_Less";
                case 2:
                    return "Is_Combat_Started";
                case 3:
                    return "Randomize";
                case 4:
                    return "Is_Target_Killed";
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return "Is_Dead";
                case 9:
                    return "+";
                case 10:
                    return "-";
                case 11:
                    return "==";
                case 12:
                    return ">";
                case 13:
                    return ">=";
                case 14:
                    return "<";
                case 15:
                    return ">";
                case 16:
                    return "Public_Counter";
                case 17:
                    return "Value";
                case 18:
                    return "Is_Event?";
                default:
                    return "?";
            }
        }

        private static string PWConditionValue(Condition c)
        {
            switch (c.OperID)
            {
                case 0:
                case 16:
                case 17:
                    return BitConverter.ToInt32(c.Value, 0).ToString(CultureInfo.InvariantCulture);
                case 1:
                case 3:
                    return BitConverter.ToSingle(c.Value, 0).ToString("F2");
                case 2:
                case 4:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 18:
                    return "";
                case 5:
                    return "NOT";
                default:
                    return "?";
            }
        }
        
        private static string PWProcedureExpression(Procedure p)
        {
            var str = "";

            int param1;
            int param2;
            int param3;
            int param4;
            switch(p.Type)
            {
                case 0:
                    str = "Attack(";
                    param1 = (int) p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 1:
                    str = "Cast_Skill(";
                    param1 = (int) p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int) p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 2:
                    str = "Broadcast_Message(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    str += "\"" + Encoding.Unicode.GetString((byte[])p.Parameter[1]).Replace("\0", "") + "\"";
                    str += ")";
                    break;
                case 3:
                    str = "Reset_Aggro()";
                    break;
                case 4:
                    str = "Execute_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 5:
                    str = "Disable_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 6:
                    str = "Enable_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 7:
                    str = "Create_Timer(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 8:
                    str = "Remove_Timer(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 9:
                    str = "Flee()";
                    break;
                case 10:
                    str = "Be_Taunted()";
                    break;
                case 11:
                    str = "Fade_Target()";
                    break;
                case 12:
                    str = "Fade_Aggro()";
                    break;
                case 13:
                    str = "Break()";
                    break;
                case 14:
                    var paramStr = (int)p.Parameter[1] % 2 < 1 ? "start" : "stop";
                    str = "NPC_Generator(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + "[" + paramStr + "]";
                    str += ")";
                    break;
                case 15:
                    str = "Initialize_Public_Counter(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 16:
                    str = "Increment_Public_Counter(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 17:
                    str = "Player_Aimed_NPC_Spawn(";
                    str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[3]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[4]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str += ((int)p.Parameter[5]).ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 18:
                    str = "Change_Path(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture) + ", ";
                    param4 = (int)p.Parameter[3];
                    str += param4.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 19:
                    str = "Play_Action(";
                    str += "\"" + Encoding.GetEncoding("GBK").GetString((byte[])p.Parameter[0]).Replace("\0", "") + "\", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture) + ", ";
                    param4 = (int)p.Parameter[3];
                    str += param4.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
            }
            return str + (" " + PWProcedureTarget(p.Target, p.TargetParams));
        }

        private static void PWSaveCondition(Condition c, BinaryWriter bw)
        {
            bw.Write(c.OperID);
            bw.Write(c.ArgBytes);
            bw.Write(c.Value);
            bw.Write(c.ConditionType);
            if (c.ConditionType == 1)
            {
                PWSaveCondition(c.ConditionLeft, bw);
                bw.Write(c.SubNodeL);
                if (c.SubNodeL == 2)
                {
                    PWSaveCondition(c.ConditionRight, bw);
                    bw.Write(c.SubNodeR);
                }
            }
            if (c.ConditionType != 2) return;
            PWSaveCondition(c.ConditionRight, bw);
            bw.Write(c.SubNodeL);
        }

        private object[] PWGetParameters(int type)
        {
            // Type 0 - Attack(int unk)
            if (type == 0 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
            if (type == 1 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 2 - Broadcast_Message(int byteCount, byte[] message)
            if (type == 2 && textBoxX_Param2.Text != "")
            {
                var unicode = Encoding.Unicode;
                var bytes = unicode.GetBytes(textBoxX_Param2.Text);
                var param1 = bytes.Length + 2;
                var message = new byte[param1];
                Array.Copy(bytes, message, bytes.Length);
                message[bytes.Length] = 0;
                message[bytes.Length + 1] = 0;
                return new object[] { param1, message };
            }

            // Type 3 - Reset_Aggro()
            if (type == 3) return new object[0];

            // Type 4 - Exec_ActionSet(int actionset_id)
            if (type == 4 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 5 - Disable_ActionSet(int actionset_id)
            if (type == 5 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 6 - Enable_ActionSet(int actionset_id)
            if (type == 6 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 7 - Create_Timer(int timerID, int delay, int cycles)
            if (type == 7 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text), Convert.ToInt32(textBoxX_Param3.Text) };

            // Type 8 - Delete_Timer(int timerID)
            if (type == 8 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 9 - Flee()
            if (type == 9) return new object[0];

            // Type 10 - Be_Taunted()
            if (type == 10) return new object[0];

            // Type 11 - Fade_Target()
            if (type == 11) return new object[0];

            // Type 12 - Fade_Aggro()
            if (type == 12) return new object[0];

            // Type 13 - Break()
            if (type == 13) return new object[0];

            // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
            if (type == 14 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 15 - Initialize_Public_Counter(int x, int y, int z)
            if (type == 15 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text), Convert.ToInt32(textBoxX_Param3.Text) };

            // Type 16 - Increment_Public_Counter(int x, int y)
            if (type == 16 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 17 - Player_Aimed_NPC_Spawn(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
            if (type == 17 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" &&
                textBoxX_Param3.Text != "" && textBoxX_Param4.Text != "" && textBoxX_Param5.Text != "" &&
                textBoxX_Param6.Text != "" && textBoxX_Param7.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                var param4 = Convert.ToInt32(textBoxX_Param4.Text);
                var param6 = Convert.ToInt32(textBoxX_Param6.Text);
                var param7 = Convert.ToInt32(textBoxX_Param7.Text);
                var message = new byte[32];
                var msgSize = Encoding.Unicode.GetBytes(textBoxX_Param5.Text);
                if (msgSize.Length < 32)
                {
                    Array.Copy(msgSize, message, msgSize.Length);
                    for (var i = msgSize.Length; i < 32; i++) message[i] = 0;
                }
                else Array.Copy(msgSize, message, 32);
                return new object[] { param1, param2, param3, param4, message, param6, param7 };
            }

            // Type 18 - Change_Path(int w, int x, int y, int z)
            if (type == 18 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text), Convert.ToInt32(textBoxX_Param3.Text) };

            // Type 19 - Play_Action(sting w, int x, int y, int z)
            if (type == 19 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "" &&
                textBoxX_Param4.Text != "")
                return new object[]
                {
                    Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text),
                    Convert.ToInt32(textBoxX_Param3.Text), Convert.ToInt32(textBoxX_Param4.Text)
                };
            
            // Type Error
            Cursor = Cursors.Default;
            MessageBox.Show(Resources.ErrParams);
            return null;
        }

        private static void PWWriteParameters(int type, object[] parameters, BinaryWriter bw)
        {
            switch (type)
            {
                    // Type 0 - Attack(int unk)
                case 0:
                    bw.Write((int) parameters[0]);
                    break;

                    // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    break;

                    // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    bw.Write((int) parameters[0]);
                    bw.Write((byte[]) parameters[1]);
                    break;

                    // Type 3 - Reset_Aggro()
                    // no parameters...
                case 3:
                    break;

                    // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:

                    // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:

                    // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    bw.Write((int) parameters[0]);
                    break;

                    // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    bw.Write((int) parameters[2]);
                    break;

                    // Type 8 - Delete_Timer(int timerID)
                case 8:
                    bw.Write((int) parameters[0]);
                    break;

                    // Type 9 - Flee()
                    // no parameters...
                case 9:

                    // Type 10 - Be_Taunted()
                    // no parameters...
                case 10:

                    // Type 11 - Fade_Target()
                    // no parameters...
                case 11:

                    // Type 12 - Fade_Aggro()
                    // no parameters...
                case 12:

                    // Tpye 13 - Break()
                    // no parameters...
                case 13:
                    break;

                    // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    break;

                    // Type 15 - Initialize_Public_Counter(int x, int y, int z)
                case 15:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    bw.Write((int) parameters[2]);
                    break;

                    // Type 16 - Increment_Public_Counter(int x, int y)
                case 16:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    break;

                // Type 17 - Player_Aimed_NPC_Spawn(int elementsID, int unknown, int unknown, int unknown, int unknown, int unknown)
                case 17:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    bw.Write((int) parameters[2]);
                    bw.Write((int) parameters[3]);
                    bw.Write((int) parameters[4]);
                    bw.Write((int) parameters[5]);
                    break;

                    // Type 18 - Change_Path(int w, int x, int y, int z)
                case 18:
                    bw.Write((int) parameters[0]);
                    bw.Write((int) parameters[1]);
                    bw.Write((int) parameters[2]);
                    bw.Write((int) parameters[3]);
                    break;

                    // Type 19 - Play_Action(sting w, int x, int y, int z)
                case 19:
                    bw.Write((byte[])parameters[0]);
                    bw.Write((int) parameters[1]);
                    bw.Write((int) parameters[2]);
                    bw.Write((int) parameters[3]);
                    break;
            }
        }

        //***********Forsaken World*************

        private void FWProcList()
        {
            switch (comboBoxEx_Proc.SelectedIndex)
            {
                // Attack(int unk)
                case 0:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Atk;
                    labelX_Param1.Text = Resources.AtkParam1;
                    break;

                // Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CastSkill;
                    labelX_Param1.Text = Resources.Skill_ID;
                    labelX_Param2.Text = Resources.SkillLvl;
                    break;

                // Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Broadcast;
                    labelX_Param1.Text = Resources.ByteCount;
                    labelX_Param2.Text = Resources.Msg;
                    break;

                // Fade_Aggro()
                case 3:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeAggro;
                    break;

                // Exec_ActionSet(int actionset_id)
                case 4:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Exec_AS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Disable_ActionSet(int actionset_id)
                case 5:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DisableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Enable_ActionSet(int actionset_id)
                case 6:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.EnableAS;
                    labelX_Param1.Text = Resources.ASID;
                    break;

                // Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.CreateTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    labelX_Param2.Text = Resources.Delay;
                    labelX_Param3.Text = Resources.Cycles;
                    break;

                // Delete_Timer(int timerID)
                case 8:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.DelTimer;
                    labelX_Param1.Text = Resources.TimerID;
                    break;

                // Flee()
                case 9:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Flee;
                    break;

                // Be_Taunted()
                case 10:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.BeTaunted;
                    break;

                // Unknown11()
                case 11:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ELEVEN;
                    break;

                // N/A
                case 12:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // Unknown13()
                case 13:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.THIRTEEN;
                    break;

                // NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NPCGenerator;
                    labelX_Param1.Text = Resources.TriggerID;
                    labelX_Param2.Text = Resources.CtrlParam;
                    break;

                // Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SummonMob;
                    labelX_Param1.Text = Resources.ElementsID;
                    labelX_Param2.Text = Resources.TimeInterval;
                    labelX_Param3.Text = Resources.Calls;
                    labelX_Param4.Text = Resources.Survival;
                    labelX_Param5.Text = Resources.MobName;
                    labelX_Param6.Text = Resources.RRange;
                    labelX_Param7.Text = Resources.Unk;
                    break;

                // Unknown16(int unknown)
                case 16:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.SIXTEEN;
                    labelX_Param1.Text = Resources.Unk;
                    break;

                // Unknown17(int x, int y)
                case 17:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.SEVENTEEN;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    break;

                // Disappear()
                case 18:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Disappear;
                    break;

                // Unknown19(int x)
                case 19:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.NINETEEN;
                    labelX_Param1.Text = Resources.Unk;
                    break;

                // N/A
                case 20:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 21:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SetMobAttr;
                    labelX_Param1.Text = Resources.MobID;
                    labelX_Param1.Text = Resources.Cycles;
                    labelX_Param1.Text = Resources.Unk + Resources.ONE;
                    labelX_Param1.Text = Resources.Name;
                    labelX_Param1.Text = Resources.Unk + Resources.TWO;
                    break;

                // Set_Value(int oldValue, int newValue)
                case 22:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.SetValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources._Equals;
                    break;

                // Add_Value(int value, int toAdd)
                case 23:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.AddValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources._Plus;
                    break;

                // Unknown24(int x, int y)
                case 24:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWOFOUR;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    break;

                // Unknown25(int x, int y, int z)
                case 25:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWOFIVE;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    break;

                // Unknown26()
                case 26:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWOSIX;
                    break;
            }
        }
        
        private static object[] FWReadParameters(int type, BinaryReader br)
        {
            switch (type)
            {
                // Type 0 - Attack(int unk)
                case 0:
                    return new object[] { br.ReadInt32() };

                // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    var byteCount = br.ReadInt32();
                    return new object[] { byteCount, br.ReadBytes(byteCount) };

                // Type 3 - Reset_Aggro()
                case 3:
                    return new object[0];

                // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:
                    return new object[] { br.ReadInt32() };

                // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:
                    return new object[] { br.ReadInt32() };

                // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    return new object[] { br.ReadInt32() };

                // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 8 - Delete_Timer(int timerID)
                case 8:
                    return new object[] { br.ReadInt32() };

                // Type 9 - Flee()
                case 9:
                    return new object[0];

                // Type 10 - Be_Taunted()
                case 10:
                    return new object[0];

                // Type 11 - Fade_Target()
                case 11:
                    return new object[0];

                // Type 12 - N/A
                case 12:
                    return new object[0];

                // Type 13 - Unknown13()
                case 13:
                    return new object[0];

                // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadBytes(32), br.ReadInt32(), br.ReadInt32() };

                // Type 16 - Unknown16()
                case 16:
                    return new object[0];

                // Type 17 - Unknown17(intx, int y)
                case 17:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 18 - Disappear()
                case 18:
                    return new object[0];

                // Type 19 - Unknown19(int x)
                case 19:
                    return new object[] { br.ReadInt32() };

                // Type 20 - N/A
                case 20:
                    return new object[0];

                // Type 21 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 21:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 22 - Set_Value(int oldValue, int newValue)
                case 22:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 23 - Add_Value(int value, int toAdd)
                case 23:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 24 - Unknown24(int x, int y)
                case 24:
                    return new object[] { br.ReadInt32(), br.ReadInt32() };

                // Type 25 - Unknown25(int x, int y, int z)
                case 25:
                    return new object[] { br.ReadInt32(), br.ReadInt32(), br.ReadInt32() };

                // Type 26 - Unknown26()
                case 26:
                    return new object[0];

                // Type 27 - Unknown27()
                case 27:
                    return new object[0];


                // default - unknown Type
                default:
                    if (type > 27) MessageBox.Show(Resources.UnkType + type);
                    return new object[0];
            }
        }

        private static string FWProcedureTarget(int target, object[] targetParameters)
        {
            switch (target)
            {
                case 0:
                    return "AGGRO_FIRST";
                case 1:
                    return "AGGRO_SECOND";
                case 2:
                    return "AGGRO_SECOND_RAND";
                case 3:
                    return "MOST_HP";
                case 4:
                    return "MOST_MP";
                case 5:
                    return "LEAST_HP";
                case 6:
                    return "TEAM";
                case 7:
                    return "SELF";
                default:
                    return "?";
            }
        }

        private string FWConditionExpression(Condition c)
        {
            var text = "";
            if (c.ConditionType == 1)
            {
                text += "(";
                text += FWConditionExpression(c.ConditionLeft);
                text = text + " " + FWConditionName(c.OperID) + " ";
                text += FWConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType == 2)
            {
                text += FWConditionName(c.OperID);
                text += "(";
                text += FWConditionExpression(c.ConditionRight);
                text += ")";
            }
            if (c.ConditionType > 2)
            {
                text += FWConditionName(c.OperID);
                text += "(";
                if (c.ArgBytes > 0) text += FWConditionValue(c);
                text += ")";
            }
            return text;
        }

        private string FWConditionName(int operID)
        {
            switch (operID)
            {
                case 0:
                    return "Is_Timer_Ticking";
                case 1:
                    return "Is_HP_Less";
                case 2:
                    return "Is_Combat_Started";
                case 3:
                    return "Randomize";
                case 4:
                    return "Is_Target_Dead";
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return "Is_Dead";
                case 9:
                    return "Path_To";
                case 10:
                    return "More_Than";
                case 11:
                    return "Distance_To";
                case 12:
                    return "Unknown12";
                case 13:
                    return "Unknown13";
                case 14:
                    return "Unknown14";
                case 15:
                    return "Unknown15";
                case 16:
                    return ">";
                case 17:
                    return "<";
                case 18:
                    return "=";
                case 19:
                    return "Variable";
                case 20:
                    return "Variable_Value";
                case 21:
                    return "Rank";
                case 22:
                    return "NPC_Vent";
                case 23:
                    return "Skill_Cast";
                default:
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show(Resources.UnkCondType + operID.ToString(CultureInfo.InvariantCulture));
                        return "?";
                    }
            }
        }

        private string FWConditionValue(Condition c)
        {
            switch (c.OperID)
            {
                case 0:
                case 9:
                case 10:
                case 19:
                case 20:
                case 21:
                case 23:
                    return BitConverter.ToInt32(c.Value, 0).ToString(CultureInfo.InvariantCulture);
                case 1:
                case 3:
                case 11:
                    return BitConverter.ToSingle(c.Value, 0).ToString("F2");
                case 2:
                case 4:
                case 6:
                case 7:
                case 8:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 22:
                    return "";
                case 5:
                    return "NOT";
                default:
                    {
                        Cursor = Cursors.Default;
                        var operID = c.OperID;
                        MessageBox.Show(Resources.UnkCondType + operID.ToString(CultureInfo.InvariantCulture));
                        return "?";
                    }
            }
        }
        
        private static string FWProcedureExpression(Procedure p)
        {
            var str = "";

            int param1;
            int param2;
            int param3;
            switch (p.Type)
            {
                case 0:
                    str = "Attack(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 1:
                    str = "Cast_Skill(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 2:
                    str = "Broadcast_Message(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    str += "\"" + Encoding.Unicode.GetString((byte[])p.Parameter[1]).Replace("\0", "") + "\"";
                    str += ")";
                    break;
                case 3:
                    str = "Reset_Aggro()";
                    break;
                case 4:
                    str = "Execute_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 5:
                    str = "Disable_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 6:
                    str = "Enable_ActionSet(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 7:
                    str = "Create_Timer(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 8:
                    str = "Remove_Timer(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 9:
                    str = "Flee()";
                    break;
                case 10:
                    str = "Be_Taunted()";
                    break;
                case 11:
                    str = "Fade_Target()";
                    break;
                case 13:
                    str = "Unknown13()";
                    break;
                case 14:
                    var paramStr = (int)p.Parameter[1] % 2 < 1 ? "start" : "stop";
                    str = "NPC_Generator(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + "[" + paramStr + "]";
                    str += ")";
                    break;
                case 15:
                    str = "Summon_Mob(";
                    str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[3]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + "\"" + Encoding.Unicode.GetString((byte[])p.Parameter[4]).Replace("\0", "") + "\",";
                    str = str + ((int)p.Parameter[5]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str += ((int)p.Parameter[6]).ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 16:
                    str = "Unknown16()";
                    break;
                case 17:
                    str = "Unknown17(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 18:
                    str = "Disappear()";
                    break;
                case 19:
                    str = "Unknown19(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 21:
                    str = "Set_Mob_Attribute(";
                    str = str + ((int)p.Parameter[0]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[1]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[2]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str = str + ((int)p.Parameter[3]).ToString(CultureInfo.InvariantCulture) + ", ";
                    str += ((int)p.Parameter[4]).ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 22:
                    str = "Set_Value(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 23:
                    str = "Add_Value(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 24:
                    str = "Unknown24(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 25:
                    str = "Unknown25(";
                    param1 = (int)p.Parameter[0];
                    str += param1.ToString(CultureInfo.InvariantCulture) + ", ";
                    param2 = (int)p.Parameter[1];
                    str += param2.ToString(CultureInfo.InvariantCulture) + ", ";
                    param3 = (int)p.Parameter[2];
                    str += param3.ToString(CultureInfo.InvariantCulture);
                    str += ")";
                    break;
                case 26:
                    str = "Unknown26()";
                    break;
                case 27:
                    str = "Unknown27()";
                    break;
            }
            return str + (" " + FWProcedureTarget(p.Target, p.TargetParams));
        }

        private static void FWSaveCondition(Condition c, BinaryWriter bw)
        {
            bw.Write(c.OperID);
            bw.Write(c.ArgBytes);
            bw.Write(c.Value);
            bw.Write(c.ConditionType);
            if (c.ConditionType == 1)
            {
                PWSaveCondition(c.ConditionLeft, bw);
                bw.Write(c.SubNodeL);
                if (c.SubNodeL == 2)
                {
                    PWSaveCondition(c.ConditionRight, bw);
                    bw.Write(c.SubNodeR);
                }
            }
            if (c.ConditionType != 2) return;
            PWSaveCondition(c.ConditionRight, bw);
            bw.Write(c.SubNodeL);
        }

        private object[] FWGetParameters(int type)
        {
            // Type 0 - Attack(int unk)
            if (type == 0 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
            if (type == 1 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 2 - Broadcast_Message(int byteCount, byte[] message)
            if (type == 2 && textBoxX_Param2.Text != "")
            {
                var unicode = Encoding.Unicode;
                var bytes = unicode.GetBytes(textBoxX_Param2.Text);
                var param1 = bytes.Length + 2;
                var message = new byte[param1];
                Array.Copy(bytes, message, bytes.Length);
                message[bytes.Length] = 0;
                message[bytes.Length + 1] = 0;
                return new object[] { param1, message };
            }

            // Type 3 - Reset_Aggro()
            if (type == 3) return new object[0];

            // Type 4 - Exec_ActionSet(int actionset_id)
            if (type == 4 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 5 - Disable_ActionSet(int actionset_id)
            if (type == 5 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 6 - Enable_ActionSet(int actionset_id)
            if (type == 6 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 7 - Create_Timer(int timerID, int delay, int cycles)
            if (type == 7 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text), Convert.ToInt32(textBoxX_Param3.Text) };

            // Type 8 - Delete_Timer(int timerID)
            if (type == 8 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 9 - Flee()
            if (type == 9) return new object[0];

            // Type 10 - Be_Taunted()
            if (type == 10) return new object[0];

            // Type 11 - Fade_Target()
            if (type == 11) return new object[0];

            // Type 12 - N/A

            // Type 13 - Unknown13()
            if (type == 13) return new object[0];

            // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
            if (type == 14 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
            if (type == 15 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" &&
                textBoxX_Param3.Text != "" && textBoxX_Param4.Text != "" && textBoxX_Param5.Text != "" &&
                textBoxX_Param6.Text != "" && textBoxX_Param7.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                var param4 = Convert.ToInt32(textBoxX_Param4.Text);
                var param6 = Convert.ToInt32(textBoxX_Param6.Text);
                var param7 = Convert.ToInt32(textBoxX_Param7.Text);
                var message = new byte[32];
                var msgSize = Encoding.Unicode.GetBytes(textBoxX_Param5.Text);
                if (msgSize.Length < 32)
                {
                    Array.Copy(msgSize, message, msgSize.Length);
                    for (var i = msgSize.Length; i < 32; i++) message[i] = 0;
                }
                else Array.Copy(msgSize, message, 32);
                return new object[] { param1, param2, param3, param4, message, param6, param7 };
            }

            // Type 16 - Unknown16()
            if (type == 16) return new object[0];

            // Type 17 - Unknown17(int x, int y)
            if (type == 17 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 18 - Disappear()
            if (type == 18) return new object[0];

            // Type 19 - Unknown19(int x)
            if (type == 19 && textBoxX_Param1.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text) };

            // Type 20 - N/A

            // Type 21 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
            if (type == 21 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" &&
                textBoxX_Param3.Text != "" && textBoxX_Param4.Text != "" && textBoxX_Param5.Text != "")
            {
                var param1 = Convert.ToInt32(textBoxX_Param1.Text);
                var param2 = Convert.ToInt32(textBoxX_Param2.Text);
                var param3 = Convert.ToInt32(textBoxX_Param3.Text);
                var param4 = Convert.ToInt32(textBoxX_Param4.Text);
                var param5 = Convert.ToInt32(textBoxX_Param5.Text);
                return new object[] {param1, param2, param3, param4, param5};
            }

            // Type 22 - Set_Value(int oldValue, int newValue)
            if (type == 22 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 23 - Add_Value(int value, int toAdd)
            if (type == 23 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 24 - Unknown24(int x, int y)
            if (type == 24 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text) };

            // Type 25 - Unknown25(int x, int y, int z)
            if (type == 25 && textBoxX_Param1.Text != "" && textBoxX_Param2.Text != "" && textBoxX_Param3.Text != "")
                return new object[] { Convert.ToInt32(textBoxX_Param1.Text), Convert.ToInt32(textBoxX_Param2.Text), Convert.ToInt32(textBoxX_Param3.Text) };

            // Type 26 - Unknown26()
            if (type == 26) return new object[0];

            // Type 27 - Unknown27()
            if (type == 27) return new object[0];

            // Type Error
            Cursor = Cursors.Default;
            MessageBox.Show(Resources.ErrParams);
            return null;
        }

        private static void FWWriteParameters(int type, object[] parameters, BinaryWriter bw)
        {
            switch (type)
            {
                // Type 0 - Attack(int unk)
                case 0:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
                case 1:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 2 - Broadcast_Message(int byteCount, byte[] message)
                case 2:
                    var value = (int)parameters[0];
                    bw.Write(value);
                    bw.Write((byte[])parameters[1]);
                    break;

                // Type 3 - Reset_Aggro()
                // no parameters...
                case 3:
                    break;

                // Type 4 - Exec_ActionSet(int actionset_id)
                case 4:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 5 - Disable_ActionSet(int actionset_id)
                case 5:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 6 - Enable_ActionSet(int actionset_id)
                case 6:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 7 - Create_Timer(int timerID, int delay, int cycles)
                case 7:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    break;

                // Type 8 - Delete_Timer(int timerID)
                case 8:
                    bw.Write((int)parameters[0]);
                    break;

                // Type 9 - Flee()
                // no parameters...
                case 9:

                // Type 10 - Be_Taunted()
                // no parameters...
                case 10:

                // Type 11 - Fade_Target()
                // no parameters...
                case 11:

                // Type 12 - N/A
                case 12:

                // Tpye 13 - Unknown13()
                // no parameters...
                case 13:
                    break;

                // Type 14 - NPC_Generator(int triggerID, int ctrlParam)
                case 14:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 15 - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                case 15:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    bw.Write((int)parameters[3]);
                    bw.Write((byte[])parameters[4]);
                    bw.Write((int)parameters[5]);
                    bw.Write((int)parameters[6]);
                    break;

                // Type 16 - Unknown16()
                // no parameters...
                case 16:
                    break;

                // Type 17 - Unknown17(int x, int y)
                case 17:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 18 - Disappear()
                case 18:
                    break;

                // Type 19 - Unknown19(int x)
                case 19:
                    bw.Write((int)parameters[0]);
                    break;


                // Type 20 - N/A
                case 20:
                    break;

                // Type 21 - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                case 21:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    bw.Write((int)parameters[3]);
                    bw.Write((int)parameters[4]);
                    break;

                // Type 22- Set_Value(int oldValue, int newValue)
                case 22:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 23- Add_Value(int value, int toAdd)
                case 23:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 24-  Unknown24(int x, int y)
                case 24:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    break;

                // Type 25 - Unknown25(int x, int y, int z)
                case 25:
                    bw.Write((int)parameters[0]);
                    bw.Write((int)parameters[1]);
                    bw.Write((int)parameters[2]);
                    break;

                // Type 26 - Unknown26()
                // no parameters...
                case 26:

                // Type 27 - Unknown27()
                // no parameters...
                case 27:
                    break;
            }
        }
        
        //**********************************************

        private void ButtonItemOpenClick(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog { Filter = Resources.AIPolicyFilter })
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK || !File.Exists(openFileDialog.FileName)) return;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    listBox_Controller.Items.Clear();
                    listBox_ActionSet.Items.Clear();
                    textBoxX_Condition.Clear();
                    listBox_Procedure.Items.Clear();
                    using (var fileStream = File.OpenRead(openFileDialog.FileName))
                    {
                        using (var binaryReader = new BinaryReader(fileStream))
                        {
                            AI = new AIPolicy();
                            AI.Signature = binaryReader.ReadInt32();
                            AI.ActionControllerCount = binaryReader.ReadInt32();
                            AI.ActionController = new ActionController[AI.ActionControllerCount];
                            for (var i = 0; i < AI.ActionController.Length; i++)
                            {
                                AI.ActionController[i] = new ActionController();
                                AI.ActionController[i].Signature = binaryReader.ReadInt32();
                                AI.ActionController[i].ID = binaryReader.ReadInt32();
                                AI.ActionController[i].ActionSetsCount = binaryReader.ReadInt32();
                                AI.ActionController[i].ActionSet = new ActionSet[AI.ActionController[i].ActionSetsCount];
                                var iD = AI.ActionController[i].ID;
                                listBox_Controller.Items.Add(iD.ToString(CultureInfo.InvariantCulture));

                                for (var j = 0; j < AI.ActionController[i].ActionSet.Length; j++)
                                {
                                    AI.ActionController[i].ActionSet[j] = new ActionSet();
                                    AI.ActionController[i].ActionSet[j].Version = binaryReader.ReadInt32();
                                    var version = AI.ActionController[i].ActionSet[j].Version;
                                    AI.ActionController[i].ActionSet[j].ID = binaryReader.ReadInt32();
                                    AI.ActionController[i].ActionSet[j].Flags = binaryReader.ReadBytes(3);
                                    AI.ActionController[i].ActionSet[j].ActionSetName = binaryReader.ReadBytes(128);

                                    // Jade Dynasty
                                    if (JDSelected)
                                    {
                                        AI.ActionController[i].ActionSet[j].Condition = LoadCondition(binaryReader);
                                        AI.ActionController[i].ActionSet[j].ProcedureCount = binaryReader.ReadInt32();
                                        AI.ActionController[i].ActionSet[j].Procedure = new Procedure[AI.ActionController[i].ActionSet[j].ProcedureCount];

                                        for (var k = 0; k < AI.ActionController[i].ActionSet[j].Procedure.Length; ++k)
                                        {
                                            AI.ActionController[i].ActionSet[j].Procedure[k] = new Procedure { Type = binaryReader.ReadInt32() };
                                            var procedure = AI.ActionController[i].ActionSet[j].Procedure[k];
                                            var mainWindow = this;
                                            var type = mainWindow.AI.ActionController[i].ActionSet[j].Procedure[k].Type;
                                            var br2 = binaryReader;
                                            var ver = version;
                                            var objArray = mainWindow.JDReadParameters(type, br2, ver);
                                            procedure.Parameter = objArray;
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Target = binaryReader.ReadInt32();
                                        }
                                    }
                                    // Perfect World
                                    else if (PWSelected)
                                    {
                                        AI.ActionController[i].ActionSet[j].Condition = LoadCondition(binaryReader);
                                        AI.ActionController[i].ActionSet[j].ProcedureCount = binaryReader.ReadInt32();
                                        AI.ActionController[i].ActionSet[j].Procedure = new Procedure[AI.ActionController[i].ActionSet[j].ProcedureCount];

                                        for (var k = 0; k < AI.ActionController[i].ActionSet[j].Procedure.Length; ++k)
                                        {
                                            AI.ActionController[i].ActionSet[j].Procedure[k] = new Procedure();
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Type = binaryReader.ReadInt32();
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Parameter = PWReadParameters(AI.ActionController[i].ActionSet[j].Procedure[k].Type, binaryReader);
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Target = binaryReader.ReadInt32();
                                            if (AI.ActionController[i].ActionSet[j].Procedure[k].Target == 6)
                                            {
                                                AI.ActionController[i].ActionSet[j].Procedure[k].TargetParams = PWReadTargetParameters(AI.ActionController[i].ActionSet[j].Procedure[k].Target, binaryReader);
                                            }
                                        }
                                    }
                                    // Forsaken World
                                    else if (FWSelected)
                                    {
                                        AI.ActionController[i].ActionSet[j].Condition = LoadCondition(binaryReader);
                                        AI.ActionController[i].ActionSet[j].ProcedureCount = binaryReader.ReadInt32();
                                        AI.ActionController[i].ActionSet[j].Procedure = new Procedure[AI.ActionController[i].ActionSet[j].ProcedureCount];

                                        for (var k = 0; k < AI.ActionController[i].ActionSet[j].Procedure.Length; k++)
                                        {
                                            AI.ActionController[i].ActionSet[j].Procedure[k] = new Procedure();
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Type = binaryReader.ReadInt32();
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Parameter =
                                                FWReadParameters(AI.ActionController[i].ActionSet[j].Procedure[k].Type, binaryReader);
                                            AI.ActionController[i].ActionSet[j].Procedure[k].Target = binaryReader.ReadInt32();
                                        }
                                    }
                                }
                            }
                            binaryReader.Dispose();
                        }
                        fileStream.Dispose();
                    }
                    Cursor = Cursors.Default;
                    openFileDialog.Dispose();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show(Resources.ErrFileLoad + ex.Message);
                }
            }
        }

        private void ButtonItemMenuOpenClick(object sender, EventArgs e)
        {
            ButtonItemOpenClick(sender, e);
        }

        private void ListBoxControllerSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearParams();
            if (AI == null || listBox_Controller.SelectedIndex <= -1) return;
            var scSelectedIndex = listBox_Controller.SelectedIndex;
            listBox_ActionSet.Items.Clear();
            var actionSet = AI.ActionController[scSelectedIndex].ActionSet;

            foreach (var t in actionSet)
            {
                var iD = t.ID;
                listBox_ActionSet.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " + t.Name);
                textBoxX_CtrlID.Text = AI.ActionController[scSelectedIndex].ID.ToString(CultureInfo.InvariantCulture);
            }

            textBoxX_ActionID.Clear();
            textBoxX_Flag1.Clear();
            textBoxX_Flag2.Clear();
            textBoxX_Flag3.Clear();
            textBoxX_ActionName.Clear();
            textBoxX_Condition.Clear();
            listBox_Procedure.Items.Clear();
        }

        private void ListBoxActionSetSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearParams();
            if (AI == null || listBox_Controller.SelectedIndex <= -1 || listBox_ActionSet.SelectedIndex <= -1) return;
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;

            // Jade Dynasty
            if (JDSelected) textBoxX_Condition.Text = JDConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
            // Perfect World
            if (PWSelected) textBoxX_Condition.Text = PWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
            // Forsaken World
            if (FWSelected) textBoxX_Condition.Text = FWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);

            listBox_Procedure.Items.Clear();
            for (var i = 0; i < AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure.Length; i++)
            {
                // Jade Dynasty
                if (JDSelected) listBox_Procedure.Items.Add("[" + i.ToString(CultureInfo.InvariantCulture) + "] " +
                    JDProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i],
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Version));

                // Perfect World
                if (PWSelected) listBox_Procedure.Items.Add("[" + i.ToString(CultureInfo.InvariantCulture) + "] " +
                    PWProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i]));

                // Forsaken World
                if (FWSelected) listBox_Procedure.Items.Add("[" + i.ToString(CultureInfo.InvariantCulture) + "] " +
                    FWProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i]));

                textBoxX_ActionID.Text = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ID.ToString(CultureInfo.InvariantCulture);
                textBoxX_Flag1.Text = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[0].ToString(CultureInfo.InvariantCulture);
                textBoxX_Flag2.Text = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[1].ToString(CultureInfo.InvariantCulture);
                textBoxX_Flag3.Text = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[2].ToString(CultureInfo.InvariantCulture);
                textBoxX_ActionName.Text = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Name.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void ListBoxProcedureSelectedIndexChanged(object sender, EventArgs e)
        {
            groupPanel_ProcParams.Text = Resources.ProcParams;
            ClearParams();

            if (AI == null || listBox_Controller.SelectedIndex <= -1 || listBox_ActionSet.SelectedIndex <= -1 ||
                listBox_Procedure.SelectedIndex <= -1) return;
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            var pSelectedIndex = listBox_Procedure.SelectedIndex;

            // Type 0 - Attack(int unk)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 0)
            {
                groupPanel_ProcParams.Text = Resources.Atk;
                labelX_Param1.Text = Resources.AtkParam1;
                var param1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = param1.ToString(CultureInfo.InvariantCulture);
            }

            // Type 1 - Cast_Skill(int skill_id, int skill_lvl)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 1)
            {
                groupPanel_ProcParams.Text = Resources.CastSkill;
                labelX_Param1.Text = Resources.Skill_ID;
                labelX_Param2.Text = Resources.SkillLvl;
                var skillID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = skillID.ToString(CultureInfo.InvariantCulture);
                var skillLvl = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = skillLvl.ToString(CultureInfo.InvariantCulture);
            }

            // Type 2 - Broadcast_Message(int byteCount, byte[] message)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 2)
            {
                groupPanel_ProcParams.Text = Resources.Broadcast;
                labelX_Param1.Text = Resources.ByteCount;
                labelX_Param2.Text = Resources.Msg;
                var byteCount = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = byteCount.ToString(CultureInfo.InvariantCulture);
                textBoxX_Param2.Text = Encoding.Unicode.GetString((byte[])AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1]);
            }

            // Type 3 - Reset_Aggro()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 3)
                groupPanel_ProcParams.Text = Resources.FadeAggro;

            // Type 4 - Exec_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 4)
            {
                groupPanel_ProcParams.Text = Resources.Exec_AS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 5 - Disable_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 5)
            {
                groupPanel_ProcParams.Text = Resources.DisableAS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 6 - Enable_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 6)
            {
                groupPanel_ProcParams.Text = Resources.EnableAS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 7 - Create_Timer(int timerID, int delay, int cycles)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 7)
            {
                groupPanel_ProcParams.Text = Resources.CreateTimer;
                labelX_Param1.Text = Resources.TimerID;
                labelX_Param2.Text = Resources.Delay;
                labelX_Param3.Text = Resources.Cycles;
                var timerID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = timerID.ToString(CultureInfo.InvariantCulture);
                var delay = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = delay.ToString(CultureInfo.InvariantCulture);
                var cycles = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                textBoxX_Param3.Text = cycles.ToString(CultureInfo.InvariantCulture);
            }

            // Type 8 - Delete_Timer(int timerID)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 8)
            {
                groupPanel_ProcParams.Text = Resources.DelTimer;
                labelX_Param1.Text = Resources.TimerID;
                var num11 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = num11.ToString(CultureInfo.InvariantCulture);
            }

            // Type 9 - Flee()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 9)
            {
                groupPanel_ProcParams.Text = Resources.Flee;
            }

            // Type 10 - Be_Taunted()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 10)
            {
                groupPanel_ProcParams.Text = Resources.BeTaunted;
            }

            // Type 11
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 11)
            {
                // Jade Dynasty - Unknown11()
                if (JDSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.ELEVEN;
                // Perfect World/Forsaken - Fade_Target()
                if (PWSelected || FWSelected) groupPanel_ProcParams.Text = Resources.FadeTarget;
            }

            // Type 12
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 12)
            {
                groupPanel_ProcParams.Text = Resources.Fade_Aggro;
            }

            // Type 13
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 13)
            {
                // Jade Dynasty - Unknown13()
                if (JDSelected || FWSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.THIRTEEN;
                // Perfect World - Break()
                if (PWSelected) groupPanel_ProcParams.Text = Resources.Break;
            }

            // Type 14
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 14)
            {
                // Jade Dynasty - Trigger(int triggerID, int ctrlParam)
                if (JDSelected) groupPanel_ProcParams.Text = Resources.Trigger;
                // Perfect World/Forsaken World - NPC_Generator(int triggerID, int ctrlParam)
                if (PWSelected || FWSelected) groupPanel_ProcParams.Text = Resources.NPCGenerator;

                labelX_Param1.Text = Resources.TriggerID;
                labelX_Param2.Text = Resources.CtrlParam;
                var triggerID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = triggerID.ToString(CultureInfo.InvariantCulture);
                var ctrlParam = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = ctrlParam.ToString(CultureInfo.InvariantCulture);
            }

            // Type 15
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 15)
            {
                // Jade Dynasty/Forsaken - Summon_Mob(int elementsID, int timeInterval, int calls, int Survival, string mobName, int refreshRange, int unknown)
                if (JDSelected || FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.SummonMob;
                    labelX_Param1.Text = Resources.ElementsID;
                    labelX_Param2.Text = Resources.TimeInterval;
                    labelX_Param3.Text = Resources.Calls;
                    labelX_Param5.Text = Resources.Survival;
                    labelX_Param5.Text = Resources.MobName;
                    labelX_Param6.Text = Resources.RRange;
                    labelX_Param7.Text = Resources.Unk;
                    var elementsID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = elementsID.ToString(CultureInfo.InvariantCulture);
                    var timeInt = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = timeInt.ToString(CultureInfo.InvariantCulture);
                    var calls = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = calls.ToString(CultureInfo.InvariantCulture);
                    var survival = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[3];
                    textBoxX_Param4.Text = survival.ToString(CultureInfo.InvariantCulture);
                    textBoxX_Param5.Text = Encoding.Unicode.GetString((byte[])AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[4]);
                    var refreshRange = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[5];
                    textBoxX_Param6.Text = refreshRange.ToString(CultureInfo.InvariantCulture);
                    var unknown = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[6];
                    textBoxX_Param7.Text = unknown.ToString(CultureInfo.InvariantCulture);
                }
                // Perfect World - Initialize_Public_Counter(int x, int y, int z)
                if (PWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.InitPubCount;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    var x = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = x.ToString(CultureInfo.InvariantCulture);
                    var y = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = y.ToString(CultureInfo.InvariantCulture);
                    var z = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = z.ToString(CultureInfo.InvariantCulture);
                }
            }

            // Type 16
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 16)
            {
                // Jade Dynasty/Forsaken World - Unknown16(int unk)
                if (JDSelected || FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.SIXTEEN;
                    labelX_Param1.Text = Resources.Unk;
                    var unk1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = unk1.ToString(CultureInfo.InvariantCulture);
                }
                // Perfect World - Increment_Public_Counter(int x, int y)
                if (PWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.IncPubCount;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    var x = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = x.ToString(CultureInfo.InvariantCulture);
                    var y = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = y.ToString(CultureInfo.InvariantCulture);
                }
            }

            // Type 17
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 17)
            {
                // Jade Dynasty - Set_Path(int pathID, int v11) for version 11 else Set_Path(int pathID)
                if (JDSelected)
                {
                    groupPanel_ProcParams.Text = Resources.SetPath;
                    labelX_Param1.Text = Resources.PathID;
                    var pathID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = pathID.ToString(CultureInfo.InvariantCulture);
                    if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Version == 11)
                    {
                        labelX_Param2.Text = Resources.v11Path;
                        var v11Path = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                        textBoxX_Param2.Text = v11Path.ToString(CultureInfo.InvariantCulture);
                    }
                }
                
                // Perfect World - Player_Aimed_NPC_Spawn(int elementsID, int timeInterval, int calls, int Survival,
                //                                        string mobName, int refreshRange, int unknown)
                if (PWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.NPCSpawn;
                    labelX_Param1.Text = Resources.ElementsID;
                    labelX_Param2.Text = Resources.TimeInterval;
                    labelX_Param3.Text = Resources.Calls;
                    labelX_Param5.Text = Resources.Survival;
                    labelX_Param5.Text = Resources.MobName;
                    labelX_Param6.Text = Resources.RRange;
                    labelX_Param7.Text = Resources.Unk;
                    var elementsID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = elementsID.ToString(CultureInfo.InvariantCulture);
                    var timeInt = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = timeInt.ToString(CultureInfo.InvariantCulture);
                    var calls = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = calls.ToString(CultureInfo.InvariantCulture);
                    var survival = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[3];
                    textBoxX_Param4.Text = survival.ToString(CultureInfo.InvariantCulture);
                    textBoxX_Param5.Text = Encoding.Unicode.GetString((byte[])AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[4]);
                    var refreshRange = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[5];
                    textBoxX_Param6.Text = refreshRange.ToString(CultureInfo.InvariantCulture);
                    var unknown = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[6];
                    textBoxX_Param7.Text = unknown.ToString(CultureInfo.InvariantCulture);
                }
                // Forsaken World - Unknown17(int x, int y)
                if (FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.SEVENTEEN;
                    labelX_Param1.Text = Resources.Unk;
                    var x = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = x.ToString(CultureInfo.InvariantCulture);
                    var y = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = y.ToString(CultureInfo.InvariantCulture);
                }
            }

            // Type 18
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 18)
            {
                // Jade Dynasty - Disappear()
                if (JDSelected) groupPanel_ProcParams.Text = Resources.Disappear;
                // Perfect World - Change_Path(int w, int x, int y, int z)
                if (PWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.ChangePath;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    var x = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = x.ToString(CultureInfo.InvariantCulture);
                    var y = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = y.ToString(CultureInfo.InvariantCulture);
                    var z = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = z.ToString(CultureInfo.InvariantCulture);
                }
                // Forsaken World - Disappear()
                if (JDSelected) groupPanel_ProcParams.Text = Resources.Disappear;
            }

            // Type 19
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 19)
            {
                // Jade Dynasty - N/A
                if (JDSelected) groupPanel_ProcParams.Text = Resources.NA;
                // Perfect World - Play_Action(sting w, int x, int y, int z)
                if (PWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.PlayAction;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    var x = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = x.ToString(CultureInfo.InvariantCulture);
                    var y = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = y.ToString(CultureInfo.InvariantCulture);
                    var z = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = z.ToString(CultureInfo.InvariantCulture);
                }
                // Forsaken World - Unknown19(int x)
                groupPanel_ProcParams.Text = Resources.Unk + Resources.NINETEEN;
                labelX_Param1.Text = Resources.AtkParam1;
                var param1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = param1.ToString(CultureInfo.InvariantCulture);
            }

            // Type 20 - N/A
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 20)
            {
                groupPanel_ProcParams.Text = Resources.NA;
            }

            // Type 21 - Respawn()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 21)
            {
                // Forsaken World - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                if(FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.SetMobAttr;
                    labelX_Param1.Text = Resources.MobID;
                    labelX_Param2.Text = Resources.Cycles;
                    labelX_Param3.Text = Resources.Unk;
                    labelX_Param5.Text = Resources.Name;
                    labelX_Param5.Text = Resources.Unk;
                    var mobID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = mobID.ToString(CultureInfo.InvariantCulture);
                    var cycles = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = cycles.ToString(CultureInfo.InvariantCulture);
                    var unk1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = unk1.ToString(CultureInfo.InvariantCulture);
                    var name = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[3];
                    textBoxX_Param4.Text = name.ToString(CultureInfo.InvariantCulture);
                    var unk2 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[4];
                    textBoxX_Param5.Text = unk2.ToString(CultureInfo.InvariantCulture);
                }
                else groupPanel_ProcParams.Text = Resources.Respawn;
            }

            // Type 22 - Set_Value(int oldValue, int newValue)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 22)
            {
                groupPanel_ProcParams.Text = Resources.SetValue;
                labelX_Param1.Text = Resources.Value;
                labelX_Param2.Text = Resources._Equals;
                var oldValue = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = oldValue.ToString(CultureInfo.InvariantCulture);
                var newValue = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = newValue.ToString(CultureInfo.InvariantCulture);
            }

            // Type 23 - Add_Value(int value, int toAdd)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 23)
            {
                groupPanel_ProcParams.Text = Resources.AddValue;
                labelX_Param1.Text = Resources.Value;
                labelX_Param2.Text = Resources._Plus;
                var value = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = value.ToString(CultureInfo.InvariantCulture);
                var toAdd = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = toAdd.ToString(CultureInfo.InvariantCulture);
            }

            // Type 24 - N/A
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 24)
            {
                if (FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.TWOFOUR;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources._Plus;
                    var value = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = value.ToString(CultureInfo.InvariantCulture);
                    var toAdd = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = toAdd.ToString(CultureInfo.InvariantCulture);
                }
                else groupPanel_ProcParams.Text = Resources.NA;
            }

            // Type 25
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 25)
            {
                // Jade Dynasty - Set_Mob_Attribute(int mobID, int cycles, int unk1, int name, int unk2)
                if (JDSelected)
                {
                    groupPanel_ProcParams.Text = Resources.SetMobAttr;
                    labelX_Param1.Text = Resources.MobID;
                    labelX_Param2.Text = Resources.Cycles;
                    labelX_Param3.Text = Resources.Unk;
                    labelX_Param5.Text = Resources.Name;
                    labelX_Param5.Text = Resources.Unk;
                    var mobID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = mobID.ToString(CultureInfo.InvariantCulture);
                    var cycles = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = cycles.ToString(CultureInfo.InvariantCulture);
                    var unk1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = unk1.ToString(CultureInfo.InvariantCulture);
                    var name = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[3];
                    textBoxX_Param4.Text = name.ToString(CultureInfo.InvariantCulture);
                    var unk2 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[4];
                    textBoxX_Param5.Text = unk2.ToString(CultureInfo.InvariantCulture);
                }
                // Forsaken World - Unknown25(int x, int y, int z)
                if (FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.TWOFIVE;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    var mobID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = mobID.ToString(CultureInfo.InvariantCulture);
                    var cycles = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = cycles.ToString(CultureInfo.InvariantCulture);
                    var unk1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = unk1.ToString(CultureInfo.InvariantCulture);
                }
            }

            // Type 26
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 26)
            {
                // Jade Dynasty - Drop_WarSoul(int itemID, int calls, int cycles)
                if (JDSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Warsoul;
                    labelX_Param1.Text = Resources.ItemID;
                    labelX_Param2.Text = Resources.Calls;
                    labelX_Param3.Text = Resources.Cycles;
                    var timerID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = timerID.ToString(CultureInfo.InvariantCulture);
                    var delay = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                    textBoxX_Param2.Text = delay.ToString(CultureInfo.InvariantCulture);
                    var cycles = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[2];
                    textBoxX_Param3.Text = cycles.ToString(CultureInfo.InvariantCulture);
                }
                // Forsaken World - Unknown26()
                if (FWSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.TWOSIX;
            }

            // Type 27 - Unknown27()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 27)
            {
                groupPanel_ProcParams.Text = Resources.Unk + Resources.TWOSEVEN;
            }

            // Type Target
            var target = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target;
            //textBoxX_ParamTarget.Text = JDProcedureTarget(target);
            // Jade Dynasty
            if (JDSelected) textBoxX_ParamTarget.Text = JDProcedureTarget(target);
            // Perfect World
            if (PWSelected && target == 6)
                textBoxX_ParamTarget.Text =
                    PWProcedureTarget(target, AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].TargetParams);
            else textBoxX_ParamTarget.Text = PWProcedureTarget(target, null);
        }

        private void ButtonXAddCtrlClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.AddCtrl);
                return;
            }
            if (AI != null && textBoxX_CtrlID.Text != "")
            {
                var acCount = AI.ActionControllerCount;
                if (!Program.IsNumber(textBoxX_CtrlID.Text))
                {
                    MessageBox.Show(Resources.NoNumCtrl);
                    return;
                }
                var ctrlID = Convert.ToInt32(textBoxX_CtrlID.Text);
                for (var i = 0; i < acCount; i++)
                {
                    if (ctrlID != AI.ActionController[i].ID || ctrlID <= 0) continue;
                    MessageBox.Show(Resources.CtrlExists);
                    return;
                }
                acCount++;
                var aIPolicy = new AIPolicy();
                aIPolicy.Signature = 0;
                aIPolicy.ActionControllerCount = acCount;
                aIPolicy.ActionController = new ActionController[acCount];

                for (var j = 0; j < aIPolicy.ActionController.Length - 1; j++)
                {
                    aIPolicy.ActionController[j] = AI.ActionController[j];
                    aIPolicy.ActionController[j].Signature = AI.ActionController[j].Signature;
                    aIPolicy.ActionController[j].ID = AI.ActionController[j].ID;
                    aIPolicy.ActionController[j].ActionSetsCount = AI.ActionController[j].ActionSetsCount;
                    aIPolicy.ActionController[j].ActionSet = AI.ActionController[j].ActionSet;
                }
                AI = aIPolicy;
                AI.ActionController[acCount - 1] = new ActionController();
                AI.ActionController[acCount - 1].Signature = 0;
                AI.ActionController[acCount - 1].ActionSetsCount = 0;
                AI.ActionController[acCount - 1].ActionSet = new ActionSet[aIPolicy.ActionController[acCount - 1].ActionSetsCount];
                AI.ActionController[acCount - 1].ID = ctrlID;
                listBox_Controller.Items.Clear();

                for (var k = 0; k < AI.ActionControllerCount; k++)
                {
                    var iD = AI.ActionController[k].ID;
                    listBox_Controller.Items.Add(iD.ToString(CultureInfo.InvariantCulture));
                }
                listBox_ActionSet.Items.Clear();
                textBoxX_Condition.Clear();
                listBox_Procedure.Items.Clear();
            }
            MessageBox.Show(Resources.CtrlIDwith + textBoxX_CtrlID.Text + Resources.beenAdded);
        }

        private void ButtonXDelCtrlClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.DelCtrl);
                return;
            }

            if (SafeMode && MessageBox.Show(Resources.sureDelete + Resources.ACtrl + textBoxX_CtrlID.Text +
                        Resources.QMark, Resources.DelACtrl, MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (AI != null && textBoxX_CtrlID.Text != "")
            {
                var actionControllerCount = AI.ActionControllerCount;
                var ctrlID = -1;
                if (!Program.IsNumber(textBoxX_CtrlID.Text))
                {
                    MessageBox.Show(Resources.NoNumCtrl);
                    return;
                }
                var delCtrlID = Convert.ToInt32(textBoxX_CtrlID.Text);
                
                for (var i = 0; i < actionControllerCount; i++)
                    if (delCtrlID == AI.ActionController[i].ID) ctrlID = i;
                
                if (ctrlID < 0)
                {
                    MessageBox.Show(Resources.CtrlNoExist);
                    return;
                }
                var aIPolicy = new AIPolicy();
                aIPolicy.Signature = 0;
                aIPolicy.ActionControllerCount = actionControllerCount - 1;
                var aIPolicy2 = aIPolicy;
                aIPolicy2.ActionController = new ActionController[aIPolicy2.ActionControllerCount];

                for (var j = 0; j < aIPolicy.ActionController.Length; j++)
                {
                    if (j < ctrlID) aIPolicy.ActionController[j] = AI.ActionController[j];
                    if (j >= ctrlID) aIPolicy.ActionController[j] = AI.ActionController[j + 1];

                }
                AI = aIPolicy;
                listBox_Controller.Items.Clear();

                for (var k = 0; k < AI.ActionControllerCount; k++)
                {
                    var iD = AI.ActionController[k].ID;
                    listBox_Controller.Items.Add(iD.ToString(CultureInfo.InvariantCulture));
                }
                listBox_ActionSet.Items.Clear();
                textBoxX_Condition.Clear();
                listBox_Procedure.Items.Clear();
            }
            MessageBox.Show(Resources.CtrlIDwith + textBoxX_CtrlID.Text + Resources.beenDel);
        }

        private void ButtonXAddActionClick(object sender, EventArgs e)
        {
            int actionID = 0;
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.AddAS);
                return;
            }
            if (listBox_Controller.SelectedIndex == -1) return;
            if (textBoxX_ActionName.Text == "")
            {
                MessageBox.Show(Resources.EnterAS);
                return;
            }
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            var actionSetCount = AI.ActionController[cSelectedIndex].ActionSetsCount;
            if (Program.IsNumber(textBoxX_ActionID.Text))
            {
                actionID = Convert.ToInt32(textBoxX_ActionID.Text);
                for (var i = 0; i < actionSetCount; i++)
                {
                    if (actionID != AI.ActionController[cSelectedIndex].ActionSet[i].ID) continue;
                    MessageBox.Show(Resources.ActionID + actionID + Resources.Exists);
                    return;
                }
            }
            if (asSelectedIndex == -1) asSelectedIndex = actionSetCount;

            var actionSet = new ActionSet[actionSetCount + 1];
            for (var j = 0; j <= actionSetCount; j++)
            {
                if (j < asSelectedIndex) actionSet[j] = AI.ActionController[cSelectedIndex].ActionSet[j];
                if (j > asSelectedIndex) actionSet[j] = AI.ActionController[cSelectedIndex].ActionSet[j - 1];
            }
            actionSet[asSelectedIndex] = new ActionSet();
            actionSet[asSelectedIndex].Version = 11;
            if (textBoxX_ActionID.Text == "")
            {
                var asCount = actionSetCount;
                for (var k = 0; k < actionSetCount; k++)
                    if (asCount < AI.ActionController[cSelectedIndex].ActionSet[k].ID)
                        asCount = AI.ActionController[cSelectedIndex].ActionSet[k].ID;

                for (var x = 0; x <= asCount; x++)
                {
                    for (var y = 0; y < actionSetCount; y++)
                        if (x == AI.ActionController[cSelectedIndex].ActionSet[y].ID)
                            actionSet[asSelectedIndex].ID = -1;

                    if (actionSet[asSelectedIndex].ID != -1)
                    {
                        actionSet[asSelectedIndex].ID = x;
                        break;
                    }
                    actionSet[asSelectedIndex].ID = x;
                }
            }
            else
                actionSet[asSelectedIndex].ID = actionID;

            var tmpFlags = new byte[3];
            tmpFlags[0] = 1;
            var flags = tmpFlags;
            actionSet[asSelectedIndex].Flags = flags;
            actionSet[asSelectedIndex].Name = textBoxX_ActionName.Text;
            actionSet[asSelectedIndex].Condition = new Condition();
            actionSet[asSelectedIndex].Condition.OperID = 3;
            actionSet[asSelectedIndex].Condition.ArgBytes = 4;

            var value = new byte[] { 0, 0, 128, 63 };
            actionSet[asSelectedIndex].Condition.Value = value;
            actionSet[asSelectedIndex].Condition.SubNodeL = 0;
            actionSet[asSelectedIndex].Condition.SubNodeR = 0;
            actionSet[asSelectedIndex].Condition.ConditionType = 3;
            actionSet[asSelectedIndex].ProcedureCount = 1;

            actionSet[asSelectedIndex].Procedure = new Procedure[1];
            actionSet[asSelectedIndex].Procedure[0] = new Procedure();
            actionSet[asSelectedIndex].Procedure[0].Type = 2;
            var unicode = Encoding.Unicode;
            var rageMsg = unicode.GetBytes("RaGEZONE Forums - http://Forum.RaGEZONE.com");
            var msgSize = rageMsg.Length + 2;
            var msg = new byte[msgSize];
            Array.Copy(rageMsg, msg, rageMsg.Length);
            msg[rageMsg.Length] = 0;
            msg[rageMsg.Length + 1] = 0;
            var parameter = new object[] { msgSize, msg };
            actionSet[asSelectedIndex].Procedure[0].Parameter = parameter;
            actionSet[asSelectedIndex].Procedure[0].Target = 0;
            AI.ActionController[cSelectedIndex].ActionSetsCount = AI.ActionController[cSelectedIndex].ActionSetsCount + 1;
            AI.ActionController[cSelectedIndex].ActionSet = actionSet;
            listBox_ActionSet.Items.Clear();
            foreach (var t in AI.ActionController[cSelectedIndex].ActionSet)
            {
                var iD = t.ID;
                listBox_ActionSet.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " + t.Name);
            }
            textBoxX_Condition.Clear();
            listBox_Procedure.Items.Clear();
        }

        private void ButtonXDelActionClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.delAS);
                return;
            }
            if (listBox_Controller.SelectedIndex == -1) return;

            if (SafeMode && MessageBox.Show(Resources.sureDelete + Resources.ASNamed + textBoxX_ActionName.Text +
                        Resources.QMark, Resources.DelAction, MessageBoxButtons.YesNo) == DialogResult.No) return;

            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            var actionSetCount = AI.ActionController[cSelectedIndex].ActionSetsCount;

            if (asSelectedIndex == -1)
            {
                MessageBox.Show(Resources.noAS);
                return;
            }
            var actionSet = new ActionSet[actionSetCount - 1];
            for (var i = 0; i < actionSetCount - 1; i++)
            {
                if (i < asSelectedIndex) actionSet[i] = AI.ActionController[cSelectedIndex].ActionSet[i];
                if (i >= asSelectedIndex) actionSet[i] = AI.ActionController[cSelectedIndex].ActionSet[i + 1];
            }
            AI.ActionController[cSelectedIndex].ActionSetsCount = AI.ActionController[cSelectedIndex].ActionSetsCount - 1;
            AI.ActionController[cSelectedIndex].ActionSet = actionSet;
            listBox_ActionSet.Items.Clear();

            foreach (var t in AI.ActionController[cSelectedIndex].ActionSet)
            {
                var iD = t.ID;
                listBox_ActionSet.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " + t.Name);
            }
            textBoxX_Condition.Clear();
            listBox_Procedure.Items.Clear();
        }

        private void ButtonXEditActionClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.EditAS);
                return;
            }
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            if (listBox_Controller.SelectedIndex != -1 && listBox_ActionSet.SelectedIndex != -1)
            {
                if (textBoxX_ActionName.Text == "")
                {
                    MessageBox.Show(Resources.ASName);
                    return;
                }
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[0] = Convert.ToByte(textBoxX_Flag1.Text);
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[1] = Convert.ToByte(textBoxX_Flag2.Text);
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Flags[2] = Convert.ToByte(textBoxX_Flag3.Text);
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Name = textBoxX_ActionName.Text;
            }
            listBox_ActionSet.Items.Clear();
            foreach (var t in AI.ActionController[cSelectedIndex].ActionSet)
            {
                var iD = t.ID;
                listBox_ActionSet.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " + t.Name);
            }
            textBoxX_Condition.Clear();
            listBox_Procedure.Items.Clear();
        }

        private void ButtonXAddProcClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.addProcedure);
                return;
            }
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            object[] pArray = null;
            if (comboBoxEx_Proc.SelectedIndex != -1 && asSelectedIndex != -1)
            {
                // Jade Dynasty
                if (JDSelected) pArray = JDGetParameters(comboBoxEx_Proc.SelectedIndex, AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Version);
                // Perfect World
                if (PWSelected) pArray = PWGetParameters(comboBoxEx_Proc.SelectedIndex);
                // Forsaken World
                if (FWSelected) pArray = FWGetParameters(comboBoxEx_Proc.SelectedIndex);

                if (pArray == null) return;
                var pSelectedIndex = listBox_Procedure.SelectedIndex;
                var procedure = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure;
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount =
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount + 1;

                var pCount = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount;
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure = new Procedure[pCount];

                pCount--;
                if (pSelectedIndex == -1) pSelectedIndex = pCount;

                for (var i = 0; i <= pCount; i++)
                {
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i] = new Procedure();
                    if (i < pSelectedIndex)
                    {
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Type = procedure[i].Type;
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Parameter = procedure[i].Parameter;
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Target = procedure[i].Target;
                    }

                    if (i <= pSelectedIndex) continue;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Type = procedure[i - 1].Type;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Parameter = procedure[i - 1].Parameter;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Target = procedure[i - 1].Target;
                }
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type = comboBoxEx_Proc.SelectedIndex;
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter = pArray;
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target = Convert.ToInt32(textBoxX_ParamTarget.Text);
                listBox_Procedure.Items.Clear();

                for (var j = 0; j < AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure.Length; j++)
                {
                    var iD = j;
                    listBox_Procedure.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " +
                        JDProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[j],
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Version));
                }
            }
            comboBoxEx_Proc.SelectedIndex = -1;
        }

        private void ButtonXDelProcClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.delProc);
                return;
            }

            if (SafeMode && MessageBox.Show(Resources.sureDelete + Resources.tProc +
                        Resources.QMark, Resources.Del_Proc, MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (listBox_Procedure.SelectedIndex != -1)
            {
                var cSelectedIndex = listBox_Controller.SelectedIndex;
                var asSelectedIndex = listBox_ActionSet.SelectedIndex;
                var pSelectedIndex = listBox_Procedure.SelectedIndex;

                if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure.Length <= 1)
                {
                    MessageBox.Show(Resources.RetainProc);
                    return;
                }
                var procedures = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure;
                var pCount = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount - 1;
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure = new Procedure[pCount];

                for (var i = 0; i < pCount; i++)
                {
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i] = new Procedure();
                    if (i < pSelectedIndex)
                    {
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Type = procedures[i].Type;
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Parameter = procedures[i].Parameter;
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Target = procedures[i].Target;
                    }
                    if (i < pSelectedIndex) continue;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Type = procedures[i + 1].Type;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Parameter = procedures[i + 1].Parameter;
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[i].Target = procedures[i + 1].Target;
                }
                AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount =
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].ProcedureCount - 1;
                listBox_Procedure.Items.Clear();

                for (var j = 0; j < AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure.Length; j++)
                {
                    var iD = j;
                    listBox_Procedure.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " +
                        JDProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[j],
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Version));
                }
            }
            comboBoxEx_Proc.SelectedIndex = -1;
        }

        private void ButtonXEditProcClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.editProc);
                return;
            }
            if (listBox_Procedure.SelectedIndex == -1) return;

            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSselectedIndex = listBox_ActionSet.SelectedIndex;
            var pSelectedIndex = listBox_Procedure.SelectedIndex;

            // Jade dynasty
            if (JDSelected) AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Parameter =
                JDGetParameters(AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Type,
                AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Version);
            // Perfect World
            if (PWSelected) AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Parameter =
                PWGetParameters(AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Type);
            // Forsaken World
            if (FWSelected) AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Parameter =
                FWGetParameters(AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[pSelectedIndex].Type);

            listBox_Procedure.Items.Clear();

            for (var i = 0; i < AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure.Length; i++)
            {
                var num = i;
                
                // Jade Dynasty
                if (JDSelected) listBox_Procedure.Items.Add("[" + num.ToString(CultureInfo.InvariantCulture) + "] " +
                    JDProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[i],
                    AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Version));
                // Perfect World
                if (PWSelected) listBox_Procedure.Items.Add("[" + num.ToString(CultureInfo.InvariantCulture) + "] " +
                    PWProcedureExpression(AI.ActionController[cSelectedIndex].ActionSet[asSselectedIndex].Procedure[i]));
            }
        }

        private void ButtonXCondSaveClick(object sender, EventArgs e)
        {
            if (AI == null)
            {
                MessageBox.Show(Resources.openAIPolicy + Resources.editCondEx);
                return;
            }
            if (listBox_ActionSet.SelectedIndex < 0) return;
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            //var pSelectedIndex = this.listBox_Procedure.SelectedIndex;
            var text = textBoxX_Condition.Text;

            // Jade Dynasty
            if (JDSelected || PWSelected || FWSelected)
            {
                text = text.Replace(" ", "");
                text = text.Replace("定时器到达", "a");
                text = text.Replace("血量小于", "b");
                text = text.Replace("战斗开始", "c");
                text = text.Replace("随机事件", "d");
                text = text.Replace("目标已死", "e");
                text = text.Replace("||", "f");
                text = text.Replace("&&", "g");
                text = text.Replace("本身被杀", "h");
                text = text.Replace("路径到达终点", "i");
                text = text.Replace("人数超过", "j");
                text = text.Replace("距离超过", "k");
                text = text.Replace("未知条件12", "l");
                text = text.Replace("未知条件13", "m");
                text = text.Replace("未知条件14", "n");
                text = text.Replace("未知条件15", "o");
                text = text.Replace("变量值", "q");
                text = text.Replace("变量", "p");
                text = text.Replace("排行榜", "r");
                text = text.Replace("怪已刷出", "s");
                text = text.Replace("被技能击中", "t");
                text = text.Replace("【", "[");
                text = text.Replace("】", "]");
                text = text.Replace("！", "!");
                text = text.Replace("１", "1");
                text = text.Replace("２", "2");
                text = text.Replace("３", "3");
                text = text.Replace("４", "4");
                text = text.Replace("５", "5");
                text = text.Replace("６", "6");
                text = text.Replace("７", "7");
                text = text.Replace("８", "8");
                text = text.Replace("９", "9");
                text = text.Replace("０", "0");
                text = text.Replace("。", ".");
                text = text.Replace("（", "(");
                text = text.Replace("）", ")");
                text = text.Replace("[", "");
                text = text.Replace("]", "");

                if (!Program.IsMatch(text))
                    MessageBox.Show(Resources.NoMatchCond);
                else
                {
                    for (var i = 0; i < text.Length; i++)
                    {
                        var expr = text.Substring(i, 1);
                        if (expr == "(" || expr == ")" || expr == "." || Program.IsNumber(expr) || Program.IDOper(expr) >= 0)
                            continue;
                        MessageBox.Show(Resources.NoResolveCond + expr);
                        return;
                    }
                    //if (JDSelected)
                    //{
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition = JDGetCondition(text);
                        AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition =
                            JDFixCondition(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                    //}
                    
                    textBoxX_Condition.Clear();

                    // Jade Dynasty
                    if (JDSelected) textBoxX_Condition.Text = JDConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                    // Perfect World
                    if (PWSelected) textBoxX_Condition.Text = PWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                    // Forsaken World
                    if (FWSelected) textBoxX_Condition.Text = FWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                }
            }
            else MessageBox.Show(Resources.NYA);
        }
        
        private void ComboBoxExProcSelectedIndexChanged(object sender, EventArgs e)
        {
            ClearParams();
            
            if (AI == null || listBox_Controller.SelectedIndex <= -1 ||
                listBox_ActionSet.SelectedIndex <= -1) return;

            // Jade Dynasty
            if (JDSelected) JDProcList();
            // Perfect World
            if (PWSelected) PWProcList();
        }

        private void ButtonItemSaveClick(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog { Filter = Resources.AIPolicyFilter })
            {
                if (AI == null || saveFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.FileName == "") return;
                Cursor = Cursors.WaitCursor;
                
                using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    using (var binaryWriter = new BinaryWriter(fileStream))
                    {
                        binaryWriter.Write(AI.Signature);
                        binaryWriter.Write(AI.ActionControllerCount);
                        foreach (var actionController in AI.ActionController)
                        {
                            binaryWriter.Write(actionController.Signature);
                            binaryWriter.Write(actionController.ID);
                            binaryWriter.Write(actionController.ActionSetsCount);
                            foreach (var actionSet in actionController.ActionSet)
                            {
                                var version = actionSet.Version;
                                binaryWriter.Write(actionSet.Version);
                                binaryWriter.Write(actionSet.ID);
                                binaryWriter.Write(actionSet.Flags);
                                binaryWriter.Write(actionSet.ActionSetName);

                                // Jade Dynasty
                                if (JDSelected) JDSaveCondition(actionSet.Condition, binaryWriter);
                                // Perfect World
                                if (PWSelected) PWSaveCondition(actionSet.Condition, binaryWriter);
                                // Forsaken World
                                if (FWSelected) FWSaveCondition(actionSet.Condition, binaryWriter);

                                binaryWriter.Write(actionSet.ProcedureCount);
                                foreach (var procedure in actionSet.Procedure)
                                {
                                    binaryWriter.Write(procedure.Type);

                                    // Jade Dynasty
                                    if (JDSelected)
                                    {
                                        JDWriteParameters(procedure.Type, procedure.Parameter, binaryWriter, version);
                                        binaryWriter.Write(procedure.Target);
                                    }
                                    // Perfect World
                                    if (PWSelected)
                                    {
                                        PWWriteParameters(procedure.Type, procedure.Parameter, binaryWriter);
                                        binaryWriter.Write(procedure.Target);
                                        if (procedure.Target == 6) binaryWriter.Write((int) procedure.TargetParams[0]);
                                    }
                                    // Forsaken World
                                    if (!FWSelected) continue;
                                    FWWriteParameters(procedure.Type, procedure.Parameter, binaryWriter);
                                    binaryWriter.Write(procedure.Target);
                                }
                            }
                        }
                        binaryWriter.Dispose();
                    }
                    fileStream.Dispose();
                }
                saveFileDialog.Dispose();
            }
            Cursor = Cursors.Default;
        }

        private void SwitchButtonItemSafeModeValueChanged(object sender, EventArgs e)
        {
            if (switchButtonItem_SafeMode.Value) SafeMode = true;
            if (switchButtonItem_SafeMode.Value == false) SafeMode = false;
        }

        private void ButtonItemJDClick(object sender, EventArgs e)
        {
            if (switchButtonItem_ModeLock.Value)
            {
                MessageBox.Show(Resources.NoSwitchMode);
                return;
            }
            JDSelected = true;
            PWSelected = false;
            FWSelected = false;
            labelItem_ModeImg.Image = Resources.JD2;

            comboBoxEx_Proc.Items.Clear();

            var comboItem1 = new DevComponents.Editors.ComboItem();
            var comboItem2 = new DevComponents.Editors.ComboItem();
            var comboItem3 = new DevComponents.Editors.ComboItem();
            var comboItem4 = new DevComponents.Editors.ComboItem();
            var comboItem5 = new DevComponents.Editors.ComboItem();
            var comboItem6 = new DevComponents.Editors.ComboItem();
            var comboItem7 = new DevComponents.Editors.ComboItem();
            var comboItem8 = new DevComponents.Editors.ComboItem();
            var comboItem9 = new DevComponents.Editors.ComboItem();
            var comboItem10 = new DevComponents.Editors.ComboItem();
            var comboItem11 = new DevComponents.Editors.ComboItem();
            var comboItem12 = new DevComponents.Editors.ComboItem();
            var comboItem13 = new DevComponents.Editors.ComboItem();
            var comboItem14 = new DevComponents.Editors.ComboItem();
            var comboItem15 = new DevComponents.Editors.ComboItem();
            var comboItem16 = new DevComponents.Editors.ComboItem();
            var comboItem17 = new DevComponents.Editors.ComboItem();
            var comboItem18 = new DevComponents.Editors.ComboItem();
            var comboItem19 = new DevComponents.Editors.ComboItem();
            var comboItem20 = new DevComponents.Editors.ComboItem();
            var comboItem21 = new DevComponents.Editors.ComboItem();
            var comboItem22 = new DevComponents.Editors.ComboItem();
            var comboItem23 = new DevComponents.Editors.ComboItem();
            var comboItem24 = new DevComponents.Editors.ComboItem();
            var comboItem25 = new DevComponents.Editors.ComboItem();
            var comboItem26 = new DevComponents.Editors.ComboItem();

            comboItem1.Text = Resources.Atk;
            comboItem2.Text = Resources.CastSkill;
            comboItem3.Text = Resources.Broadcast;
            comboItem4.Text = Resources.ResetAggro;
            comboItem5.Text = Resources.Exec_AS;
            comboItem6.Text = Resources.DisableAS;
            comboItem7.Text = Resources.EnableAS;
            comboItem8.Text = Resources.CreateTimer;
            comboItem9.Text = Resources.DelTimer;
            comboItem10.Text = Resources.Flee;
            comboItem11.Text = Resources.BeTaunted;
            comboItem12.Text = Resources.Unk + Resources.ELEVEN;
            comboItem13.Text = Resources.FadeAggro;
            comboItem14.Text = Resources.Unk + Resources.THIRTEEN;
            comboItem15.Text = Resources.Trigger;
            comboItem16.Text = Resources.SumMob;
            comboItem17.Text = Resources.Unk + Resources.SIXTEEN;
            comboItem18.Text = Resources.SetPath;
            comboItem19.Text = Resources.Disappear;
            comboItem20.Text = Resources.NA;
            comboItem21.Text = Resources.Respawn;
            comboItem22.Text = Resources.SetValue;
            comboItem23.Text = Resources.AddValue;
            comboItem24.Text = Resources.NA;
            comboItem25.Text = Resources.SetMobAttr;
            comboItem26.Text = Resources.Warsoul;

            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem1,
                comboItem2,
                comboItem3,
                comboItem4,
                comboItem5,
                comboItem6,
                comboItem7,
                comboItem8,
                comboItem9,
                comboItem10,
                comboItem11,
                comboItem12,
                comboItem13,
                comboItem14,
                comboItem15,
                comboItem16,
                comboItem17,
                comboItem18,
                comboItem19,
                comboItem20,
                comboItem21,
                comboItem22,
                comboItem23,
                comboItem24,
                comboItem25,
                comboItem26
            });

            JDProcList();
        }

        private void ButtonItemPWClick(object sender, EventArgs e)
        {
            if (switchButtonItem_ModeLock.Value)
            {
                MessageBox.Show(Resources.NoSwitchMode);
                return;
            }
            JDSelected = false;
            PWSelected = true;
            FWSelected = false;
            labelItem_ModeImg.Image = Resources.PW1;

            comboBoxEx_Proc.Items.Clear();

            var comboItem1 = new DevComponents.Editors.ComboItem();
            var comboItem2 = new DevComponents.Editors.ComboItem();
            var comboItem3 = new DevComponents.Editors.ComboItem();
            var comboItem4 = new DevComponents.Editors.ComboItem();
            var comboItem5 = new DevComponents.Editors.ComboItem();
            var comboItem6 = new DevComponents.Editors.ComboItem();
            var comboItem7 = new DevComponents.Editors.ComboItem();
            var comboItem8 = new DevComponents.Editors.ComboItem();
            var comboItem9 = new DevComponents.Editors.ComboItem();
            var comboItem10 = new DevComponents.Editors.ComboItem();
            var comboItem11 = new DevComponents.Editors.ComboItem();
            var comboItem12 = new DevComponents.Editors.ComboItem();
            var comboItem13 = new DevComponents.Editors.ComboItem();
            var comboItem14 = new DevComponents.Editors.ComboItem();
            var comboItem15 = new DevComponents.Editors.ComboItem();
            var comboItem16 = new DevComponents.Editors.ComboItem();
            var comboItem17 = new DevComponents.Editors.ComboItem();
            var comboItem18 = new DevComponents.Editors.ComboItem();
            var comboItem19 = new DevComponents.Editors.ComboItem();
            var comboItem20 = new DevComponents.Editors.ComboItem();

            comboItem1.Text = Resources.Atk;
            comboItem2.Text = Resources.CastSkill;
            comboItem3.Text = Resources.Broadcast;
            comboItem4.Text = Resources.ResetAggro;
            comboItem5.Text = Resources.Exec_AS;
            comboItem6.Text = Resources.DisableAS;
            comboItem7.Text = Resources.EnableAS;
            comboItem8.Text = Resources.CreateTimer;
            comboItem9.Text = Resources.DelTimer;
            comboItem10.Text = Resources.Flee;
            comboItem11.Text = Resources.BeTaunted;
            comboItem12.Text = Resources.FadeTarget;
            comboItem13.Text = Resources.FadeAggro;
            comboItem14.Text = Resources.Break;
            comboItem15.Text = Resources.NPCGenerator;
            comboItem16.Text = Resources.InitPubCount;
            comboItem17.Text = Resources.IncPubCount;
            comboItem18.Text = Resources.NPCSpawn;
            comboItem19.Text = Resources.ChangePath;
            comboItem20.Text = Resources.PlayAction;

            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem1,
                comboItem2,
                comboItem3,
                comboItem4,
                comboItem5,
                comboItem6,
                comboItem7,
                comboItem8,
                comboItem9,
                comboItem10,
                comboItem11,
                comboItem12,
                comboItem13,
                comboItem14,
                comboItem15,
                comboItem16,
                comboItem17,
                comboItem18,
                comboItem19,
                comboItem20
            });

            PWProcList();
        }

        private void ButtonItemFWClick(object sender, EventArgs e)
        {
            if (switchButtonItem_ModeLock.Value)
            {
                MessageBox.Show(Resources.NoSwitchMode);
                return;
            }
            JDSelected = false;
            PWSelected = false;
            FWSelected = true;
            labelItem_ModeImg.Image = Resources.FW2;

            comboBoxEx_Proc.Items.Clear();

            var comboItem1 = new DevComponents.Editors.ComboItem();
            var comboItem2 = new DevComponents.Editors.ComboItem();
            var comboItem3 = new DevComponents.Editors.ComboItem();
            var comboItem4 = new DevComponents.Editors.ComboItem();
            var comboItem5 = new DevComponents.Editors.ComboItem();
            var comboItem6 = new DevComponents.Editors.ComboItem();
            var comboItem7 = new DevComponents.Editors.ComboItem();
            var comboItem8 = new DevComponents.Editors.ComboItem();
            var comboItem9 = new DevComponents.Editors.ComboItem();
            var comboItem10 = new DevComponents.Editors.ComboItem();
            var comboItem11 = new DevComponents.Editors.ComboItem();
            var comboItem12 = new DevComponents.Editors.ComboItem();
            var comboItem13 = new DevComponents.Editors.ComboItem();
            var comboItem14 = new DevComponents.Editors.ComboItem();
            var comboItem15 = new DevComponents.Editors.ComboItem();
            var comboItem16 = new DevComponents.Editors.ComboItem();
            var comboItem17 = new DevComponents.Editors.ComboItem();
            var comboItem18 = new DevComponents.Editors.ComboItem();
            var comboItem19 = new DevComponents.Editors.ComboItem();
            var comboItem20 = new DevComponents.Editors.ComboItem();
            var comboItem21 = new DevComponents.Editors.ComboItem();
            var comboItem22 = new DevComponents.Editors.ComboItem();
            var comboItem23 = new DevComponents.Editors.ComboItem();
            var comboItem24 = new DevComponents.Editors.ComboItem();
            var comboItem25 = new DevComponents.Editors.ComboItem();
            var comboItem26 = new DevComponents.Editors.ComboItem();
            var comboItem27 = new DevComponents.Editors.ComboItem();
            var comboItem28 = new DevComponents.Editors.ComboItem();

            comboItem1.Text = Resources.Atk;
            comboItem2.Text = Resources.CastSkill;
            comboItem3.Text = Resources.Broadcast;
            comboItem4.Text = Resources.ResetAggro;
            comboItem5.Text = Resources.Exec_AS;
            comboItem6.Text = Resources.DisableAS;
            comboItem7.Text = Resources.EnableAS;
            comboItem8.Text = Resources.CreateTimer;
            comboItem9.Text = Resources.DelTimer;
            comboItem10.Text = Resources.Flee;
            comboItem11.Text = Resources.BeTaunted;
            comboItem12.Text = Resources.FadeTarget;
            comboItem13.Text = Resources.NA;
            comboItem14.Text = Resources.Unk + Resources.THIRTEEN;
            comboItem15.Text = Resources.NPCGenerator;
            comboItem16.Text = Resources.SumMob;
            comboItem17.Text = Resources.Unk + Resources.SIXTEEN;
            comboItem18.Text = Resources.Unk + Resources.SEVENTEEN;
            comboItem19.Text = Resources.Disappear;
            comboItem20.Text = Resources.Unk + Resources.NINETEEN;
            comboItem21.Text = Resources.NA;
            comboItem22.Text = Resources.SetMobAttr;
            comboItem23.Text = Resources.SetValue;
            comboItem24.Text = Resources.AddValue;
            comboItem25.Text = Resources.Unk + Resources.TWOFOUR;
            comboItem26.Text = Resources.Unk + Resources.TWOFIVE;
            comboItem27.Text = Resources.Unk + Resources.TWOSIX;
            comboItem28.Text = Resources.Unk + Resources.TWOSEVEN;

            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem1,
                comboItem2,
                comboItem3,
                comboItem4,
                comboItem5,
                comboItem6,
                comboItem7,
                comboItem8,
                comboItem9,
                comboItem10,
                comboItem11,
                comboItem12,
                comboItem13,
                comboItem14,
                comboItem15,
                comboItem16,
                comboItem17,
                comboItem18,
                comboItem19,
                comboItem20,
                comboItem21,
                comboItem22,
                comboItem23,
                comboItem24,
                comboItem25,
                comboItem26,
                comboItem27,
                comboItem28
            });

            FWProcList();
        }

        private void ButtonItemMenuSaveClick(object sender, EventArgs e)
        {
            ButtonItemSaveClick(sender, e);
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            ButtonItemJDClick(sender, e);
        }
        
    }
}
