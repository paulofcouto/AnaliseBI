using AnaliseBI.Application.Entities;
using AnaliseBI.Infrastructure.MySql;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;


namespace AnaliseBI.Application.Services
{
    public class SaleService
    {
        private readonly SaleRepository _saleRepository;

        public SaleService(SaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IEnumerable<SaleModel> GetAll()
        {
            return _saleRepository.GetAll();
        }

        public async Task ProcessFile()
        {
            string originDirectoryPath = "../ftp/";

            string processedFilesPath = "../AnaliseBI/ArquivosProcessados/";

            string[] files = Directory.GetFiles(originDirectoryPath, "*.xlsx");

            foreach (string file in files)
            {
                await ProcessFileAsync(file);

                //string fileName = Path.GetFileName(file);
                //File.Move(file, Path.Combine(processedFilesPath, fileName));
            }
        }

        private async Task ProcessFileAsync(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;

                var sales = new List<SaleModel>();

                for (int row = 2; row <= rows; row++)
                {
                    var sale = new SaleModel
                    {
                        OrderID = worksheet.Cells[row, 2].GetValue<string>(),
                        OrderDate = worksheet.Cells[row, 3].GetValue<DateTime>(),
                        ShipDate = worksheet.Cells[row, 4].GetValue<DateTime>(),
                        ShipMode = worksheet.Cells[row, 5].GetValue<string>(),
                        CustomerID = worksheet.Cells[row, 6].GetValue<string>(),
                        CustomerName = worksheet.Cells[row, 7].GetValue<string>(),
                        CustomerAge = worksheet.Cells[row, 8].GetValue<int>(),
                        CustomerBirthday = new DateTime(1, int.Parse(worksheet.Cells[row, 9].GetValue<string>().Split('-')[0]), int.Parse(worksheet.Cells[row, 9].GetValue<string>().Split('-')[1])),
                        CustomerState = worksheet.Cells[row, 10].GetValue<string>(),
                        Segment = worksheet.Cells[row, 11].GetValue<string>(),
                        Country = worksheet.Cells[row, 12].GetValue<string>(),
                        City = worksheet.Cells[row, 13].GetValue<string>(),
                        State = worksheet.Cells[row, 14].GetValue<string>(),
                        RegionalManagerID = worksheet.Cells[row, 15].GetValue<string>(),
                        RegionalManager = worksheet.Cells[row, 16].GetValue<string>(),
                        PostalCode = worksheet.Cells[row, 17].GetValue<string>(),
                        Region = worksheet.Cells[row, 18].GetValue<string>(),
                        ProductID = worksheet.Cells[row, 19].GetValue<string>(),
                        Category = worksheet.Cells[row, 20].GetValue<string>(),
                        SubCategory = worksheet.Cells[row, 21].GetValue<string>(),
                        ProductName = worksheet.Cells[row, 22].GetValue<string>(),
                        Sales = worksheet.Cells[row, 23].GetValue<decimal>(),
                        Quantity = worksheet.Cells[row, 24].GetValue<int>(),
                        Discount = worksheet.Cells[row, 25].GetValue<decimal>(),
                        Profit = worksheet.Cells[row, 26].GetValue<decimal>()
                    };

                    sales.Add(sale);
                }

                // Salva os dados no banco de dados
                await _saleRepository.AddSales(sales);
            }
        }
    }
}
