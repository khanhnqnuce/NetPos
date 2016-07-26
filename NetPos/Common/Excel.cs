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
        public static void ExportToCard(string filePath , UltraGrid grid)
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
                        "Phát hành",
                        "Thành viên",
                        "Khóa thẻ"
                    };
                worksheet.Cells["A1:I2"].Value = "DANH MỤC SẢN PHẨM";
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

                    worksheet.Cells[row, col].Value = item.Cells["Code"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["CardNumber"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["AccountName"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["Balance"].Value;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "#,##";

                    worksheet.Cells[row, col].Value = item.Cells["CardTypeCode"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["IsRelease"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["IsEdit"].Text;
                    worksheet.Cells[row, col].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                    worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

                    worksheet.Cells[row, col].Value = item.Cells["IsLockCard"].Text;
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
    }
}
