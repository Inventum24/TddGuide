using System;

namespace NunitMoq.UnitTest
{
    public class Bar: IEquatable<Bar>
    {
        public string Name { get; set; }

        public bool Equals(Bar other)
        {
            if (ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this,other)) return true;
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;

            return Equals((Bar)obj);
        }
    }
}