using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Report;
using ResortApi.interfaces;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Models.OrderAggregate;

namespace ShopSuphan.Services
{
    public class ReportService : IReportService
    {
        private readonly DatabaseContext databaseContext;
        public ReportService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private static float DateBooking(DateTime checkIn, DateTime checkOut)
        {
            TimeSpan date = checkOut - checkIn;
            var sumdate = date.Days;

            return sumdate;
        }
        ////// Report Product
        public async Task<List<ProductStatisticsDTO>> ProductStatistics()
        {
            List<ProductStatisticsDTO> ProductStatistics = new();
            List<OrderItem> orderItems = new();
            var orders = await databaseContext.Orders.ToListAsync();
            foreach (var order in orders)
            {
                 var items = databaseContext.OrderItems.Where(e => e.OrderId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);
            };
            foreach (var item in orderItems)
            {
                var product = await databaseContext.FoodDrinks.AsNoTracking().FirstOrDefaultAsync(e => e.FdId == item.FdId);
                if (product is not null)
                {
                    var checkProduct = ProductStatistics.FirstOrDefault(e => e.Product.FdId == product.FdId);
                    if (checkProduct is null)
                        ProductStatistics.Add(new ProductStatisticsDTO { Amount = item.Amount, Product = product });
                    else checkProduct.Amount += item.Amount;
                };
            };
            var sum = ProductStatistics.Sum(e => e.Amount);
            foreach (var item in ProductStatistics) item.NumPercen = item.Amount * 100 / sum;
            return ProductStatistics;
        }

        ////// Report Accmd
        public async Task<List<AccmdStatisticsDTO>> AccmdStatistics()
        {
            List<AccmdStatisticsDTO> ProductStatistics = new();
            List<HBOrderItem> orderItems = new();
            var orders = await databaseContext.HBOrders.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.HBOrderItems.Where(e => e.HBOrderId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);
            };
            foreach (var item in orderItems)
            {
                var product = await databaseContext.Accommodations.AsNoTracking().FirstOrDefaultAsync(e => e.AccommodationId == item.AccommodationId);
                if (product is not null)
                {
                    var checkProduct = ProductStatistics.FirstOrDefault(e => e.Accmd.AccommodationId == product.AccommodationId);
                    if (checkProduct is null)
                        ProductStatistics.Add(new AccmdStatisticsDTO { Amount = DateBooking(item.CheckIn, item.CheckOut), Accmd = product });
                    else checkProduct.Amount += DateBooking(item.CheckIn, item.CheckOut);
                };
            };
            var sum = ProductStatistics.Sum(e => e.Amount);
            foreach (var item in ProductStatistics) item.NumPercen = item.Amount * 100 / sum;
            return ProductStatistics;
        }

        ////// Report Serve
        public async Task<List<ServeStatisticsDTO>> ServeStatistics()
        {
            List<ServeStatisticsDTO> ProductStatistics = new();
            List<ServeOrderItem> orderItems = new();
            var orders = await databaseContext.ServeOrders.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.ServeOrdersItem.Where(e => e.ServeOrderId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);
            };
            foreach (var item in orderItems)
            {
                var product = await databaseContext.Services.AsNoTracking().FirstOrDefaultAsync(e => e.ServeId == item.ServeId);
                if (product is not null)
                {
                    var checkProduct = ProductStatistics.FirstOrDefault(e => e.Serve.ServeId == product.ServeId);
                    if (checkProduct is null)
                        ProductStatistics.Add(new ServeStatisticsDTO { Amount = item.Amount, Serve = product });
                    else checkProduct.Amount += item.Amount;
                };
            };
            var sum = ProductStatistics.Sum(e => e.Amount);
            foreach (var item in ProductStatistics) item.NumPercen = item.Amount * 100 / sum;
            return ProductStatistics;
        }
        
        
        /// product
        public async Task<SalesStatisticsDTO> SalesStatistics()
        {
            SalesStatisticsDTO salesStatisticsDTO = new();
            List<OrderItem> orderItems = new();
            var orders = await databaseContext.Orders.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.OrderItems.Where(e => e.OrderId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);


                var result = salesStatisticsDTO.Sales.Find(x => x.Month == order.CreateDate.Value.Month && x.Year == order.CreateDate.Value.Year);
                if (result == null)
                {
                    salesStatisticsDTO.Sales.Add(new SalesStatisticeItemDTO
                    {
                        price = order.Total,
                        FullTime = order.CreateDate,
                        Day = order.CreateDate.Value.Day,
                        Month = order.CreateDate.Value.Month,
                        Year = order.CreateDate.Value.Year
                    });
                }
                else result.price += order.Total;
            };


            salesStatisticsDTO.TotalPrice = salesStatisticsDTO.Sales.Sum(e => e.price);
            foreach (var item in salesStatisticsDTO.Sales)
            {
                var Percen = item.price * 100 / salesStatisticsDTO.TotalPrice;
                item.percent = Percen;
            }
            salesStatisticsDTO.Sales = salesStatisticsDTO.Sales.OrderByDescending(e => e.Month).ToList();


            return salesStatisticsDTO;

        }

        /// accmd
        public async Task<SalesStatisticsDTO> AccmdSalesStatistics()
        {
            SalesStatisticsDTO salesStatisticsDTO = new();
            List<HBOrderItem> orderItems = new();
            var orders = await databaseContext.HBOrders.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.HBOrderItems.Where(e => e.HBOrderId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);


                var result = salesStatisticsDTO.Sales.Find(x => x.Month == order.CreateDate.Value.Month && x.Year == order.CreateDate.Value.Year);
                if (result == null)
                {
                    salesStatisticsDTO.Sales.Add(new SalesStatisticeItemDTO
                    {
                        price = order.Total,
                        FullTime = order.CreateDate,
                        Day = order.CreateDate.Value.Day,
                        Month = order.CreateDate.Value.Month,
                        Year = order.CreateDate.Value.Year
                    });
                }
                else result.price += order.Total;
            };


            salesStatisticsDTO.TotalPrice = salesStatisticsDTO.Sales.Sum(e => e.price);
            foreach (var item in salesStatisticsDTO.Sales)
            {
                var Percen = item.price * 100 / salesStatisticsDTO.TotalPrice;
                item.percent = Percen;
            }
            salesStatisticsDTO.Sales = salesStatisticsDTO.Sales.OrderByDescending(e => e.Month).ToList();


            return salesStatisticsDTO;

        }

        /// serve
        public async Task<SalesStatisticsDTO> ServeSalesStatistics()
        {
            SalesStatisticsDTO salesStatisticsDTO = new();
            List<ServeOrderItem> orderItems = new();
            var orders = await databaseContext.ServeOrders.ToListAsync();
            foreach (var order in orders)
            {
                var items = databaseContext.ServeOrdersItem.Where(e => e.ServeId.Equals(order.Id)).ToList();
                if (items?.Count() > 0)
                    orderItems.AddRange(items);


                var result = salesStatisticsDTO.Sales.Find(x => x.Month == order.CreateDate.Value.Month && x.Year == order.CreateDate.Value.Year);
                if (result == null)
                {
                    salesStatisticsDTO.Sales.Add(new SalesStatisticeItemDTO
                    {
                        price = order.Total,
                        FullTime = order.CreateDate,
                        Day = order.CreateDate.Value.Day,
                        Month = order.CreateDate.Value.Month,
                        Year = order.CreateDate.Value.Year
                    });
                }
                else result.price += order.Total;
            };


            salesStatisticsDTO.TotalPrice = salesStatisticsDTO.Sales.Sum(e => e.price);
            foreach (var item in salesStatisticsDTO.Sales)
            {
                var Percen = item.price * 100 / salesStatisticsDTO.TotalPrice;
                item.percent = Percen;
            }
            salesStatisticsDTO.Sales = salesStatisticsDTO.Sales.OrderByDescending(e => e.Month).ToList();


            return salesStatisticsDTO;

        }
    }
}
