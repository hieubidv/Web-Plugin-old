using System;
using System.Collections.Generic;

namespace ICreative.Controllers.ViewModels
{

  public class WebPagerItemCollection : List<WebPagerItem>
  {
    #region Constructor
    public WebPagerItemCollection(int rowCount, int pageSize, int pageIndex)
    {
      // Calculate total pages based on RowCount and PageSize
      int pageCount = 0;
      
      pageCount = Convert.ToInt32(
                    Math.Ceiling(
                       Convert.ToDecimal(rowCount) /
                       Convert.ToDecimal(pageSize)));

      // Initialize the collection of pager items
      Init(pageCount, pageIndex);
    }
    #endregion

    #region Public Properties
    public int PageCount { get; set; }
    #endregion

    #region Init Method
    private void Init(int pageCount, int pageIndex)
    {
      int itemIndex = 0;

      PageCount = pageCount;

      Add(new WebPagerItem(WebPagerCommands.FirstText, 
                            WebPagerCommands.First,
                            (pageIndex == 0), WebPagerCommands.FirstTooltipText));
      itemIndex++;
      Add(new WebPagerItem(WebPagerCommands.PreviousText, 
                            WebPagerCommands.Previous,
                            (pageIndex == 0), WebPagerCommands.PreviousTooltipText));
      itemIndex++;

      
      for (int i = 0; i < PageCount; i++)
      {          
          if ( (i > pageIndex - 10) & (i < pageIndex + 10))
          {
              Add(new WebPagerItem(i, pageIndex,
                                WebPagerCommands.PageText + " " + (i + 1).ToString()));   
          }          
        itemIndex++;
      }

      Add(new WebPagerItem(WebPagerCommands.NextText, 
                            WebPagerCommands.Next,
                            (PageCount - 1 == pageIndex), WebPagerCommands.NextTooltipText));
      itemIndex++;
      Add(new WebPagerItem(WebPagerCommands.LastText, 
                            WebPagerCommands.Last,
                            (PageCount - 1 == pageIndex), WebPagerCommands.LastTooltipText));
    }
    #endregion
  }
}
