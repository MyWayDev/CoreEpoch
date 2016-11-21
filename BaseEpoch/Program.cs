using System;


using System.Linq;

using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.DataAccess;
using System.Data.Entity;


namespace BaseEpoch
{
   public class Program
    {
        static void Main()
        {
            #region Proof

            //    var promolist = new List<Promo>()
            //    {
            //     new Promo()
            //     {
            //         ProductId = "",
            //         Periods = new List<Period>()
            //         {
            //             new Period()
            //             {
            //                PeriodId = 1,
            //                StartDate =DateTime.Today,
            //                DimDates= new List<DimDate>()
            //                {
            //                    new DimDate()
            //                    {
            //                        PeriodId = 1,  
            //                    }
            //                }

            //             }   
            //         },
            //       PromoProducts = new List<PromoProduct>()
            //       {
            //         new PromoProduct()
            //         {
            //             PromoProductId = 1 ,
            //             PromoId = 1,
            //             ProductId = "",
            //             PromoPrice = 23.5f
            //         },
            //         new PromoProduct()
            //         {

            //             ProductId = "",
            //             PromoPrice = 23.5f 
            //         }

            //       }

            //     },

            //     new Promo()
            //     {

            //     },
            //     new Promo()
            //     {

            //     }
            //    };
            //    var p1 = new Promo();
            //    var p2 = new Promo();
            //    var list = new[] {p1, p2}.ToList();
            //    promolist.AddRange(list);



            //    promolist.AddRange(promolist);





            //    var ProductDto = new ProductDto()
            //    {
            //        ProductName = "shampoo",
            //        BasePrice = 23.5f,
            //        GroupId = 1,
            //        Promos = promolist, //{new Promo() {ProductId = "1099"}, new Promo() {ProductId = "2"}},
            //        PromoProducts = { new PromoProduct() { ProductId = "2020",Qty = 1,PromoPrice = 32.6F} },

            //    };
            //

            #endregion
           #region proof2

           /* var ProductDto = new ProductDto
            {
                Id = "123",
                ProductName = "Test",
                Type = ProductDto.ProductType.Sku,
                Active = true,
                AddDate = DateTime.Today,
                Booking = false,
                GroupId = 1,
                

                ProductPrices = new List<ProductPrice>()
                {
                    new ProductPrice
                    {
                        ProductId = "123",
                        Bp = 1,
                        Bv = 2.2f,
                        Price = 22.0f,
                        PriceId = 1,
                        Type = PriceType.BasePrice

                    },
                    new ProductPrice
                    {
                        ProductId = "123",
                        Bp = 2,
                        Bv = 1.2f,
                        Price = 32.0f,
                        PriceId = 2,
                        Type = PriceType.DiscountPrice
                    }
                },
                Promos = new List<Promo>()
                {
                    new Promo()
                    {
                        ProductId = "123",
                        PriceId = 3,
                        PromoGrade = PromoGrade.A,
                        PromoName = "wha'ver",
                        PromoType = PromoType.DiscountPrice,
                        ProductPrice = new ProductPrice
                        {
                            ProductId = "123",
                            Bp = 2,
                            Bv = 1.2f,
                            Price = 31.0f,
                            PriceId = 3,
                            Type = PriceType.DiscountPrice
                        },
                        PromoId = 3,
                        Period = new Period
                        {
                            PeriodId = 1,
                            PeriodDetails = new List<PeriodDetail>
                            {
                                new PeriodDetail
                                {
                                    Days = 1,
                                    PeriodDate = DateTime.Now
                                },
                                new PeriodDetail
                                {
                                    Days = 2,
                                    PeriodDate = DateTime.Now
                                }
                            }

                        },
                        PromoProducts = new List<PromoProduct>
                        {
                            new PromoProduct
                            {
                                ProductId = "555",
                                ProductPrice = new ProductPrice
                                {
                                    ProductId = "555",
                                    Bp = 2,
                                    Bv = 1.2f,
                                    Price = 31.0f,
                                    PriceId = 3,
                                    Type = PriceType.PromoPrice
                                },
                                ProductPriceId = 3

                            },
                            new PromoProduct
                            {
                                ProductId = "444",
                                ProductPrice = new ProductPrice
                                {
                                    ProductId = "444",
                                    Bp = 2,
                                    Bv = 1.2f,
                                    Price = 31.0f,
                                    PriceId = 3,
                                    Type = PriceType.PromoPrice
                                },
                                ProductPriceId = 3
                            }
                        }

                    }

                },
              



            };
            */
            #endregion

            var db = new DBC();
            var products = db.Products.Include(p=>p.ProductGroup).ToList();
            foreach (var item in products)
            {
                Console.WriteLine(item.Id+':'+item.ProductName+':'+item.ProductGroup.GroupName);
                
            }
            Console.ReadLine();
            //var q = db.ProductGroups.Select(g => new {g.GroupId, g.ProductTrees});

            //foreach (var I in q)

            //{
            //    Console.WriteLine(I.GroupId);
            //    foreach (var t in I.ProductTrees.ToString())
            //    {
            //        Console.WriteLine(t.ToString());
            //    }
            //    Console.Read();
            //}

        }
    }
}
