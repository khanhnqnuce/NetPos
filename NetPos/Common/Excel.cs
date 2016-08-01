using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using FDI;
using FDI.Simple;
using Infragistics.Win.UltraWinGrid;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace NetPos
{
    public class Excel
    {
        public static void ExportToCard(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Order");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Mã KH",
                        "Số thẻ",
                        "Tên tài khoản",
                        "Số dư",
                        "Loại thẻ",
                        "Trạng thái",
                        "Ngày phát hành"
                    };
                worksheet.Cells["A1:H2"].Value = "DANH SÁCH THẺ";
                worksheet.Cells["A1:H2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:H2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:H2"].Style.Font.Bold = true;
                worksheet.Cells["A1:H2"].Style.Font.Size = 12;
                worksheet.Cells["A1:H2"].Merge = true;
                worksheet.Cells["A1:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:H2"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                var row = 3;
                for (var i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                row++;
                var stt = 1;
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt++;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, col].Value = item.Cells["CustomerID"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CustomerName"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Balance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["CardType"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardStatus"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["DateIssue"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                    row++;
                }
                //foreach (var item in report)
                //{
                //    var col = 1;
                //    worksheet.Cells[row, col].Value = stt++;
                //    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                //    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //    worksheet.Cells[row, col].Value = item.Code;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.CardNumber;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.AccountName;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.Balance;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.CardTypeCode;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.IsRelease;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.IsEdit;
                //    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                //    worksheet.Cells[row, col].Value = item.IsLockCard;
                //    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                //    row++;
                //}
                var nameexcel = "Danh sách thẻ" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void ExportToReportCardDetail(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Order");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Mã thẻ",
                        "Thời gian",
                        "Thanh toán",
                        "Số dư tài khoản",
                        "Miêu tả",
                        "Tên tài khoản",
                        "Loại thẻ",
                        "Tòa nhà",
                        "Khu vực",
                        "Nhân viên bán thẻ"
                    };
                worksheet.Cells["A1:K2"].Value = "BÁO CÁO DOANH THU CHI TIẾT";
                worksheet.Cells["A1:K2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:K2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:K2"].Style.Font.Bold = true;
                worksheet.Cells["A1:K2"].Style.Font.Size = 14;
                worksheet.Cells["A1:K2"].Merge = true;
                worksheet.Cells["A1:K2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:K2"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                var row = 3;
                for (var i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                row++;
                var stt = 1;
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt++;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Date"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Balance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Action"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["AccountName"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardType"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Buiding"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Area"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["UserName"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                    row++;
                }
                var nameexcel = "Bao cao doanh thu chi tiet" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void ExportToTalCard(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Order");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Mô Tả",
                        "Tổng số thẻ",
                        "Tổng số thẻ đã phát hành - T",
                        "Tổng số thẻ còn lại - R",
                        "Tổng số thẻ đã khóa",
                        "Số dư tài khoản"
                    };
                worksheet.Cells["A1:G2"].Value = "Thống kê thẻ";
                worksheet.Cells["A1:G2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:G2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:G2"].Style.Font.Bold = true;
                worksheet.Cells["A1:G2"].Style.Font.Size = 14;
                worksheet.Cells["A1:G2"].Merge = true;
                worksheet.Cells["A1:G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:G2"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                var row = 3;
                for (var i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                row++;
                var stt = 1;
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt++;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, col].Value = item.Cells["NameType"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["TotalCard"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "0";

                    worksheet.Cells[row, col].Value = item.Cells["TotalUsed"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "0";

                    worksheet.Cells[row, col].Value = item.Cells["TotalNotUsed"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "0";

                    worksheet.Cells[row, col].Value = item.Cells["TotalBlock"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["TotalBalance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "#,##";
                    row++;
                }
                var nameexcel = "Thong ke the" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void BCDoanhThuBanThe(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("DTBT");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Loại thống kê",
                        "Giá trị"
                    };
                worksheet.Cells["A1:I2"].Value = "BÁO CÁO DOANH THU BÁN THẺ";
                worksheet.Cells["A1:I2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:I2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:I2"].Style.Font.Bold = true;
                worksheet.Cells["A1:I2"].Style.Font.Size = 12;
                worksheet.Cells["A1:I2"].Merge = true;
                worksheet.Cells["A1:I2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:I2"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                var row = 3;
                for (var i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                row++;
                var stt = 1;
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt++;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, col].Value = item.Cells["Name"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "#,##";

                    row++;
                }
                var nameexcel = "doanh thu ban the" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void BCDoanhThuBanHang(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("DTBT");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Thông tin",
                        "Giá trị"
                    };
                worksheet.Cells["A1:I2"].Value = "BÁO CÁO DOANH THU BÁN THẺ";
                worksheet.Cells["A1:I2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:I2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:I2"].Style.Font.Bold = true;
                worksheet.Cells["A1:I2"].Style.Font.Size = 12;
                worksheet.Cells["A1:I2"].Merge = true;
                worksheet.Cells["A1:I2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1:I2"].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);

                var row = 3;
                for (var i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                row++;
                var stt = 1;
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt++;
                    worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    worksheet.Cells[row, col].Value = item.Cells["Name"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "#,##";

                    row++;
                }
                var nameexcel = "doanh_thu_ban_the_" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }


        public static void ChiTietThe(string filePath, CustomerItem customerItem, UltraGrid grid, string starDate, string endDate)
        {
            try
            {


                var newFile = new FileInfo(filePath);
                using (var xlPackage = new ExcelPackage(newFile))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add("Chi tiet the");
                    xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                    var properties = new[]
                    {
                        "STT",
                        "Miêu tả",
                        "Thời gian",
                        "Thanh toán",
                        "Đối tượng"
                    };
                    worksheet.Cells["A2:B2"].Value = "Mã khách hàng:";
                    worksheet.Cells["A2:B2"].Merge = true;
                    worksheet.Cells["C2"].Value = customerItem.CustomerID;

                    worksheet.Cells["A3:B3"].Value = "Tên khách hàng:";
                    worksheet.Cells["A3:B3"].Merge = true;
                    worksheet.Cells["C3"].Value = customerItem.CustomerName;

                    worksheet.Cells["A4:B4"].Value = "Ngày sinh:";
                    worksheet.Cells["A4:B4"].Merge = true;
                    worksheet.Cells["C4"].Value = customerItem.BirthDate;

                    worksheet.Cells["A5:B5"].Value = "Năm học:";
                    worksheet.Cells["A5:B5"].Merge = true;
                    worksheet.Cells["C5"].Value = customerItem.SchoolYear;

                    worksheet.Cells["A6:B6"].Value = "Lớp:";
                    worksheet.Cells["A6:B6"].Merge = true;
                    worksheet.Cells["C6"].Value = customerItem.CustomerClass;

                    worksheet.Cells["E2:F2"].Value = "Mã thẻ:";
                    worksheet.Cells["E2:F2"].Merge = true;
                    worksheet.Cells["G2"].Value = customerItem.CardNumber;

                    worksheet.Cells["E3:F3"].Value = "Số dư:";
                    worksheet.Cells["E3:F3"].Merge = true;
                    worksheet.Cells["G3"].Value = customerItem.Balance;
                    worksheet.Cells["G3"].Style.Numberformat.Format = "#,##";

                    worksheet.Cells["E4:F4"].Value = "Loại thẻ:";
                    worksheet.Cells["E4:F4"].Merge = true;
                    worksheet.Cells["G4"].Value = customerItem.CardType;

                    worksheet.Cells["E5:F5"].Value = "Trạng thái:";
                    worksheet.Cells["E5:F5"].Merge = true;
                    worksheet.Cells["G5"].Value = customerItem.CardStatus;

                    worksheet.Cells["E6:F6"].Value = "Ngày phát hành:";
                    worksheet.Cells["E6:F6"].Merge = true;
                    worksheet.Cells["G6"].Value = customerItem.DateIssue;

                    worksheet.Cells["A8:G8"].Value = "CÁC GIAO DỊCH";
                    worksheet.Cells["A8:G8"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A8:G8"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    worksheet.Cells["A8:G8"].Style.Font.Bold = true;
                    worksheet.Cells["A8:G8"].Style.Font.Size = 12;
                    worksheet.Cells["A8:G8"].Merge = true;
                    worksheet.Cells["A8:G8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    
                    worksheet.Cells["A9:G9"].Value = "("+ starDate + " - " + endDate + ")";
                    worksheet.Cells["A9:G9"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells["A9:G9"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                    worksheet.Cells["A9:G9"].Style.Font.Italic = true;
                    worksheet.Cells["A9:G9"].Merge = true;
                    worksheet.Cells["A9:G9"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    var row = 11;
                    for (var i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[row, i + 1].Value = properties[i];
                        worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                        worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                        worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    }
                    worksheet.Cells[row, 1, row, properties.Length].AutoFilter = true;
                    row++;
                    var stt = 1;
                    foreach (var item in grid.Rows)
                    {
                        var col = 1;
                        worksheet.Cells[row, col].Value = stt++;
                        worksheet.Cells[row, col].Style.Numberformat.Format = "0";
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        worksheet.Cells[row, col].Value = item.Cells["Event"].Text;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                        worksheet.Cells[row, col].Value = item.Cells["Date"].Text;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                        worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                        worksheet.Cells[row, col].Value = item.Cells["Object"].Value;
                        worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                        worksheet.Cells[row, col].Style.Numberformat.Format = "@";

                        row++;
                    }
                    var nameexcel = "Chi_tiet_the_" + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
                    xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                    xlPackage.Workbook.Properties.Author = "Admin-IT";
                    xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                    xlPackage.Workbook.Properties.Category = "Report Manager";
                    xlPackage.Workbook.Properties.Company = "Report Manager";
                    xlPackage.Save();
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

    }
}
