//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PS.HireRocks.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class MessageLabel
    {
        public MessageLabel()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public long MessageLabelId { get; set; }
        public string LabelName { get; set; }
    
        public virtual ICollection<Message> Messages { get; set; }
    }
}
