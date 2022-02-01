using System;

namespace Demo_Attributes {
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ReviewCommentAttribute : System.Attribute
    {
        public string Description { get; set; }
        public string VersionNumber { get; set; }
        public string ReviewerID { get; set; }
        public ReviewCommentAttribute(string desc, string ver)
        {
            Description = desc;
            VersionNumber = ver;
        }
    }

}
