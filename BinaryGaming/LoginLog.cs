
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace BinaryGaming
{

using System;
    using System.Collections.Generic;
    
public partial class LoginLog
{

    public int Id { get; set; }

    public int MembersId { get; set; }

    public System.DateTime LoginDate { get; set; }

    public bool SuccessfulYN { get; set; }

    public string ErrorException { get; set; }

    public string ClientIpAddress { get; set; }



    public virtual Members Member { get; set; }

}

}
