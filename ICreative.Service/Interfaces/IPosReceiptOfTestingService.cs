
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Services.Messaging;

namespace ICreative.Services.Interfaces
{
    public interface IPosReceiptOfTestingService
    {
        CreatePosReceiptOfTestingResponse CreatePosReceiptOfTesting(CreatePosReceiptOfTestingRequest request);
        GetPosReceiptOfTestingResponse GetPosReceiptOfTesting(GetPosReceiptOfTestingRequest request);
        GetAllPosReceiptOfTestingResponse GetAllPosReceiptOfTestings();
        ModifyPosReceiptOfTestingResponse ModifyPosReceiptOfTesting(ModifyPosReceiptOfTestingRequest request);
        RemovePosReceiptOfTestingResponse RemovePosReceiptOfTesting(RemovePosReceiptOfTestingRequest request);
    }

}
