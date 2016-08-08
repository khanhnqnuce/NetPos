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
                        "Mã thẻ",
                        "Tên KH",
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

                var row = 4;
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

                    worksheet.Cells[row, col].Value = item.Cells["DateIssue"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                    row++;
                }
                var nameexcel = "Danh sách thẻ" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void ExportTKThe(string filePath, UltraGrid grid)
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
                        "Mã thẻ",
                        "Tên KH",
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

                var row = 4;
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

                    worksheet.Cells[row, col].Value = item.Cells["DateIssue"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                    row++;
                }
                var nameexcel = "Danh sách thẻ" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void ExportToCardBackList(string filePath, UltraGrid grid)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Order");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Thời gian",
                        "Mã thẻ",
                        "Trạng thái",
                        "Mã KH",
                        "Lớp",
                        "Tên KH",
                        "Loại thẻ",
                        "Năm học",
                        "Mô tả"
                    };
                worksheet.Cells["A1:J2"].Value = "DANH SÁCH THẺ ĐEN";
                worksheet.Cells["A1:J2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:J2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:J2"].Style.Font.Bold = true;
                worksheet.Cells["A1:J2"].Style.Font.Size = 12;
                worksheet.Cells["A1:J2"].Merge = true;
                worksheet.Cells["A1:J2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var row = 4;
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

                    worksheet.Cells[row, col].Value = item.Cells["Date"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardStatus"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CustomerID"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CustomerClass"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CustomerName"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardType"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["SchoolYear"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Desc"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";
                    row++;
                }
                var nameexcel = "Danh sách thẻ đen" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
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
                var worksheet = xlPackage.Workbook.Worksheets.Add("GiaoDich");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Thời gian",
                        "Mã thẻ",
                        "Loại giao dịch",
                        "Số tiền",
                        "Đối tượng",
                        "Khu vục"
                    };
                worksheet.Cells["A1:G2"].Value = "CHI TIẾT GIAO DỊCH";
                worksheet.Cells["A1:G2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A1:G2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A1:G2"].Style.Font.Bold = true;
                worksheet.Cells["A1:G2"].Style.Font.Size = 14;
                worksheet.Cells["A1:G2"].Merge = true;
                worksheet.Cells["A1:G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                var row = 4;
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

                    worksheet.Cells[row, col].Value = item.Cells["Date"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Event"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Object"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Area"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
                    row++;
                }
                var nameexcel = "tong giao dich" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
                xlPackage.Workbook.Properties.Author = "Admin-IT";
                xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
                xlPackage.Workbook.Properties.Category = "Report";
                xlPackage.Workbook.Properties.Company = "NetPos";
                xlPackage.Save();
            }
        }

        public static void ExportToTalCard(string filePath, UltraGrid grid, UltraGrid grid1)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("TKT");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "",
                        "Tổng số thẻ",
                        "Tổng số thẻ đã phát hành - T",
                        "Tổng số thẻ còn lại - R",
                        "Tổng số thẻ đã khóa",
                        "Số dư tài khoản"
                    };

                var row = 2;
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
                foreach (var item in grid.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = item.Cells["NameType"].Text;
                    worksheet.Cells[row, col].Style.Font.Bold = true;
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

                // chi tiết
                row++;
                var properties1 = new[]
                    {
                        "STT",
                        "Mã KH",
                        "Mã thẻ",
                        "Tên KH",
                        "Số dư",
                        "Loại thẻ",
                        "Trạng thái",
                        "Ngày phát hành"
                    };
                worksheet.Cells["A" + row + ":H" + row].Value = "DANH SÁCH THẺ";
                worksheet.Cells["A" + row + ":H" + row].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A" + row + ":H" + row].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A" + row + ":H" + row].Style.Font.Bold = true;
                worksheet.Cells["A" + row + ":H" + row].Style.Font.Size = 12;
                worksheet.Cells["A" + row + ":H" + row].Merge = true;
                worksheet.Cells["A" + row + ":H" + row].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                row++;
                for (var i = 0; i < properties1.Length; i++)
                {
                    worksheet.Cells[row, i + 1].Value = properties1[i];
                    worksheet.Cells[row, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[row, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
                    worksheet.Cells[row, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[row, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                worksheet.Cells[row, 1, row, properties1.Length].AutoFilter = true;
                row++;
                var stt1 = 1;
                foreach (var item in grid1.Rows)
                {
                    var col = 1;
                    worksheet.Cells[row, col].Value = stt1++;
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

                    worksheet.Cells[row, col].Value = item.Cells["DateIssue"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";
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

        public static void BCDoanhThuBanThe(string filePath, UltraGrid grid, ModelItem modelItem, List<ThongKeItem> lst)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("DTBT");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Thời gian",
                        "Mã HS",
                        "Mã thẻ",
                        "Loại giao dịch",
                        "Số tiền",
                        "Số dư",
                        "Đối tượng",
                        "Khu vực"
                    };
                worksheet.Cells["A2:I2"].Value = "BÁO CÁO DOANH THU BÁN THẺ";
                worksheet.Cells["A2:I2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A2:I2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A2:I2"].Style.Font.Bold = true;
                worksheet.Cells["A2:I2"].Style.Font.Size = 12;
                worksheet.Cells["A2:I2"].Merge = true;
                worksheet.Cells["A2:I2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3:H3"].Value = string.Format("({0} - {1})", modelItem.StartDate.Value.ToString("dd/MM/yyyy"), modelItem.EndDate.Value.ToString("dd/MM/yyyy"));
                worksheet.Cells["A3:H3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A3:H3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A3:H3"].Style.Font.Italic = true;
                worksheet.Cells["A3:H3"].Merge = true;
                worksheet.Cells["A3:H3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A5:B5"].Value = "Đơn vị:";
                worksheet.Cells["C5:D5"].Value = modelItem.BuidingName;
                worksheet.Cells["A6:B6"].Value = "Khu vực:";
                worksheet.Cells["C5:D5"].Value = modelItem.AreaName;
                worksheet.Cells["A7:B7"].Value = "Đầu đọc thẻ:";
                worksheet.Cells["C5:D5"].Value = modelItem.ObjectName;
                worksheet.Cells["A5:B5"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;
                worksheet.Cells["A6:B6"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;
                worksheet.Cells["A7:B7"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;

                worksheet.Cells["A9:C9"].Value = "Tổng số thẻ đã phát hành:";
                worksheet.Cells["A9:C9"].Style.Font.Bold = true;
                worksheet.Cells["A9:C9"].Merge = true;
                worksheet.Cells["D9:E9"].Value = lst[0].Value;
                worksheet.Cells["D9:E9"].Merge = true;

                worksheet.Cells["A10:C10"].Value = "Tổng số tiền đã nạp:";
                worksheet.Cells["A10:C10"].Style.Font.Bold = true;
                worksheet.Cells["A10:C10"].Merge = true;
                worksheet.Cells["D10:E10"].Value = lst[1].Value;
                worksheet.Cells["D10:E10"].Style.Numberformat.Format = "#,##";
                worksheet.Cells["D10:E10"].Merge = true;

                worksheet.Cells["A11:C11"].Value = "Tổng số tiền đã rút:";
                worksheet.Cells["A11:C11"].Style.Font.Bold = true;
                worksheet.Cells["A11:C11"].Merge = true;
                worksheet.Cells["D11:E11"].Value = lst[2].Value;
                worksheet.Cells["D11:E11"].Style.Numberformat.Format = "#,##";
                worksheet.Cells["D11:E11"].Merge = true;

                worksheet.Cells["A13:H13"].Value = "Danh sách giao dịch chi tiết";
                worksheet.Cells["A13:H13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A13:H13"].Merge = true;

                var row = 15;
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

                    worksheet.Cells[row, col].Value = item.Cells["Date"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

                    worksheet.Cells[row, col].Value = item.Cells["OwnerCode"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Event"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Balance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Object"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Area"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";

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

        public static void BCDoanhThuBanHang(string filePath, UltraGrid grid, ModelItem modelItem, List<ThongKeItem> lst)
        {
            var newFile = new FileInfo(filePath);
            using (var xlPackage = new ExcelPackage(newFile))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("DTBH");
                xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
                var properties = new[]
                    {
                        "STT",
                        "Thời gian",
                        "Mã HS",
                        "Mã thẻ",
                        "Loại giao dịch",
                        "Số tiền",
                        "Số dư",
                        "Đối tượng",
                        "Khu vực"
                    };
                worksheet.Cells["A2:I2"].Value = "BÁO CÁO DOANH THU BÁN THẺ";
                worksheet.Cells["A2:I2"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A2:I2"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A2:I2"].Style.Font.Bold = true;
                worksheet.Cells["A2:I2"].Style.Font.Size = 12;
                worksheet.Cells["A2:I2"].Merge = true;
                worksheet.Cells["A2:I2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3:H3"].Value = string.Format("({0} - {1})", modelItem.StartDate.Value.ToString("dd/MM/yyyy"), modelItem.EndDate.Value.ToString("dd/MM/yyyy"));
                worksheet.Cells["A3:H3"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells["A3:H3"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
                worksheet.Cells["A3:H3"].Style.Font.Italic = true;
                worksheet.Cells["A3:H3"].Merge = true;
                worksheet.Cells["A3:H3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A5:B5"].Value = "Đơn vị:";
                worksheet.Cells["C5:D5"].Value = modelItem.BuidingName;
                worksheet.Cells["A6:B6"].Value = "Khu vực:";
                worksheet.Cells["C5:D5"].Value = modelItem.AreaName;
                worksheet.Cells["A7:B7"].Value = "Đầu đọc thẻ:";
                worksheet.Cells["C5:D5"].Value = modelItem.ObjectName;
                worksheet.Cells["A5:B5"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;
                worksheet.Cells["A6:B6"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;
                worksheet.Cells["A7:B7"].Merge = true;
                worksheet.Cells["C5:D5"].Merge = true;

                worksheet.Cells["A9:C9"].Value = "Tổng doanh thu bán hàng:";
                worksheet.Cells["A9:C9"].Style.Font.Bold = true;
                worksheet.Cells["A9:C9"].Merge = true;
                worksheet.Cells["D9:E9"].Value = lst[0].Value;
                worksheet.Cells["D9:E9"].Style.Numberformat.Format = "#,##";
                worksheet.Cells["D9:E9"].Merge = true;

                worksheet.Cells["A10:C10"].Value = "Tổng số giao dịch:";
                worksheet.Cells["A10:C10"].Style.Font.Bold = true;
                worksheet.Cells["A10:C10"].Merge = true;
                worksheet.Cells["D10:E10"].Value = lst[1].Value;
                worksheet.Cells["D10:E10"].Style.Numberformat.Format = "#,##";
                worksheet.Cells["D10:E10"].Merge = true;

                worksheet.Cells["A12:H12"].Value = "Danh sách giao dịch chi tiết";
                worksheet.Cells["A12:H12"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A12:H12"].Merge = true;

                var row = 14;
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

                    worksheet.Cells[row, col].Value = item.Cells["Date"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["OwnerCode"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Event"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Value"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Balance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["Object"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Area"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col].Style.Numberformat.Format = "@";

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

                    worksheet.Cells["A9:G9"].Value = "(" + starDate + " - " + endDate + ")";
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
