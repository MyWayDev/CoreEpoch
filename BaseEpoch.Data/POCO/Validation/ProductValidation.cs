using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;


namespace BaseEpoch.Dtos
{
   public class BookingValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product) validationContext.ObjectInstance;

            //if(product.Discontnuied == true && product.Booking==true)
            //    return new ValidationResult("Can Not Book Discontuied ProductDto");
            
            //if(product.Booking==true && product.Type == Product.ProductType.NonSku)
            //     return new ValidationResult("Can Not Book Non Stock ProductDto");

            return ValidationResult.Success;
        }
    }
   public class NonSKUValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (Product)validationContext.ObjectInstance;

            //if (product.Discontnuied == true && product.Booking == true)
            //    return new ValidationResult("Can Not Book Discontuied ProductDto");

            //if (product.Booking == true && product.Type == Product.ProductType.NonSku)
            //    return new ValidationResult("Can Not Book Non Stock Poduct");

            return ValidationResult.Success;
        }
    }

}
