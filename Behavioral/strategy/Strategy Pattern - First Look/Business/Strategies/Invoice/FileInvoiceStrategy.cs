﻿using Strategy_Pattern___First_Look.Business.Models;
using System;
using System.IO;

namespace Strategy_Pattern___First_Look.Business.Strategies.Invoice
{
    public class FileInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            using var stream = new StreamWriter($"invoice_{Guid.NewGuid()}.txt");

            stream.Write(GenerateTextInvoice(order));
            stream.Flush();
        }
    }
}
