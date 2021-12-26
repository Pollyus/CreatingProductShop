using DAL.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBL.Interfaces;

namespace BBL.Servises
{
    public class FileService : IFileService
    {
        IDbRepos dataBase;
        public FileService(IDbRepos dbRepository)
        {
            dataBase = dbRepository;
        }

        public void PrintExceptions(Exception ex)
        {
            string writePath = @"Exception.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(ex.Message);
                    sw.WriteLine(ex.StackTrace);
                    sw.WriteLine(ex.InnerException);
                    sw.WriteLine(ex.Source + "\n");
                }
            }
            catch (Exception e)
            {
                PrintExceptions(e);
            }
        }

        public void PrintCheque(int orderId)
        {
            try
            {
                string file = @"Check.pdf";
                var order = dataBase.Orders.GetItem(orderId);
                var buyer = dataBase.Buyers.GetItem((int)order.UserId);
                var lines = dataBase.OrderLines.GetList().Where(i => i.OrderId == orderId).Join(dataBase.Products.GetList(), i => i.ProductId, pr => pr.Id, (i, pr) => new { i.Price, i.Amount, pr.Name }).ToList();

                FileStream fs = new FileStream(file, FileMode.Create);
                Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font1 = new Font(baseFont, 14, Font.BOLD);
                Font font = new Font(baseFont, 12);

               
                document.Open();

                Paragraph header = new Paragraph("Доставка продуктов", font1);
                header.Alignment = Element.ALIGN_CENTER;
                Paragraph separator = new Paragraph("--------------------------------------------------------------------------------", font1);
                separator.Alignment = Element.ALIGN_CENTER;
                Paragraph date = new Paragraph($"Дата оформления заказа: {order.Date}", font);
                Paragraph name = new Paragraph($"Ваше имя: {buyer.Name}", font);
                Paragraph sum = new Paragraph($"Сумма заказа составила: {order.Sum} руб.", font);




            document.Add(header);
                document.Add(separator);
                document.Add(new Paragraph("\n"));
                document.Add(date);
                document.Add(name);
                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("\n"));

                foreach (var i in lines)
                {
                    document.Add(new Paragraph($"{i.Name}: {i.Amount} шт. {i.Price.ToString() } руб. ", font));
                
                    document.Add(new Paragraph("\n"));
                }

                document.Add(new Paragraph("\n"));
                document.Add(sum);
                document.Add(separator);


                document.Close();
                writer.Close();
                fs.Close();

                Process iStartProcess = new Process();
                iStartProcess.StartInfo.FileName = file;
                iStartProcess.Start();
            }
            catch (Exception ex)
            {
                PrintExceptions(ex);
            }
        }
    }
}
