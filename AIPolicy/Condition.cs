namespace AIPolicy
{
    internal class Condition
    {
        public int OperID;
        public int ArgBytes;
        public byte[] Value;
        public int ConditionType;
        public Condition ConditionLeft;
        public int SubNodeL;
        public Condition ConditionRight;
        public int SubNodeR;
    }
}
