
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICreative.Model;
using ICreative.Services.ViewModels;
using AutoMapper;
namespace ICreative.Services.Mapping
{
    public static class PosReceiptOfTestingMapper
    {
        public static PosReceiptOfTestingView ConvertToPosReceiptOfTestingView(
                                               this PosReceiptOfTesting posReceiptOfTesting)
        {
            return Mapper.Map<PosReceiptOfTesting,
                              PosReceiptOfTestingView>(posReceiptOfTesting);
        }
        
        
        public static IEnumerable<PosReceiptOfTestingView> ConvertToPosReceiptOfTestingViews(
                                                      this IEnumerable<PosReceiptOfTesting> posReceiptOfTestings)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTesting>, IEnumerable<PosReceiptOfTestingView>>(posReceiptOfTestings);
        }
        
        public static PosReceiptOfTesting ConvertToPosReceiptOfTesting(
                                               this PosReceiptOfTestingView posReceiptOfTestingView)
        {
            return Mapper.Map<PosReceiptOfTestingView,
                              PosReceiptOfTesting>(posReceiptOfTestingView);
        }
        
        
        public static IList<PosReceiptOfTesting> ConvertToPosReceiptOfTestings(
                                                      this IEnumerable<PosReceiptOfTestingView> posReceiptOfTestingsView)
        {
            return Mapper.Map<IEnumerable<PosReceiptOfTestingView>, IList<PosReceiptOfTesting>>(posReceiptOfTestingsView);
        }        
        
    }

}
