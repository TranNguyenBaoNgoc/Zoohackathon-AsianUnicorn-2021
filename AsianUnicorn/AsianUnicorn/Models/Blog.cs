//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AsianUnicorn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int BlogID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Author { get; set; }
        public Nullable<int> Category_BlogID { get; set; }
        public Nullable<int> TagID { get; set; }
    
        public virtual Category_Blog Category_Blog { get; set; }
        public virtual Blog_Tag Blog_Tag { get; set; }
    }
}
