//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace _1091606.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TableCarts1091606
    {
        public int cartId { get; set; }
        public Nullable<int> tId { get; set; }
        public string sLogin { get; set; }
    
        public virtual TableStudents1091606 TableStudents1091606 { get; set; }
        public virtual TableTeachers1091606 TableTeachers1091606 { get; set; }
    }
}
