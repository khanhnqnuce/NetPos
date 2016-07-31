﻿using System;

namespace FDI.Simple
{
    public class CardItem:BaseSimple
    {
        public int ID { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string CardStatus { get; set; }
        public DateTime DateIssue { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CardType { get; set; }
    }
}