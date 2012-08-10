using System;
using System.Collections;
using System.Drawing;
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
            labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Gold;
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
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.ONE;
                    break;

                // Fade_Aggro()
                case 12:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.FadeAggro;
                    break;

                // Unknown13()
                case 13:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.THREE;
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
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.SIX;
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
                    labelX_Param2.Text = Resources.EQUAL;
                    break;

                // Add_Value(int value, int toAdd)
                case 23:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.AddValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources.PLUS;
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
            var s2 = s.Substring(0, 1);
            var text = s.Substring(1);

            //if (text.ToString(CultureInfo.InvariantCulture) == "") return null;

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
                    //string s2;
                    if (text2 == "(")
                    {
                        if (stack.Count != 0)
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition2 = new Condition { OperID = Program.JDIDOper(stack.Pop().ToString()) };
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
                        if (stack.Count != 0 && (text2 == "" || Program.GetOperPrime(Program.JDIDOper(stack.Peek().ToString())) <= Program.GetOperPrime(Program.JDIDOper(text2))))
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition3 = new Condition { OperID = Program.JDIDOper(stack.Pop().ToString()) };
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
            if (c.OperID > 23) return null;
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

        // Overloaded function
        private static int JDProcedureTarget(string target)
        {
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_MOST")       return 0;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST")      return 1;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST_RAND") return 2;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_HP")          return 3;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_MP")          return 4;
            if (target.ToString(CultureInfo.InvariantCulture) == "LEAST_HP")         return 5;
            if (target.ToString(CultureInfo.InvariantCulture) == "TEAM")             return 6;
            if (target.ToString(CultureInfo.InvariantCulture) == "SELF")             return 7;
            return 0; // defaults to AGGRO_MOST as it is the most common
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
                    return Resources.IsTimerTicking;
                case 1:
                    return Resources.IsHPLess;
                case 2:
                    return Resources.IsCombatStarted;
                case 3:
                    return Resources.Randomize;
                case 4:
                    return Resources.IsTargetDead;
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return Resources.IsDead;
                case 9:
                    return Resources.PathTo;
                case 10:
                    return Resources.MoreThan;
                case 11:
                    return Resources.DistanceTo;
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
                    return Resources.Variable;
                case 20:
                    return Resources.VariableValue;
                case 21:
                    return Resources.Rank;
                case 22:
                    return Resources.NPCVent;
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
                case 0:    // Is_Timer_Ticking[0]
                case 9:    // Path_To[0]
                case 10:   // More_Than[0]
                case 19:   // Variable[0]
                case 20:   // Variable_Value[0]
                case 21:   // Rank[0]
                case 23:   // Cast_Skill[0]
                    return BitConverter.ToInt32(c.Value, 0).ToString(CultureInfo.InvariantCulture);
                case 1:    // Is_HP_Less[0.00]
                case 3:    // Randomize[0.00]
                case 11:   // Distance_To[0.00]
                    return BitConverter.ToSingle(c.Value, 0).ToString("F2");
                case 2:    // Is_Combat_Started[]
                case 4:    // Is_Target_Dead[]
                case 6:    // ||
                case 7:    // &&
                case 8:    // Is_Dead[]
                case 12:   // Unknown12[]
                case 13:   // Unknown13[]
                case 14:   // Unknown14[]
                case 15:   // Unknown15[]
                case 16:   // >
                case 17:   // <
                case 18:   // =
                case 22:   // NPC_Vent[]
                    return "";
                case 5:    // !
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
            labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Gold;
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

        private static Condition PWGetCondition(string s)
        {
            var num = 1;
            var num2 = 0;
            var s2 = s.Substring(0, 1);
            var text = s.Substring(1);

            //if (text.ToString(CultureInfo.InvariantCulture) == "") return null;
            
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
                    return PWGetCondition(s);
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
                    //string s2;
                    if (text2 == "(")
                    {
                        if (stack.Count != 0)
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition2 = new Condition { OperID = Program.PWIDOper(stack.Pop().ToString()) };
                            var tmpCond1 = condition2;
                            tmpCond1.ConditionType = Program.GetOperPrime(tmpCond1.OperID);
                            var tmpCond2 = condition2;
                            tmpCond2.ArgBytes = Program.GetOperArgBytes(tmpCond2.OperID);
                            var tmpCond3 = condition2;
                            tmpCond3.Value = new byte[tmpCond3.ArgBytes];
                            if (condition2.ConditionType == 1)
                            {
                                condition2.ConditionLeft = PWGetCondition(s2);
                                var tmpCond4 = condition2;
                                tmpCond4.SubNodeL = Program.GetSubNodeL(tmpCond4.OperID);
                                condition2.ConditionRight = PWGetCondition(text);
                                var tmpCond5 = condition2;
                                tmpCond5.SubNodeR = Program.GetSubNodeR(tmpCond5.OperID);
                            }
                            if (condition2.ConditionType == 2)
                            {
                                condition2.ConditionRight = PWGetCondition(text);
                                var tmpCond6 = condition2;
                                tmpCond6.SubNodeL = Program.GetSubNodeL(tmpCond6.OperID);
                            }
                            return condition2;
                        }
                        num4 = num2 + 1;
                    }
                    else
                    {
                        if (stack.Count != 0 && (text2 == "" || Program.GetOperPrime(Program.PWIDOper(stack.Peek().ToString())) <= Program.GetOperPrime(Program.PWIDOper(text2))))
                        {
                            num4--;
                            s2 = s.Substring(0, num4);
                            text = s.Substring(num4 + 1);
                            var condition3 = new Condition { OperID = Program.PWIDOper(stack.Pop().ToString()) };
                            var tmpCond7 = condition3;
                            tmpCond7.ConditionType = Program.GetOperPrime(tmpCond7.OperID);
                            var tmpCond8 = condition3;
                            tmpCond8.ArgBytes = Program.GetOperArgBytes(tmpCond8.OperID);
                            var value = new byte[condition3.ArgBytes];
                            switch (condition3.OperID)
                            {
                                case 0:
                                case 16:
                                case 17:
                                    value = BitConverter.GetBytes(Convert.ToInt32(stack2.Pop().ToString()));
                                    break;

                                case 1:
                                case 3:
                                value = BitConverter.GetBytes(Convert.ToSingle(stack2.Pop().ToString()));
                                    break;
                            }
                            condition3.Value = value;

                            if (condition3.ConditionType == 1)
                            {
                                condition3.ConditionLeft = PWGetCondition(s2);
                                var tmpCond9 = condition3;
                                tmpCond9.SubNodeL = Program.GetSubNodeL(tmpCond9.OperID);
                                condition3.ConditionRight = PWGetCondition(text);
                                var tmpCond10 = condition3;
                                tmpCond10.SubNodeR = Program.GetSubNodeR(tmpCond10.OperID);
                            }

                            if (condition3.ConditionType == 2)
                            {
                                condition3.ConditionRight = PWGetCondition(text);
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

        // Overloaded function
        private static int PWProcedureTarget(string target)
        {
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_MOST") return 0;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST") return 1;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST_RAND") return 2;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_HP") return 3;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_MP") return 4;
            if (target.ToString(CultureInfo.InvariantCulture) == "LEAST_HP") return 5;
            if (target.ToString(CultureInfo.InvariantCulture) == "CLASS_COMBO") return 6; // will have to fix this...
            if (target.ToString(CultureInfo.InvariantCulture) == "SELF") return 7;
            return 0; // defaults to AGGRO_MOST as it is the most common
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
                text += "[";
                if (c.ArgBytes > 0) text += PWConditionValue(c);
                text += "]";
            }
            return text;
        }

        private static string PWConditionName(int operID)
        {
            switch (operID)
            {
                case 0:
                    return Resources.IsTimerTicking;
                case 1:
                    return Resources.IsHPLess;
                case 2:
                    return Resources.IsCombatStarted;
                case 3:
                    return Resources.Randomize;
                case 4:
                    return "Is_Target_Dead";
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return Resources.IsDead;
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
                    return Resources.PubCtr;
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
                case 0:    // Is_Timer_Ticking[0]
                case 16:   // Public_Counter[0]
                case 17:   // Value[0]
                    return BitConverter.ToInt32(c.Value, 0).ToString(CultureInfo.InvariantCulture);
                case 1:    // Is_HP_Less[0.00]
                case 3:    // Randomize[0.00]
                    return BitConverter.ToSingle(c.Value, 0).ToString("F2");
                case 2:    // Is_Combat_Started[]
                case 4:    // Is_Target_Killed[]
                case 6:    // ||
                case 7:    // &&
                case 8:    // Is_Dead[]
                case 9:    // +
                case 10:   // -
                case 11:   // ==
                case 12:   // >
                case 13:   // >=
                case 14:   // (space)
                case 15:   // >
                case 18:   // Is_Event[]?
                    return "";
                case 5:    // !
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
            labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Gold;
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
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.ONE;
                    break;

                // N/A
                case 12:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.NA;
                    break;

                // Unknown13()
                case 13:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.THREE;
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
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.SIX;
                    labelX_Param1.Text = Resources.Unk;
                    break;

                // Unknown17(int x, int y)
                case 17:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.SEVEN;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    break;

                // Disappear()
                case 18:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Disappear;
                    break;

                // Unknown19(int x)
                case 19:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.ONE + Resources.NINE;
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
                    labelX_Param2.Text = Resources.EQUAL;
                    break;

                // Add_Value(int value, int toAdd)
                case 23:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.AddValue;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources.PLUS;
                    break;

                // Unknown24(int x, int y)
                case 24:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWO + Resources.FOUR;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    break;

                // Unknown25(int x, int y, int z)
                case 25:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWO + Resources.FIVE;
                    labelX_Param1.Text = Resources.Unk;
                    labelX_Param2.Text = Resources.Unk;
                    labelX_Param3.Text = Resources.Unk;
                    break;

                // Unknown26()
                case 26:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWO + Resources.SIX;
                    break;
                // Unknown26()
                case 27:
                    groupPanel_ProcParams.Text = Resources.AddProc + Resources.Unk + Resources.TWO + Resources.THREE;
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

        private static string FWProcedureTarget(int target)
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

        // Overloaded function
        private static int FWProcedureTarget(string target)
        {
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_MOST") return 0;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST") return 1;
            if (target.ToString(CultureInfo.InvariantCulture) == "AGGRO_LEAST_RAND") return 2;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_HP") return 3;
            if (target.ToString(CultureInfo.InvariantCulture) == "MOST_MP") return 4;
            if (target.ToString(CultureInfo.InvariantCulture) == "LEAST_HP") return 5;
            if (target.ToString(CultureInfo.InvariantCulture) == "TEAM") return 6;
            if (target.ToString(CultureInfo.InvariantCulture) == "SELF") return 7;
            return 0; // defaults to AGGRO_MOST as it is the most common
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
                text += "[";
                if (c.ArgBytes > 0) text += FWConditionValue(c);
                text += "]";
            }
            return text;
        }

        private string FWConditionName(int operID)
        {
            switch (operID)
            {
                case 0:
                    return Resources.IsTimerTicking;
                case 1:
                    return Resources.IsHPLess;
                case 2:
                    return Resources.IsCombatStarted;
                case 3:
                    return Resources.Randomize;
                case 4:
                    return Resources.IsTargetDead;
                case 5:
                    return "!";
                case 6:
                    return "||";
                case 7:
                    return "&&";
                case 8:
                    return Resources.IsDead;
                case 9:
                    return Resources.PathTo;
                case 10:
                    return Resources.MoreThan;
                case 11:
                    return Resources.DistanceTo;
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
                    return Resources.Variable;
                case 20:
                    return Resources.VariableValue;
                case 21:
                    return Resources.Rank;
                case 22:
                    return Resources.NPCVent;
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
            return str + (" " + FWProcedureTarget(p.Target));
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
                                if (i == 1818)
                                {
                                    
                                }
                                AI.ActionController[i] = new ActionController();
                                AI.ActionController[i].Signature = binaryReader.ReadInt32();
                                AI.ActionController[i].ID = binaryReader.ReadInt32();
                                AI.ActionController[i].ndx = AI.ActionController[i].ID;
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

            labelX_Param2.BackColor = Color.Transparent;
            ClearParams();
            if (AI == null || listBox_Controller.SelectedIndex <= -1) return;
            var cSelectedIndex = listBox_Controller.SelectedIndex;
            listBox_ActionSet.Items.Clear();
            var actionSet = AI.ActionController[cSelectedIndex].ActionSet;
            
            foreach (var aSet in actionSet)
            {
                var iD = aSet.ID;
                listBox_ActionSet.Items.Add("[" + iD.ToString(CultureInfo.InvariantCulture) + "] " + aSet.Name);
                textBoxX_CtrlID.Text = AI.ActionController[cSelectedIndex].ID.ToString(CultureInfo.InvariantCulture);
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
            labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Gold;
                var byteCount = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = byteCount.ToString(CultureInfo.InvariantCulture);
                textBoxX_Param2.Text = Encoding.Unicode.GetString((byte[])AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1]);
            }

            // Type 3 - Reset_Aggro()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 3)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.FadeAggro;
            }

            // Type 4 - Exec_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 4)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.Exec_AS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 5 - Disable_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 5)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.DisableAS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 6 - Enable_ActionSet(int actionset_id)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 6)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.EnableAS;
                labelX_Param1.Text = Resources.ASID;
                var actionID = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = actionID.ToString(CultureInfo.InvariantCulture);
            }

            // Type 7 - Create_Timer(int timerID, int delay, int cycles)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 7)
            {
                labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.DelTimer;
                labelX_Param1.Text = Resources.TimerID;
                var num11 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = num11.ToString(CultureInfo.InvariantCulture);
            }

            // Type 9 - Flee()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 9)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.Flee;
            }

            // Type 10 - Be_Taunted()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 10)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.BeTaunted;
            }

            // Type 11
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 11)
            {
                labelX_Param2.BackColor = Color.Transparent;
                // Jade Dynasty - Unknown11()
                if (JDSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.ONE + Resources.ONE;
                // Perfect World/Forsaken - Fade_Target()
                if (PWSelected || FWSelected) groupPanel_ProcParams.Text = Resources.FadeTarget;
            }

            // Type 12
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 12)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.Fade_Aggro;
            }

            // Type 13
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 13)
            {
                labelX_Param2.BackColor = Color.Transparent;
                // Jade Dynasty - Unknown13()
                if (JDSelected || FWSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.ONE + Resources.THREE;
                // Perfect World - Break()
                if (PWSelected) groupPanel_ProcParams.Text = Resources.Break;
            }

            // Type 14
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 14)
            {
                labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
                // Jade Dynasty/Forsaken World - Unknown16(int unk)
                if (JDSelected || FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.ONE + Resources.SIX;
                    labelX_Param1.Text = Resources.Unk;
                    var unk1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                    textBoxX_Param1.Text = unk1.ToString(CultureInfo.InvariantCulture);
                }
                // Perfect World - Increment_Public_Counter(int x, int y)
                if (PWSelected)
                {
                    labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Transparent;
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.ONE + Resources.SEVEN;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                groupPanel_ProcParams.Text = Resources.Unk + Resources.ONE + Resources.NINE;
                labelX_Param1.Text = Resources.AtkParam1;
                var param1 = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = param1.ToString(CultureInfo.InvariantCulture);
            }

            // Type 20 - N/A
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 20)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.NA;
            }

            // Type 21 - Respawn()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 21)
            {
                labelX_Param2.BackColor = Color.Transparent;
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
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.SetValue;
                labelX_Param1.Text = Resources.Value;
                labelX_Param2.Text = Resources.EQUAL;
                var oldValue = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = oldValue.ToString(CultureInfo.InvariantCulture);
                var newValue = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = newValue.ToString(CultureInfo.InvariantCulture);
            }

            // Type 23 - Add_Value(int value, int toAdd)
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 23)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.AddValue;
                labelX_Param1.Text = Resources.Value;
                labelX_Param2.Text = Resources.PLUS;
                var value = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[0];
                textBoxX_Param1.Text = value.ToString(CultureInfo.InvariantCulture);
                var toAdd = (int)AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Parameter[1];
                textBoxX_Param2.Text = toAdd.ToString(CultureInfo.InvariantCulture);
            }

            // Type 24 - N/A
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 24)
            {
                labelX_Param2.BackColor = Color.Transparent;
                if (FWSelected)
                {
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.TWO + Resources.FOUR;
                    labelX_Param1.Text = Resources.Value;
                    labelX_Param2.Text = Resources.PLUS;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                    labelX_Param2.BackColor = Color.Transparent;
                    groupPanel_ProcParams.Text = Resources.Unk + Resources.TWO + Resources.FIVE;
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
                labelX_Param2.BackColor = Color.Transparent;
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
                if (FWSelected) groupPanel_ProcParams.Text = Resources.Unk + Resources.TWO + Resources.SIX;
            }

            // Type 27 - Unknown27()
            if (AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Type == 27)
            {
                labelX_Param2.BackColor = Color.Transparent;
                groupPanel_ProcParams.Text = Resources.Unk + Resources.TWO + Resources.SEVEN;
            }

            // Type Target
            var target = AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target;
            
            // Jade Dynasty
            if (JDSelected) textBoxX_ParamTarget.Text = JDProcedureTarget(target);
            // Perfect World
            if (PWSelected && target == 6)
                textBoxX_ParamTarget.Text =
                    PWProcedureTarget(target, AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].TargetParams);
            else textBoxX_ParamTarget.Text = PWProcedureTarget(target, null);
            // Forsaken World
            if (FWSelected) textBoxX_ParamTarget.Text = FWProcedureTarget(target);
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
                
                // Jade Dynasty
                if (JDSelected) AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target =
                    Convert.ToInt32(JDProcedureTarget(textBoxX_ParamTarget.Text));
                // Perfect World
                if (PWSelected) AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target =
                    Convert.ToInt32(PWProcedureTarget(textBoxX_ParamTarget.Text));
                // Forsaken World
                if (FWSelected) AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Procedure[pSelectedIndex].Target =
                    Convert.ToInt32(FWProcedureTarget(textBoxX_ParamTarget.Text));

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

            if (textBoxX_Condition.Text == "")
            {
                MessageBox.Show(Resources.NoExpEntered);
                return;
            }

            var cSelectedIndex = listBox_Controller.SelectedIndex;
            var asSelectedIndex = listBox_ActionSet.SelectedIndex;
            //var pSelectedIndex = this.listBox_Procedure.SelectedIndex;
            var text = textBoxX_Condition.Text;

            // Jade Dynasty
            if (JDSelected)
            {
                text = text.Replace(" ", "");
                text = text.Replace("Is_Timer_Ticking", "a"); // Is_Timer_Ticking[0]
                text = text.Replace("Is_HP_Less", "b"); // Is_HP_Less[0.00]
                text = text.Replace("Is_Combat_Started", "c"); // Is_Combat_Started[]
                text = text.Replace("Randomize", "d"); // Randomize[0.00]
                text = text.Replace("Is_Target_Dead", "e"); // Is_Target_Dead[]
                text = text.Replace("||", "f"); // OR
                text = text.Replace("&&", "g"); // AND
                text = text.Replace("Is_Dead", "h"); // Is_Dead[]
                text = text.Replace("Path_To", "i"); // Path_To[0]
                text = text.Replace("More_Than", "j"); // More_Than[0]
                text = text.Replace("Distance_To", "k"); // Distance_To[0.00]
                text = text.Replace("Unknown12", "l"); // Unknown12[]
                text = text.Replace("Unknown13", "m"); // Unknown13[]
                text = text.Replace("Unknown14", "n"); // Unknown14[]
                text = text.Replace("Unknown15", "o"); // Unknown15[]
                text = text.Replace("Variable_Value", "q"); // Variable_Value[0]
                text = text.Replace("Variable", "p"); // Variable[0]
                text = text.Replace("Rank", "r"); // Rank[0]
                text = text.Replace("NPC_Vent", "s"); //  NPC_Vent[]
                text = text.Replace("Cast_Skill", "t"); // Cast_Skill[0]
                //text = text.Replace("Public_Counter", "u"); // Public_Counter[0]
                //text = text.Replace("Value", "v"); // Value[0]
                //text = text.Replace("Is_Event", "w"); // Is_Event[]
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
            }

            // Perfect World
            if (PWSelected)
            {
                text = text.Replace(" ", "");
                text = text.Replace("Is_Timer_Ticking", "a"); // Is_Timer_Ticking[0]
                text = text.Replace("Is_HP_Less", "b"); // Is_HP_Less[0.00]
                text = text.Replace("Is_Combat_Started", "c"); // Is_Combat_Started[]
                text = text.Replace("Randomize", "d"); // Randomize[0.00]
                text = text.Replace("Is_Target_Dead", "e"); // Is_Target_Dead[]
                text = text.Replace("||", "f"); // OR
                text = text.Replace("&&", "g"); // AND
                text = text.Replace("Is_Dead", "h"); // Is_Dead[]
                text = text.Replace("Public_Counter", "i"); // Public_Counter[0]
                text = text.Replace("Value", "j"); // Value[0]
                text = text.Replace("Is_Event", "k"); // Is_Event[]
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
            }

            if (!Program.IsMatch(text))
                MessageBox.Show(Resources.NoMatchCond);
            else
            {
                for (var i = 0; i < text.Length; i++)
                {
                    var expr = text.Substring(i, 1);
                    if (JDSelected)
                    {
                        if (expr == "(" || expr == ")" || expr == "." || Program.IsNumber(expr) || Program.JDIDOper(expr) >= 0)
                            continue;
                    }
                    if (PWSelected)
                    {
                        if (expr == "(" || expr == ")" || expr == "." || Program.IsNumber(expr) || Program.PWIDOper(expr) >= 0)
                            continue;
                    }
                    //if (expr == "(" || expr == ")" ||  expr == "." || Program.IsNumber(expr) || Program.JDIDOper(expr) >= 0)
                    //    continue;
                    MessageBox.Show(Resources.NoResolveCond + expr);
                    return;
                }
                if (JDSelected)
                {
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition = JDGetCondition(text);
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition =
                        JDFixCondition(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                }
                if (PWSelected)
                {
                    AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition = PWGetCondition(text);
                    //AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition =
                    //    JDFixCondition(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                }
                //AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition = JDGetCondition(text);
                //AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition =
                //    JDFixCondition(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                
                textBoxX_Condition.Clear();
                
                // Jade Dynasty
                if (JDSelected) textBoxX_Condition.Text = JDConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                // Perfect World
                if (PWSelected) textBoxX_Condition.Text = PWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
                // Forsaken World
                if (FWSelected) textBoxX_Condition.Text = FWConditionExpression(AI.ActionController[cSelectedIndex].ActionSet[asSelectedIndex].Condition);
            }
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
            // Forsaken World
            if (FWSelected) FWProcList();
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
            Program._jdState = true;
            PWSelected = false;
            Program._pwState = false;
            FWSelected = false;
            Program._fwState = false;
            labelItem_ModeImg.Image = Resources.JD2;

            // Clear out the comboBox
            comboBoxEx_Proc.Items.Clear();

            // Dynamically allocate all needed items
            var comboItem0 = new DevComponents.Editors.ComboItem();
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

            // setup item values
            comboItem0.Text = Resources.Atk;
            comboItem0.FontStyle = FontStyle.Bold;

            comboItem1.Text = Resources.CastSkill;
            comboItem1.FontStyle = FontStyle.Bold;

            comboItem2.Text = Resources.Broadcast;
            comboItem2.FontStyle = FontStyle.Bold;

            comboItem3.Text = Resources.ResetAggro;
            comboItem3.FontStyle = FontStyle.Bold;

            comboItem4.Text = Resources.Exec_AS;
            comboItem4.FontStyle = FontStyle.Bold;

            comboItem5.Text = Resources.DisableAS;
            comboItem5.FontStyle = FontStyle.Bold;

            comboItem6.Text = Resources.EnableAS;
            comboItem6.FontStyle = FontStyle.Bold;

            comboItem7.Text = Resources.CreateTimer;
            comboItem7.FontStyle = FontStyle.Bold;

            comboItem8.Text = Resources.DelTimer;
            comboItem8.FontStyle = FontStyle.Bold;

            comboItem9.Text = Resources.Flee;
            comboItem9.FontStyle = FontStyle.Bold;

            comboItem10.Text = Resources.BeTaunted;
            comboItem10.FontStyle = FontStyle.Bold;

            comboItem11.Text = Resources.Unk + Resources.ONE + Resources.ONE;
            comboItem11.FontStyle = FontStyle.Bold;

            comboItem12.Text = Resources.FadeAggro;
            comboItem12.FontStyle = FontStyle.Bold;

            comboItem13.Text = Resources.Unk + Resources.ONE + Resources.THREE;
            comboItem13.FontStyle = FontStyle.Bold;

            comboItem14.Text = Resources.Trigger;
            comboItem14.FontStyle = FontStyle.Bold;

            comboItem15.Text = Resources.SumMob;
            comboItem15.FontStyle = FontStyle.Bold;

            comboItem16.Text = Resources.Unk + Resources.ONE + Resources.SIX;
            comboItem16.FontStyle = FontStyle.Bold;

            comboItem17.Text = Resources.SetPath;
            comboItem17.FontStyle = FontStyle.Bold;

            comboItem18.Text = Resources.Disappear;
            comboItem18.FontStyle = FontStyle.Bold;

            comboItem19.Text = Resources.NA;
            comboItem19.FontStyle = FontStyle.Bold;

            comboItem20.Text = Resources.NA;
            comboItem20.FontStyle = FontStyle.Bold;

            comboItem21.Text = Resources.Respawn;
            comboItem21.FontStyle = FontStyle.Bold;

            comboItem22.Text = Resources.SetValue;
            comboItem22.FontStyle = FontStyle.Bold;

            comboItem23.Text = Resources.AddValue;
            comboItem23.FontStyle = FontStyle.Bold;

            comboItem24.Text = Resources.NA;
            comboItem24.FontStyle = FontStyle.Bold;

            comboItem25.Text = Resources.SetMobAttr;
            comboItem25.FontStyle = FontStyle.Bold;

            comboItem26.Text = Resources.Warsoul;
            comboItem26.FontStyle = FontStyle.Bold;

            // add created range to comboBox
            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem0,
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
            // list procedures
            JDProcList();

            // clear out condition expressions
            comboBoxEx_CondEx.Items.Clear();

            // Dynamically allocate all needed items
            var comboItemx0 = new DevComponents.Editors.ComboItem();   // <BLANK>
            var comboItemx1 = new DevComponents.Editors.ComboItem();   // Is_Timer_Ticking[0]
            var comboItemx2 = new DevComponents.Editors.ComboItem();   // Is_HP_Less[0.00]
            var comboItemx3 = new DevComponents.Editors.ComboItem();   // Is_Combat_Started[]
            var comboItemx4 = new DevComponents.Editors.ComboItem();   // Randomize[0]
            var comboItemx5 = new DevComponents.Editors.ComboItem();   // Is_Target_Dead[]
            var comboItemx6 = new DevComponents.Editors.ComboItem();   // Is_Dead[]
            var comboItemx7 = new DevComponents.Editors.ComboItem();   // Path_To[0]
            var comboItemx8 = new DevComponents.Editors.ComboItem();   // More_Than[0]
            var comboItemx9 = new DevComponents.Editors.ComboItem();   // Distance_To[0.00]
            var comboItemx10 = new DevComponents.Editors.ComboItem();  // Unknown12[]
            var comboItemx11 = new DevComponents.Editors.ComboItem();  // Unknown13[]
            var comboItemx12 = new DevComponents.Editors.ComboItem();  // Unknown14[]
            var comboItemx13 = new DevComponents.Editors.ComboItem();  // Unknown15[]
            var comboItemx14 = new DevComponents.Editors.ComboItem();  // Variable[0]
            var comboItemx15 = new DevComponents.Editors.ComboItem();  // Variable_Value[0]
            var comboItemx16 = new DevComponents.Editors.ComboItem();  // Rank[0]
            var comboItemx17 = new DevComponents.Editors.ComboItem();  // NPC_Vent[]
            var comboItemx18 = new DevComponents.Editors.ComboItem();  // Cast_Skill[0]

            // setup item values
            comboItemx0.Text = "";                          // <BLANK>
            comboItemx0.FontStyle = FontStyle.Bold;
            comboItemx1.Text = Resources.IsTimerTicking;    // Is_Timer_Ticking[0]
            comboItemx1.FontStyle = FontStyle.Bold;
            comboItemx2.Text = Resources.IsHPLess;          // Is_HP_Less[0.00]
            comboItemx2.FontStyle = FontStyle.Bold;
            comboItemx3.Text = Resources.IsCombatStarted;   // Is_Combat_Started[]
            comboItemx3.FontStyle = FontStyle.Bold;
            comboItemx4.Text = Resources.Randomize;         // Randomize[0]
            comboItemx4.FontStyle = FontStyle.Bold;
            comboItemx5.Text = Resources.IsTargetDead;      // Is_Target_Dead[]
            comboItemx5.FontStyle = FontStyle.Bold;
            comboItemx6.Text = Resources.IsDead;            // Is_Dead[]
            comboItemx6.FontStyle = FontStyle.Bold;
            comboItemx7.Text = Resources.PathTo;            // Path_To[0]
            comboItemx7.FontStyle = FontStyle.Bold;
            comboItemx8.Text = Resources.MoreThan;          // More_Than[0]
            comboItemx8.FontStyle = FontStyle.Bold;
            comboItemx9.Text = Resources.DistanceTo;        // Distance_To[0.00]
            comboItemx9.FontStyle = FontStyle.Bold;
            comboItemx10.Text = Resources.Unk + Resources.ONE + Resources.TWO;    // Unknown12[]
            comboItemx10.FontStyle = FontStyle.Bold;
            comboItemx11.Text = Resources.Unk + Resources.ONE + Resources.THREE;  // Unknown13[]
            comboItemx11.FontStyle = FontStyle.Bold;
            comboItemx12.Text = Resources.Unk + Resources.ONE + Resources.FOUR;   // Unknown14[]
            comboItemx12.FontStyle = FontStyle.Bold;
            comboItemx13.Text = Resources.Unk + Resources.ONE + Resources.FIVE;   // Unknown15[]
            comboItemx13.FontStyle = FontStyle.Bold;
            comboItemx14.Text = Resources.Variable;         // Variable[0]
            comboItemx14.FontStyle = FontStyle.Bold;
            comboItemx15.Text = Resources.VariableValue;    // Variable_Value[0]
            comboItemx15.FontStyle = FontStyle.Bold;
            comboItemx16.Text = Resources.Rank;             // Rank[0]
            comboItemx16.FontStyle = FontStyle.Bold;
            comboItemx17.Text = Resources.NPCVent;          // NPC_Vent[]
            comboItemx17.FontStyle = FontStyle.Bold;
            comboItemx18.Text = Resources.CastSkill;        // Cast_Skill[0]
            comboItemx18.FontStyle = FontStyle.Bold;

            // add created range to comboBox
            comboBoxEx_CondEx.Items.AddRange(new object[]
            {
                comboItemx0,
                comboItemx1,
                comboItemx2,
                comboItemx3,
                comboItemx4,
                comboItemx5,
                comboItemx6,
                comboItemx7,
                comboItemx8,
                comboItemx9,
                comboItemx10,
                comboItemx11,
                comboItemx12,
                comboItemx13,
                comboItemx14,
                comboItemx15,
                comboItemx16,
                comboItemx17,
                comboItemx18
            });
        }

        private void ButtonItemPWClick(object sender, EventArgs e)
        {
            if (switchButtonItem_ModeLock.Value)
            {
                MessageBox.Show(Resources.NoSwitchMode);
                return;
            }
            JDSelected = false;
            Program._jdState = false;
            PWSelected = true;
            Program._pwState = true;
            FWSelected = false;
            Program._fwState = false;
            labelItem_ModeImg.Image = Resources.PW1;

            comboBoxEx_Proc.Items.Clear();

            var comboItem0 = new DevComponents.Editors.ComboItem();
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
            
            comboItem0.Text = Resources.Atk;
            comboItem0.FontStyle = FontStyle.Bold;
            comboItem1.Text = Resources.CastSkill;
            comboItem1.FontStyle = FontStyle.Bold;
            comboItem2.Text = Resources.Broadcast;
            comboItem2.FontStyle = FontStyle.Bold;
            comboItem3.Text = Resources.ResetAggro;
            comboItem3.FontStyle = FontStyle.Bold;
            comboItem4.Text = Resources.Exec_AS;
            comboItem4.FontStyle = FontStyle.Bold;
            comboItem5.Text = Resources.DisableAS;
            comboItem5.FontStyle = FontStyle.Bold;
            comboItem6.Text = Resources.EnableAS;
            comboItem6.FontStyle = FontStyle.Bold;
            comboItem7.Text = Resources.CreateTimer;
            comboItem7.FontStyle = FontStyle.Bold;
            comboItem8.Text = Resources.DelTimer;
            comboItem8.FontStyle = FontStyle.Bold;
            comboItem9.Text = Resources.Flee;
            comboItem9.FontStyle = FontStyle.Bold;
            comboItem10.Text = Resources.BeTaunted;
            comboItem10.FontStyle = FontStyle.Bold;
            comboItem11.Text = Resources.FadeTarget;
            comboItem11.FontStyle = FontStyle.Bold;
            comboItem12.Text = Resources.FadeAggro;
            comboItem12.FontStyle = FontStyle.Bold;
            comboItem13.Text = Resources.Break;
            comboItem13.FontStyle = FontStyle.Bold;
            comboItem14.Text = Resources.NPCGenerator;
            comboItem14.FontStyle = FontStyle.Bold;
            comboItem15.Text = Resources.InitPubCount;
            comboItem15.FontStyle = FontStyle.Bold;
            comboItem16.Text = Resources.IncPubCount;
            comboItem16.FontStyle = FontStyle.Bold;
            comboItem17.Text = Resources.NPCSpawn;
            comboItem17.FontStyle = FontStyle.Bold;
            comboItem18.Text = Resources.ChangePath;
            comboItem18.FontStyle = FontStyle.Bold;
            comboItem19.Text = Resources.PlayAction;
            comboItem19.FontStyle = FontStyle.Bold;
            comboItem20.Text = Resources.Broadcast;
            comboItem20.FontStyle = FontStyle.Bold;

            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem0,
                comboItem1,
                comboItem2,
                comboItem3,
                comboItem4,
                comboItem5,
                comboItem6,
                comboItem7,
                comboItem8,
                comboItem9
            });

            PWProcList();

            // clear out condition expressions
            comboBoxEx_CondEx.Items.Clear();

            // Dynamically allocate all needed items
            var comboItemx0 = new DevComponents.Editors.ComboItem();   // <BLANK>
            var comboItemx1 = new DevComponents.Editors.ComboItem();   // Is_Timer_Ticking[0]
            var comboItemx2 = new DevComponents.Editors.ComboItem();   // Is_HP_Less[0.00]
            var comboItemx3 = new DevComponents.Editors.ComboItem();   // Is_Combat_Started[]
            var comboItemx4 = new DevComponents.Editors.ComboItem();   // Randomize[0.00]
            var comboItemx5 = new DevComponents.Editors.ComboItem();   // Is_Target_Dead[]
            var comboItemx6 = new DevComponents.Editors.ComboItem();   // Is_Dead[]
            var comboItemx7 = new DevComponents.Editors.ComboItem();   // Public_Counter[0]
            var comboItemx8 = new DevComponents.Editors.ComboItem();   // Value[0]
            var comboItemx9 = new DevComponents.Editors.ComboItem();   // Is_Event?
            
            // setup item values
            comboItemx0.Text = "";                         // <BLANK>
            comboItemx0.FontStyle = FontStyle.Bold;
            comboItemx1.Text = Resources.IsTimerTicking;   // Is_Timer_Ticking[0]
            comboItemx1.FontStyle = FontStyle.Bold;
            comboItemx2.Text = Resources.IsHPLess;         // Is_HP_Less[0.00]
            comboItemx2.FontStyle = FontStyle.Bold;
            comboItemx3.Text = Resources.IsCombatStarted;  // Is_Combat_Started[]
            comboItemx3.FontStyle = FontStyle.Bold;
            comboItemx4.Text = Resources.Randomize;        // Randomize[0.00]
            comboItemx4.FontStyle = FontStyle.Bold;
            comboItemx5.Text = Resources.IsTargetDead;     // Is_Target_Dead[]
            comboItemx5.FontStyle = FontStyle.Bold;
            comboItemx6.Text = Resources.IsDead;           // Is_Dead[]
            comboItemx6.FontStyle = FontStyle.Bold;
            comboItemx7.Text = Resources.PubCtr;           // Public_Counter[0]
            comboItemx7.FontStyle = FontStyle.Bold;
            comboItemx8.Text = Resources.Value;            // Value[0]
            comboItemx8.FontStyle = FontStyle.Bold;
            comboItemx9.Text = Resources.IsEvent;          // Is_Event?
            comboItemx9.FontStyle = FontStyle.Bold;
            
            // add created range to comboBox
            comboBoxEx_CondEx.Items.AddRange(new object[]
            {
                comboItemx0,
                comboItemx1,
                comboItemx2,
                comboItemx3,
                comboItemx4,
                comboItemx5,
                comboItemx6,
                comboItemx7,
                comboItemx8,
                comboItemx9
            });
        }

        private void ButtonItemFWClick(object sender, EventArgs e)
        {
            if (switchButtonItem_ModeLock.Value)
            {
                MessageBox.Show(Resources.NoSwitchMode);
                return;
            }
            JDSelected = false;
            Program._jdState = false;
            PWSelected = false;
            Program._pwState = false;
            FWSelected = true;
            Program._fwState = true;
            labelItem_ModeImg.Image = Resources.FW2;

            comboBoxEx_Proc.Items.Clear();

            var comboItem0 = new DevComponents.Editors.ComboItem();
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
            
            comboItem0.Text = Resources.Atk;
            comboItem0.FontStyle = FontStyle.Bold;

            comboItem1.Text = Resources.CastSkill;
            comboItem1.FontStyle = FontStyle.Bold;

            comboItem2.Text = Resources.Broadcast;
            comboItem2.FontStyle = FontStyle.Bold;

            comboItem3.Text = Resources.ResetAggro;
            comboItem3.FontStyle = FontStyle.Bold;

            comboItem4.Text = Resources.Exec_AS;
            comboItem4.FontStyle = FontStyle.Bold;

            comboItem5.Text = Resources.DisableAS;
            comboItem5.FontStyle = FontStyle.Bold;

            comboItem6.Text = Resources.EnableAS;
            comboItem6.FontStyle = FontStyle.Bold;

            comboItem7.Text = Resources.CreateTimer;
            comboItem7.FontStyle = FontStyle.Bold;

            comboItem8.Text = Resources.DelTimer;
            comboItem8.FontStyle = FontStyle.Bold;

            comboItem9.Text = Resources.Flee;
            comboItem9.FontStyle = FontStyle.Bold;

            comboItem10.Text = Resources.BeTaunted;
            comboItem10.FontStyle = FontStyle.Bold;

            comboItem11.Text = Resources.FadeTarget;
            comboItem11.FontStyle = FontStyle.Bold;

            comboItem12.Text = Resources.NA;
            comboItem12.FontStyle = FontStyle.Bold;

            comboItem13.Text = Resources.Unk + Resources.ONE + Resources.THREE;
            comboItem13.FontStyle = FontStyle.Bold;

            comboItem14.Text = Resources.NPCGenerator;
            comboItem14.FontStyle = FontStyle.Bold;

            comboItem15.Text = Resources.SumMob;
            comboItem15.FontStyle = FontStyle.Bold;

            comboItem16.Text = Resources.Unk + Resources.ONE + Resources.THREE;
            comboItem16.FontStyle = FontStyle.Bold;

            comboItem17.Text = Resources.Unk + Resources.ONE + Resources.SEVEN;
            comboItem17.FontStyle = FontStyle.Bold;

            comboItem18.Text = Resources.Disappear;
            comboItem18.FontStyle = FontStyle.Bold;

            comboItem19.Text = Resources.Unk + Resources.ONE + Resources.NINE;
            comboItem19.FontStyle = FontStyle.Bold;

            comboItem20.Text = Resources.NA;
            comboItem20.FontStyle = FontStyle.Bold;

            comboItem21.Text = Resources.SetMobAttr;
            comboItem21.FontStyle = FontStyle.Bold;

            comboItem22.Text = Resources.SetValue;
            comboItem22.FontStyle = FontStyle.Bold;

            comboItem23.Text = Resources.AddValue;
            comboItem23.FontStyle = FontStyle.Bold;

            comboItem24.Text = Resources.Unk + Resources.TWO + Resources.FOUR;
            comboItem24.FontStyle = FontStyle.Bold;

            comboItem25.Text = Resources.Unk + Resources.TWO + Resources.FIVE;
            comboItem25.FontStyle = FontStyle.Bold;

            comboItem26.Text = Resources.Unk + Resources.TWO + Resources.SIX;
            comboItem26.FontStyle = FontStyle.Bold;

            comboItem27.Text = Resources.Unk + Resources.TWO + Resources.SEVEN;
            comboItem27.FontStyle = FontStyle.Bold;

            comboBoxEx_Proc.Items.AddRange(new object[]
            {
                comboItem0,
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
                comboItem27
            });

            FWProcList();

            // clear out condition expressions
            comboBoxEx_CondEx.Items.Clear();

            // Dynamically allocate all needed items
            var comboItemx0 = new DevComponents.Editors.ComboItem();
            var comboItemx1 = new DevComponents.Editors.ComboItem();
            var comboItemx2 = new DevComponents.Editors.ComboItem();
            var comboItemx3 = new DevComponents.Editors.ComboItem();
            var comboItemx4 = new DevComponents.Editors.ComboItem();
            var comboItemx5 = new DevComponents.Editors.ComboItem();
            var comboItemx6 = new DevComponents.Editors.ComboItem();
            var comboItemx7 = new DevComponents.Editors.ComboItem();
            var comboItemx8 = new DevComponents.Editors.ComboItem();
            var comboItemx9 = new DevComponents.Editors.ComboItem();
            var comboItemx10 = new DevComponents.Editors.ComboItem();
            var comboItemx11 = new DevComponents.Editors.ComboItem();
            var comboItemx12 = new DevComponents.Editors.ComboItem();
            var comboItemx13 = new DevComponents.Editors.ComboItem();
            var comboItemx14 = new DevComponents.Editors.ComboItem();
            var comboItemx15 = new DevComponents.Editors.ComboItem();
            var comboItemx16 = new DevComponents.Editors.ComboItem();
            var comboItemx17 = new DevComponents.Editors.ComboItem();

            // setup item values
            comboItemx0.Text = Resources.Atk;
            comboItemx0.FontStyle = FontStyle.Bold;

            comboItemx1.Text = Resources.CastSkill;
            comboItemx1.FontStyle = FontStyle.Bold;

            comboItemx2.Text = Resources.Broadcast;
            comboItemx2.FontStyle = FontStyle.Bold;

            comboItemx3.Text = Resources.ResetAggro;
            comboItemx3.FontStyle = FontStyle.Bold;

            comboItemx4.Text = Resources.Exec_AS;
            comboItemx4.FontStyle = FontStyle.Bold;

            comboItemx5.Text = Resources.DisableAS;
            comboItemx5.FontStyle = FontStyle.Bold;

            comboItemx6.Text = Resources.EnableAS;
            comboItemx6.FontStyle = FontStyle.Bold;

            comboItemx7.Text = Resources.CreateTimer;
            comboItemx7.FontStyle = FontStyle.Bold;

            comboItemx8.Text = Resources.DelTimer;
            comboItemx8.FontStyle = FontStyle.Bold;

            comboItemx9.Text = Resources.Flee;
            comboItemx9.FontStyle = FontStyle.Bold;

            comboItemx10.Text = Resources.BeTaunted;
            comboItemx10.FontStyle = FontStyle.Bold;

            comboItemx11.Text = Resources.Unk + Resources.ONE + Resources.ONE;
            comboItemx11.FontStyle = FontStyle.Bold;

            comboItemx12.Text = Resources.FadeAggro;
            comboItemx12.FontStyle = FontStyle.Bold;

            comboItemx13.Text = Resources.Unk + Resources.ONE + Resources.THREE;
            comboItemx13.FontStyle = FontStyle.Bold;

            comboItemx14.Text = Resources.Trigger;
            comboItemx14.FontStyle = FontStyle.Bold;

            comboItemx15.Text = Resources.SumMob;
            comboItemx15.FontStyle = FontStyle.Bold;

            comboItemx16.Text = Resources.Unk + Resources.ONE + Resources.SIX;
            comboItemx16.FontStyle = FontStyle.Bold;

            comboItemx17.Text = Resources.SetPath;
            comboItemx17.FontStyle = FontStyle.Bold;

            // add created range to comboBox
            comboBoxEx_CondEx.Items.AddRange(new object[]
            {
                comboItemx0,
                comboItemx1,
                comboItemx2,
                comboItemx3,
                comboItemx4,
                comboItemx5,
                comboItemx6,
                comboItemx7,
                comboItemx8,
                comboItemx9,
                comboItemx10,
                comboItemx11,
                comboItemx12,
                comboItemx13,
                comboItemx14,
                comboItemx15,
                comboItemx16,
                comboItemx17
            });
        }

        private void ButtonItemMenuSaveClick(object sender, EventArgs e)
        {
            ButtonItemSaveClick(sender, e);
        }

        private void MainWindowLoad(object sender, EventArgs e)
        {
            ButtonItemJDClick(sender, e);
        }

        // Broadcast_Message "Editor"
        private void LabelXParam2Click(object sender, EventArgs e)
        {
            if (labelX_Param2.Text == Resources.Msg)
            {
                panelEx_Msg.Visible = true;
            }
        }

        private void ButtonXMsgOkClick(object sender, EventArgs e)
        {
            panelEx_Msg.Visible = false;
            var length = (textBoxX_Msg.TextLength * 2) + 2;
            textBoxX_Param1.Text = length.ToString(CultureInfo.InvariantCulture);
            textBoxX_Param2.Text = textBoxX_Msg.Text;
        }

        private void ButtonXMsgCancelClick(object sender, EventArgs e)
        {
            panelEx_Msg.Visible = false;
        }

        // Target "Editor"
        private void LabelXParamTargetClick(object sender, EventArgs e)
        {
            panelEx_Target.Visible = true;
        }

        private void ButtonXTOKClick(object sender, EventArgs e)
        {
            textBoxX_ParamTarget.Text = comboBoxEx_Target.Text;
            panelEx_Target.Visible = false;
        }

        private void ButtonXTCancelClick(object sender, EventArgs e)
        {
            panelEx_Target.Visible = false;
        }

        // Condition "Editor"
        private void LabelXClickMeClick(object sender, EventArgs e)
        {
            comboBoxEx_CondEx.Text = "";
            textBoxX_Exp.Text = "";
            Encode = "";
            panelEx_CondCalc.Visible = true;
        }

        private void ButtonXCondEdOKClick(object sender, EventArgs e)
        {
            // Clear Hint/Example
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
            // Transfer Encoded to textbox
            textBoxX_Condition.Text = Encode;
            panelEx_CondCalc.Visible = false;
        }

        private void ButtonXCondEdCancelClick(object sender, EventArgs e)
        {
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
            Encode = "";
            panelEx_CondCalc.Visible = false;
        }

        private void ComboBoxExCondEdSelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear Hint/Example
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
            // Set undo buffer
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            // Set condition in textbox
            textBoxX_Exp.Text += comboBoxEx_CondEx.Text;

            // Is_Timer_Ticking[x]
            if (comboBoxEx_CondEx.Text == Resources.IsTimerTicking)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.ITT1P;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.ITTEx;
                // Encode
                Encode += "a";
            }

            // Is_HP_Less[x]
            if (comboBoxEx_CondEx.Text == Resources.IsHPLess)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.IHPL1P;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.IHPLEx;
                // Encode
                Encode += "b";
            }

            // Is_Combat_Started[]
            if (comboBoxEx_CondEx.Text == Resources.IsCombatStarted)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.ICS;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.ICSEx;
                // Encode
                Encode += "c[]";
            }

            // Randomize[x]
            if (comboBoxEx_CondEx.Text == Resources.Randomize)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.R1P;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.R1PEx;
                // Encode
                Encode += "d";
            }
            // Is_Target_Dead[]
            if (comboBoxEx_CondEx.Text == Resources.IsTargetDead)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.ITD;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.ITDEx;
                // Encode
                Encode += "e[]";
            }

            // Is_Dead[]
            if (comboBoxEx_CondEx.Text == Resources.IsDead)
            {
                // Give Hint/Example
                labelX_Hint.Visible = true;
                labelX_HintText.Text = Resources.IDnoP;
                labelX_Example.Visible = true;
                labelX_ExampleText.Text = Resources.IDnoPEx;
                // Encode
                Encode += "h[]";
            }

            // Perfect World - Public_Counter[x]
            if (PWSelected)
            {
                if (comboBoxEx_CondEx.Text == Resources.PubCtr)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.PC1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.PC1PEx;
                    // Encode
                    Encode += "i";
                }

                // Perfect World - Value[0]
                if (comboBoxEx_CondEx.Text == Resources.Value)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.V1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.V1PEx;
                    // Encode
                    Encode += "j";
                }

                // Perfect World - Is_Event[]
                if (comboBoxEx_CondEx.Text == Resources.IsEvent)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.IE;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.IEEx;
                    // Encode
                    Encode += "k[]";
                }
            } // End Perfect World

            // Jade Dynasty
            if (JDSelected)
            {
                // Jade Dynasty - Path_To[0]
                if (comboBoxEx_CondEx.Text == Resources.PathTo)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.PT1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.PT1PEx;
                    // Encode
                    Encode += "i";
                }

                // Jade Dynasty - More_Than[0]
                if (comboBoxEx_CondEx.Text == Resources.MoreThan)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.MT1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.MT1PEx;
                    // Encode
                    Encode += "j";
                }

                // Jade Dynasty - Distance_To[0.00]
                if (comboBoxEx_CondEx.Text == Resources.DistanceTo)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.DT1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.DT1PEx;
                    // Encode
                    Encode += "k";
                }

                // Jade Dynasty - Unknown12[]
                if (comboBoxEx_CondEx.Text == Resources.Unk + Resources.ONE + Resources.TWO)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.U12;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.U12Ex;
                    // Encode
                    Encode += "l[]";
                }

                // Jade Dynasty - Unknown13[]
                if (comboBoxEx_CondEx.Text == Resources.Unk + Resources.ONE + Resources.THREE)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.U13;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.U13Ex;
                    // Encode
                    Encode += "m[]";
                }

                // Jade Dynasty - Unknown14[]
                if (comboBoxEx_CondEx.Text == Resources.Unk + Resources.ONE + Resources.FOUR)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.U14;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.U14Ex;
                    // Encode
                    Encode += "n[]";
                }

                // Jade Dynasty - Unknown15[]
                if (comboBoxEx_CondEx.Text == Resources.Unk + Resources.ONE + Resources.FIVE)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.U15;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.U15Ex;
                    // Encode
                    Encode += "o[]";
                }

                // Jade Dynasty - Variable_Value[0]
                if (comboBoxEx_CondEx.Text == Resources.VariableValue)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.VV1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.VV1PEx;
                    // Encode
                    Encode += "q";
                }

                // Jade Dynasty - Variable[0]
                if (comboBoxEx_CondEx.Text == Resources.Variable)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.Var1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.Var1PEx;
                    // Encode
                    Encode += "p";
                }

                // Jade Dynasty - Rank[0]
                if (comboBoxEx_CondEx.Text == Resources.Rank)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.Ra1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.Ra1PEx;
                    // Encode
                    Encode += "r";
                }

                // Jade Dynasty - NPC_Vent[0]
                if (comboBoxEx_CondEx.Text == Resources.NPCVent)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.NPCV;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.NPCVEx;
                    // Encode
                    Encode += "s[]";
                }

                // Jade Dynasty - Cast_Skill[0]
                if (comboBoxEx_CondEx.Text == Resources.CastSkill)
                {
                    // Give Hint/Example
                    labelX_Hint.Visible = true;
                    labelX_HintText.Text = Resources.CS1P;
                    labelX_Example.Visible = true;
                    labelX_ExampleText.Text = Resources.CS1PEx;
                    // Encode
                    Encode += "t";
                }
            }

            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        // Condition Keys
        private void ButtonXKey0Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.ZERO;
            Encode += Resources.ZERO;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey1Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.ONE;
            Encode += Resources.ONE;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey2Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.TWO;
            Encode += Resources.TWO;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey3Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.THREE;
            Encode += Resources.THREE;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey4Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.FOUR;
            Encode += Resources.FOUR;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey5Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.FIVE;
            Encode += Resources.FIVE;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey6Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.SIX;
            Encode += Resources.SIX;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey7Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.SEVEN;
            Encode += Resources.SEVEN;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey8Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.EIGHT;
            Encode += Resources.EIGHT;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKey9Click(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.NINE;
            Encode += Resources.NINE;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXLThanClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.LTHAN;
            Encode += Resources.LTHAN;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXMThanClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.MTHAN;
            Encode += Resources.MTHAN;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyLParenClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.LPAREN;
            Encode += Resources.LPAREN;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyRParenClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.RPAREN;
            Encode += Resources.RPAREN;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyLBracketClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.LBRACKET;
            Encode += Resources.LBRACKET;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyRBrackeyClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.RBRACKET;
            Encode += Resources.RBRACKET;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyORClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.OR;
            Encode += "f";
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyANDClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.AND;
            Encode += "g";
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyNOTClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.NOT;
            Encode += Resources.NOT;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyEqualsClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.EQUAL;
            Encode += Resources.EQUAL;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyPointClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.POINT;
            Encode += Resources.POINT;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyPlusClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.PLUS;
            Encode += Resources.PLUS;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyMinusClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.MINUS;
            Encode += Resources.MINUS;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }

        private void ButtonXKeyUndoClick(object sender, EventArgs e)
        {
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
            if (undoBuffer.CanUndo)
            {
                undoBuffer.Undo();
                encodeBuffer.Undo();
            }
            textBoxX_Exp.Text = undoBuffer.Value;
            Encode = encodeBuffer.Value;
        }

        private void ButtonXKeyClearClick(object sender, EventArgs e)
        {
            if (textBoxX_Exp.Text == "") return;
            while (undoBuffer.CanUndo)
            {
                undoBuffer.Undo();
                encodeBuffer.Undo();
            }
            textBoxX_Exp.Text = undoBuffer.Value;
            Encode = encodeBuffer.Value;
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
        }

        private void ButtonXKeyRedoClick(object sender, EventArgs e)
        {
            labelX_HintText.Text = "";
            labelX_Hint.Visible = false;
            labelX_ExampleText.Text = "";
            labelX_Example.Visible = false;
            if (undoBuffer.CanRedo)
            {
                undoBuffer.Redo();
                encodeBuffer.Redo();
            }
            textBoxX_Exp.Text = undoBuffer.Value;
            Encode = encodeBuffer.Value;
        }

        private void ButtonXSpaceClick(object sender, EventArgs e)
        {
            undoBuffer.SaveState();
            encodeBuffer.SaveState();
            textBoxX_Exp.Text += Resources.SPACE;
            Encode += Resources.SPACE;
            undoBuffer.Value = textBoxX_Exp.Text;
            encodeBuffer.Value = Encode;
        }
    }
}
