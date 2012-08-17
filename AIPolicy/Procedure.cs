namespace AIPolicy
{
    internal class Procedure
    {
        public int Type;
        public object[] Parameter;
        public int Target;
        public object[] TargetParams = null;

        // string ProcedureTarget(int)
        public static string ProcedureTarget(int target)
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

        // 
    }
}
