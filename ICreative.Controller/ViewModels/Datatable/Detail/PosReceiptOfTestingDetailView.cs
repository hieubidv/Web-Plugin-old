﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICreative.Controllers.ViewModels
{
    public class PosReceiptOfTestingDetailView
    {
        public System.Int32 ReceiptOfTestingId { get; set; }
        public System.DateTime TestDate { get; set; }
        public System.Int32 PosMerchantMerchantId { get; set; }
        public System.String AgentAName { get; set; }
        public System.String AgentBName { get; set; }
        public System.Int32 PosId { get; set; }
    }
}
