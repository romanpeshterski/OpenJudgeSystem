//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OJS.Tools.OldDatabaseMigration
{
    using System;
    using System.Collections.Generic;
    
    public partial class BugReport
    {
        public int Id { get; set; }
        public Nullable<int> User { get; set; }
        public System.DateTime Time { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public bool Fixed { get; set; }
    
        public virtual User User1 { get; set; }
    }
}
