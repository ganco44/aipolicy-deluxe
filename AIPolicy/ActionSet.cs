using System;
using System.Text;

namespace AIPolicy
{
    internal class ActionSet
    {
        public int Version;
        public int ID;
        public byte[] Flags;
        public byte[] ActionSetName;
        public Condition Condition;
        public int ProcedureCount;
        public Procedure[] Procedure;
        public string Name
        {
            get
            {
                var encoding = Encoding.GetEncoding("GBK");
                return encoding.GetString(ActionSetName);
            }
            set
            {
                var encoding = Encoding.GetEncoding("GBK");
                var array = new byte[128];
                var bytes = encoding.GetBytes(value);
                if (array.Length > bytes.Length)
                    Array.Copy(bytes, array, bytes.Length);
                else
                {
                    Array nameStr1 = bytes;
                    var nameStr2 = array;
                    Array.Copy(nameStr1, nameStr2, nameStr2.Length);
                }
                ActionSetName = array;
            }
        }
    }
}
