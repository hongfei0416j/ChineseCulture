//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChineseCulture.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class MemberLoginLog
    {
        public int mll_id { get; set; }
        public int member_id { get; set; }
        public string password { get; set; }
        public System.DateTime kdate { get; set; }
        public string ip { get; set; }
        public string browser { get; set; }
    }
}