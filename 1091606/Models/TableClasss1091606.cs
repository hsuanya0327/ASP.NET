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
    
    public partial class TableClasss1091606
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableClasss1091606()
        {
            this.TableTeachers1091606 = new HashSet<TableTeachers1091606>();
        }
    
        public int cId { get; set; }
        public string cName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableTeachers1091606> TableTeachers1091606 { get; set; }
    }
}
