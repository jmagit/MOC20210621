﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Curso.Domain.Entities
{
    [Table("Customer", Schema = "SalesLT")]
    [Index(nameof(Rowguid), Name = "AK_Customer_rowguid", IsUnique = true)]
    [Index(nameof(EmailAddress), Name = "IX_Customer_EmailAddress")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        public bool NameStyle { get; set; }
        [StringLength(8)]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string Suffix { get; set; }
        [StringLength(128)]
        public string CompanyName { get; set; }
        [StringLength(256)]
        public string SalesPerson { get; set; }
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [StringLength(25)]
        public string Phone { get; set; }
        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }
        [Required]
        [StringLength(10)]
        public string PasswordSalt { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty(nameof(CustomerAddress.Customer))]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        [InverseProperty(nameof(SalesOrderHeader.Customer))]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
