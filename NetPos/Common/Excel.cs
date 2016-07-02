namespace NetPos
{
    public class Excel
    {
        //public static void ExportToOrder(string filePath, List<OrderItem> report)
        //{
        //    var newFile = new FileInfo(filePath);
        //    using (var xlPackage = new ExcelPackage(newFile))
        //    {
        //        var worksheet = xlPackage.Workbook.Worksheets.Add("Order");
        //        xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;
        //        var properties = new[]
        //            {
        //                "STT",
        //                "Ngày bán",
        //                "Mã đơn hàng",
        //                "Cửa hàng",
        //                "Khách hàng",
        //                "NV thu ngân",
        //                "NV bán hàng",
        //                "Tổng tiền"
        //            };
        //        for (var i = 0; i < properties.Length; i++)
        //        {
        //            worksheet.Cells[1, i + 1].Value = properties[i];
        //            worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(184, 204, 228));
        //            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
        //            worksheet.Cells[1, i + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        //        }

        //        var row = 2;
        //        var stt = 1;
        //        foreach (var item in report)
        //        {
        //            var col = 1;
        //            worksheet.Cells[row, col].Value = stt++;
        //            worksheet.Cells[row, col].Style.Numberformat.Format = "0";
        //            worksheet.Cells[row, col++].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

        //            worksheet.Cells[row, col].Value = item.DateCreated;
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "dd/MM/yyyy";

        //            worksheet.Cells[row, col].Value = Utility.RandomMaKh(WebConfig.txtHD,item.OrderCode,10);
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

        //            worksheet.Cells[row, col].Value = item.ShopName;
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

        //            worksheet.Cells[row, col].Value = item.CustomerName;
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

        //            worksheet.Cells[row, col].Value = item.UserCreate;
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

        //            worksheet.Cells[row, col].Value = item.UserID;
        //            worksheet.Cells[row, col++].Style.Numberformat.Format = "@";

        //            worksheet.Cells[row, col].Value = item.OrderTotal;
        //            worksheet.Cells[row, col].Style.Numberformat.Format = "#,##";
        //            row++;
        //        }
        //        var nameexcel = "Danh sách Đơn hàng" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        //        xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
        //        xlPackage.Workbook.Properties.Author = "Admin-IT";
        //        xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
        //        xlPackage.Workbook.Properties.Category = "Report";
        //        xlPackage.Workbook.Properties.Company = "CTS";
        //        xlPackage.Save();
        //    }
        //}

        //public virtual void ExportReportToExcelByMonth(string filePath, List<CustomerItem> report)
        //{
        //    var list = report.GroupBy(m => m.ID).ToList();
        //    //int idIn = 23;
        //    foreach (var item in list)
        //    {
        //        var listreport = report.Where(m => m.ID == item.Key).ToList();
        //        var customer = listreport.FirstOrDefault();
        //        var newFile = new FileInfo(filePath);

        //        // ok, we can run the real code of the sample now
        //        var dem = 0;
        //        using (var xlPackage = new ExcelPackage(newFile))
        //        {
        //            var worksheet = xlPackage.Workbook.Worksheets.Add(customer.FullName);
        //            xlPackage.Workbook.CalcMode = ExcelCalcMode.Manual;

        //            var properties = new[]
        //            {
        //                "Số in:",
        //                "Hà Nội, Ngày………Tháng…… … Năm…………",
        //                "          CÔNG TY TNHH NHƯỢNG QUYỀN THƯƠNG MẠI THĂNG LONG",
        //                "          ĐC: Số 32 Ngõ 23 Đỗ Quang, Trung Hòa, Cầu Giấy, HN",       
        //                "                       BẢNG THU NHẬP - RECEIPT",
        //                "Họ Tên",
        //                "CMND",
        //                "Mã số ID",
        //                "Địa Chỉ",
        //                "Cấp bậc",
        //                "ĐT",
        //                "Thưởng 10 ngày",
        //                "Thưởng 30 ngày",
        //                "Thưởng 60 ngày",
        //                "Thưởng 5% Nâng gói",
        //                "Thưởng chu kỳ",
        //                "Thưởng 5% nhóm",
        //                "Thưởng nén 10 tầng",
        //                "Thưởng 6 đời",
        //                "Thưởng 5% doanh số công ty",
        //                "Tổng cộng",
        //                "Thuế",
        //                "Công nợ(nếu có)",
        //                "Phí in ấn",
        //                "Thực lãnh",
        //                "                       GIẤY KÝ NHẬN",
        //                "Tôi là:",
        //                "Đã nhận tiền  Ngày .........Tháng .....Năm...........của Công ty .......................................",
        //                "Tổng cộng :",
        //                "Trong đó thuế thu nhập",
        //                "Trong đó thuế thu nhập + phí in ấn:",
        //                 "Thực lãnh",
        //                 "Lưu ý: Khi ký nhận NPP gửi kèm CMND công chứng mới hợp lệ. "
        //            };

        //            worksheet.Cells[1, 1].Value = properties[0];
        //            worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[1, 1].Style.Font.Bold = true;
        //            worksheet.Cells[1, 1].Style.Font.Size = 16;
        //            worksheet.Cells[1, 2].Value = customer.ID.ToString();


        //            worksheet.Cells[1, 3].Value = properties[1];
        //            worksheet.Cells[1, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[1, 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[1, 3].Style.Font.Bold = true;
        //            worksheet.Cells[1, 3].Style.Font.Size = 12;

        //            worksheet.Cells[3, 2].Value = properties[2];
        //            worksheet.Cells[3, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[3, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[3, 2].Style.Font.Bold = true;
        //            worksheet.Cells[3, 2].Style.Font.Size = 12;

        //            worksheet.Cells[4, 2].Value = properties[3];
        //            worksheet.Cells[4, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[4, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[4, 2].Style.Font.Bold = true;
        //            worksheet.Cells[4, 2].Style.Font.Size = 10;

        //            worksheet.Cells[5, 2].Value = properties[4];
        //            worksheet.Cells[5, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[5, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[5, 2].Style.Font.Bold = true;
        //            worksheet.Cells[5, 2].Style.Font.Size = 20;

        //            worksheet.Cells[7, 1].Value = properties[5];
        //            worksheet.Cells[7, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[7, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[7, 1].Style.Font.Bold = true;
        //            worksheet.Cells[7, 1].Style.Font.Size = 16;
        //            worksheet.Cells[7, 2].Value = ": " + customer.FullName;

        //            worksheet.Cells[7, 4].Value = properties[6];
        //            worksheet.Cells[7, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[7, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[7, 4].Style.Font.Bold = true;
        //            worksheet.Cells[7, 4].Style.Font.Size = 16;
        //            worksheet.Cells[7, 5].Value = ": " + customer.Cmnd;

        //            worksheet.Cells[8, 1].Value = properties[7];
        //            worksheet.Cells[8, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[8, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[8, 1].Style.Font.Bold = true;
        //            worksheet.Cells[8, 1].Style.Font.Size = 16;
        //            worksheet.Cells[8, 2].Value = ": " + customer.FullName;

        //            worksheet.Cells[8, 4].Value = properties[8];
        //            worksheet.Cells[8, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[8, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[8, 4].Style.Font.Bold = true;
        //            worksheet.Cells[8, 4].Style.Font.Size = 16;
        //            worksheet.Cells[8, 5].Value = ": " + customer.Address;

        //            worksheet.Cells[9, 1].Value = properties[9];
        //            worksheet.Cells[9, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[9, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[9, 1].Style.Font.Bold = true;
        //            worksheet.Cells[9, 1].Style.Font.Size = 16;
        //            worksheet.Cells[9, 2].Value = ": " + customer.Cmnd;

        //            worksheet.Cells[9, 4].Value = properties[10];
        //            worksheet.Cells[9, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[9, 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[9, 4].Style.Font.Bold = true;
        //            worksheet.Cells[9, 4].Style.Font.Size = 16;
        //            worksheet.Cells[9, 5].Value = ": " + customer.Mobile;


        //            foreach (var customeritem in listreport)
        //            {
        //                dem++;
        //                worksheet.Cells[11 + dem, 1].Value = customeritem.Cmnd;
        //                worksheet.Cells[11 + dem, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //                worksheet.Cells[11 + dem, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //                //worksheet.Cells[11, 1].Style.Font.Bold = true;
        //                worksheet.Cells[11 + dem, 1].Style.Font.Size = 16;
        //                worksheet.Cells[11 + dem, 2].Value = ": " + customeritem.Cmnd;

        //            }

        //            worksheet.Cells[11 + dem + 1, 1].Value = properties[20];
        //            worksheet.Cells[11 + dem + 1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[11 + dem + 1, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[11 + dem + 1, 1].Style.Font.Bold = true;
        //            worksheet.Cells[11 + dem + 1, 1].Style.Font.Size = 16;
        //            worksheet.Cells[11 + dem + 1, 2].Value = ": " + "123456789";

        //            worksheet.Cells[11 + dem + 2, 1].Value = properties[21];
        //            worksheet.Cells[11 + dem + 2, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[11 + dem + 2, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            //worksheet.Cells[21, 1].Style.Font.Bold = true;
        //            worksheet.Cells[11 + dem + 2, 1].Style.Font.Size = 16;

        //            worksheet.Cells[11 + dem + 3, 1].Value = properties[22];
        //            worksheet.Cells[11 + dem + 3, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[11 + dem + 3, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            //worksheet.Cells[22, 1].Style.Font.Bold = true;
        //            worksheet.Cells[11 + dem + 3, 1].Style.Font.Size = 16;

        //            worksheet.Cells[11 + dem + 4, 1].Value = properties[23];
        //            worksheet.Cells[11 + dem + 4, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[11 + dem + 4, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            //worksheet.Cells[23, 1].Style.Font.Bold = true;
        //            worksheet.Cells[11 + dem + 4, 1].Style.Font.Size = 16;

        //            worksheet.Cells[11 + dem + 5, 1].Value = properties[24];
        //            worksheet.Cells[11 + dem + 5, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[11 + dem + 5, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[11 + dem + 5, 1].Style.Font.Bold = true;
        //            worksheet.Cells[11 + dem + 5, 1].Style.Font.Size = 16;


        //            //bien 2
        //            int row = 11 + dem + 10;
        //            worksheet.Cells[++row, 1].Value = properties[0];//so in
        //            worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 16;
        //            worksheet.Cells[row, 2].Value = customer.ID.ToString();

        //            worksheet.Cells[row, 3].Value = properties[1];//ha noi ngay
        //            worksheet.Cells[row, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 3].Style.Font.Bold = true;
        //            worksheet.Cells[row, 3].Style.Font.Size = 12;

        //            ++row;
        //            worksheet.Cells[++row, 2].Value = properties[2];//          CÔNG TY TNHH NHƯỢNG QUYỀN THƯƠNG MẠI THĂNG LONG
        //            worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 2].Style.Font.Bold = true;
        //            worksheet.Cells[row, 2].Style.Font.Size = 12;

        //            worksheet.Cells[++row, 2].Value = properties[3];//          ĐC: Số 32 Ngõ 23 Đỗ Quang, Trung Hòa, Cầu Giấy, HN
        //            worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 2].Style.Font.Bold = true;
        //            worksheet.Cells[row, 2].Style.Font.Size = 10;

        //            worksheet.Cells[++row, 2].Value = properties[25];// giấy ký xác nhận
        //            worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 2].Style.Font.Bold = true;
        //            worksheet.Cells[row, 2].Style.Font.Size = 18;

        //            worksheet.Cells[++row, 1].Value = properties[26];//toi la
        //            //   worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 14;
        //            worksheet.Cells[row, 2].Value = ": " + customer.FullName;
        //            worksheet.Cells[row, 3].Value = "Mã số ID :";
        //            worksheet.Cells[row, 4].Value = customer.FullName;
        //            worksheet.Cells[row, 5].Value = "Ngày in";
        //            worksheet.Cells[row, 6].Value = DateTime.Now.ToString("dd/MM/yyyy");

        //            worksheet.Cells[++row, 1].Value = properties[27];//da nhan tien
        //            worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 14;

        //            worksheet.Cells[++row, 1].Value = properties[20];//tong cong
        //            worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 14;
        //            worksheet.Cells[row, 2].Value = ": " + listreport.Sum(m => m.CityID);

        //            worksheet.Cells[++row, 1].Value = properties[29];//thuc lanh
        //            worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 14;

        //            worksheet.Cells[++row, 1].Value = properties[30];//luu y
        //            worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 1].Style.Font.Bold = true;
        //            worksheet.Cells[row, 1].Style.Font.Size = 14;

        //            worksheet.Cells[++row, 5].Value = properties[1];// ha noi ngay
        //            worksheet.Cells[row, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 5].Style.Font.Bold = true;
        //            worksheet.Cells[row, 5].Style.Font.Size = 14;

        //            worksheet.Cells[++row, 2].Value = "Kế toán";// ha noi ngay
        //            worksheet.Cells[row, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 2].Style.Font.Bold = true;
        //            worksheet.Cells[row, 2].Style.Font.Size = 14;

        //            worksheet.Cells[row, 5].Value = "                  Ký nhận";// ha noi ngay
        //            worksheet.Cells[row, 5].Style.Fill.PatternType = ExcelFillStyle.Solid;
        //            worksheet.Cells[row, 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 255));
        //            worksheet.Cells[row, 5].Style.Font.Bold = true;
        //            worksheet.Cells[row, 5].Style.Font.Size = 14;

        //            // we had better add some document properties to the spreadsheet 
        //            // set some core property values
        //            var nameexcel = "Danh sách Hoa hồng" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
        //            xlPackage.Workbook.Properties.Title = string.Format("{0} reports", nameexcel);
        //            xlPackage.Workbook.Properties.Author = "Admin-IT";
        //            xlPackage.Workbook.Properties.Subject = string.Format("{0} reports", "");
        //            xlPackage.Workbook.Properties.Category = "Report";

        //            // set some extended property values
        //            xlPackage.Workbook.Properties.Company = "DoAnMVC";
        //            // save the new spreadsheet
        //            xlPackage.Save();
        //        }


        //    }
        //}

    }
}
