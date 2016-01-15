using System.ComponentModel;

namespace WebGridExample.Query
{
    public class ConditionType: Enumeration
    {
        public static readonly ConditionType Equal = new ConditionType(0, "Equals", "==");
        public static readonly ConditionType NotEquals = new ConditionType(1, "Does Not Equal", "!=");
        public static readonly ConditionType Contains = new ConditionType(2, "Contains", "");
        public static readonly ConditionType NotContains = new ConditionType(3, "Does Not Contain", "");
        public static readonly ConditionType LessThan = new ConditionType(4, "Less Than", "<");
        public static readonly ConditionType LessThanOrEqualTo = new ConditionType(5, "Less Than Or Equal To", "<=");
        public static readonly ConditionType MoreThan = new ConditionType(6, "More Than", ">");
        public static readonly ConditionType MoreThanOrEqualTo = new ConditionType(7, "More Than Or Equal To", ">=");
        public static readonly ConditionType Between = new ConditionType(8, "Between", "");
        public static readonly ConditionType NotBetween = new ConditionType(9, "Not Between", "");


        public ConditionType() { }

        private ConditionType(int index, string displayName, string value): base(index, displayName, value) {}
    }
}