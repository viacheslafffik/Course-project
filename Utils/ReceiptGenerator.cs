using Course_Project.Models.Users;
using Course_Project.Models.Orders;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Course_Project.Utils
{
    internal static class ReceiptGenerator
    {
        public static void GenerateAndOpen(int orderId, Client client)
        {
            string fileName = $"receipt_{orderId}.html";
            string path = Path.Combine(Path.GetTempPath(), fileName);

            var sb = new StringBuilder();

            sb.Append(@"
<!DOCTYPE html>
<html>
<head>
<meta charset='utf-8'>
<title>Чек</title>

<style>
    body {
        font-family: Consolas, monospace;
        font-size: 12px;
        margin: 0;
        padding: 0;
    }

    .receipt {
        width: 58mm; /* або 80mm */
        margin: 0 auto;
        padding: 5px;
    }

    h2, h3, p {
        text-align: center;
        margin: 4px 0;
    }

    table {
        width: 100%;
        border-collapse: collapse;
    }

    td {
        padding: 2px 0;
    }

    .right {
        text-align: right;
    }

    hr {
        border: none;
        border-top: 1px dashed black;
        margin: 6px 0;
    }

    @media print {
        body {
            margin: 0;
        }
    }

    @page {
        size: 58mm auto;
        margin: 0;
    }

</style>
</head>
<body onload='window.print()'>
<div class='receipt'>
");

            sb.Append("<h2>BookSales Manager</h2>");
            sb.Append("<p>КАСОВИЙ ЧЕК</p>");
            sb.Append("<hr>");

            sb.Append($"<p>Чек № {orderId}</p>");
            sb.Append($"<p>{DateTime.Now:dd.MM.yyyy HH:mm}</p>");

            if (client != null)
                sb.Append($"<p>{client.firstName} {client.lastName}<br>{client.phone}</p>");

            sb.Append("<hr>");

            sb.Append("<table>");
            foreach (var i in OrderCart.Items)
            {
                sb.Append($@"
<tr>
    <td colspan='2'>{i.name}</td>
</tr>
<tr>
    <td>{i.quantity} x {i.price:0.00}</td>
    <td class='right'>{(i.price * i.quantity):0.00}</td>
</tr>");
            }
            sb.Append("</table>");

            sb.Append("<hr>");

            decimal total = OrderCart.Total();
            if (client != null && client.discount > 0)
            {
                decimal disc = total * client.discount / 100m;
                sb.Append($"<p>Знижка: -{disc:0.00}</p>");
                total -= disc;
            }

            sb.Append($"<h3>Разом: {total:0.00} грн</h3>");
            sb.Append("<hr>");
            sb.Append("<p>Дякуємо за покупку!</p>");

            sb.Append("</div></body></html>");

            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
    }
}
