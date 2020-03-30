
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.ViewModels;
namespace ICreative.Services.Messaging
{
    public class GetAllPosReceiptOfTestingResponse
    {
              public bool PosReceiptOfTestingFound { get; set; }
              public IEnumerable<PosReceiptOfTestingView> PosReceiptOfTestings { get; set; }
    }
}
