using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseAccessManagement.SQLPredicate
{
	interface SQLPredicate
    {
		String toString();
    }

    abstract class CompositePredicate : SQLPredicate
    {
        protected SQLPredicate leftMember;
        protected SQLPredicate rightMember;


        public CompositePredicate(SQLPredicate leftMember, SQLPredicate rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public abstract String toString();

    }

    class AndPredicate : CompositePredicate
    {
        public AndPredicate(SQLPredicate leftMember, SQLPredicate rightMember) : base(leftMember, rightMember) { }
        public override string toString()
        {
            return "( "+leftMember.toString() + " AND " + rightMember.toString()+" )";
        } 
    }

    class OrPredicate : CompositePredicate
    {
        public OrPredicate(SQLPredicate leftMember, SQLPredicate rightMember) : base(leftMember, rightMember) { }
        public override string toString()
        {
            return "( " + leftMember.toString() + " OR " + rightMember.toString() + " )";
        }
    }
    interface AtomicPredicate : SQLPredicate
    {
    }

    /*class ExistPredicate : AtomicPredicate
    {
        private SQLPredicate rightMember;
        public ExistPredicate(SQLPredicate rightMember)
        {
            this.rightMember = rightMember;
        }

        public String toString()
        {
            return "EXISTS " +"( "+ rightMember.toString() +" )";
        }
    }*/

    class LessThanPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public LessThanPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " < " + rightMember;
        }
    }

    class LessThanOrEqualPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public LessThanOrEqualPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " < " + rightMember;
        }
    }

    class EqualToPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public EqualToPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " = " + rightMember;
        }
    }

    class NotEqualToPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public NotEqualToPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " != " + rightMember;
        }
    }

    class GreaterThanPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public GreaterThanPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " > " + rightMember;
        }
    }

    class GreaterThanOrEqualPredicate : AtomicPredicate
    {
        private String leftMember;
        private String rightMember;
        public GreaterThanOrEqualPredicate(String leftMember, String rightMember)
        {
            this.leftMember = leftMember;
            this.rightMember = rightMember;
        }
        public String toString()
        {
            return leftMember + " >= " + rightMember;
        }
    }
}
