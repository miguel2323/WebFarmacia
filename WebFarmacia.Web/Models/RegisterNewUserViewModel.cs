namespace WebFarmacia.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
public class RegisterNewUserViewModel
{
    [Required]
    [Display(Name="First name")]
    public string FirstName{get;set;}

    [Required]
    [Display(Name="last name")]
    public string LastName{get;set;}


    [Required]
    [DataType(DataType.EmailAddress)]
    public string Username{get;set;}

    [Required]
   [MaxLength(6)]
    public string Password{get;set;}


[Required]
   [Compare("Password")]
    public string Confirm{get;set;}



}








}