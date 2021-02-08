using SalesRegisterWebAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesRegisterWebAPI.Domain.Models
{
    public class SalesRegister
    {
        public SalesRegister()
        {

        }
        public SalesRegister(DateTime createdOn, Seller seller, ICollection<Vehicle> vehicles)
        {
            this.CreatedOn = createdOn;
            this.Seller = seller;
            this.Vehicles = vehicles;
            this.Status = Enums.SalesStatus.PaymentPending;
        }

        [Key]
        public long IdSalesRegister { get; set; }
        [Required]
        public SalesStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public Seller Seller { get; set; }

        [Required]
        [MinLength(1)]
        public virtual ICollection<Vehicle> Vehicles { get; set; }        
    }
}
