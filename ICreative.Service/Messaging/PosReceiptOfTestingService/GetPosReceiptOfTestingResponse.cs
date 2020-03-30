
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetPosReceiptOfTestingResponse
    {
              public bool PosReceiptOfTestingFound { get; set; }
              public PosReceiptOfTestingView PosReceiptOfTesting { get; set; }
    }
}
