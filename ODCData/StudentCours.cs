//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ODCData
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentCours
    {
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public Nullable<int> ProjectDegree { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual Student Student { get; set; }
    }
}
