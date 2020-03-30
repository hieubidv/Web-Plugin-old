
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
namespace ICreative.Controllers.Controllers
{
 public class ColumnTable
    {
        public string ColumnField { get; set; }
        public string ColumnHeader { get; set; }
    }
    public static class DocxHelper
    {
        public static SdtRun GetField(string Name)
        {
            SdtRun sdtRun1 = new SdtRun();

            SdtProperties sdtProperties1 = new SdtProperties();
            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            SdtAlias sdtAlias1 = new SdtAlias() { Val = Name };
            Tag tag1 = new Tag() { Val = Name };
            SdtId sdtId1 = new SdtId() { Val = -1033731646 };

            SdtPlaceholder sdtPlaceholder1 = new SdtPlaceholder();
            DocPartReference docPartReference1 = new DocPartReference() { Val = "DefaultPlaceholder_1082065158" };

            sdtPlaceholder1.Append(docPartReference1);
            sdtProperties1.Append(runProperties1);
            sdtProperties1.Append(sdtAlias1);
            sdtProperties1.Append(tag1);
            sdtProperties1.Append(sdtId1);
            sdtProperties1.Append(sdtPlaceholder1);
            SdtEndCharProperties sdtEndCharProperties1 = new SdtEndCharProperties();

            SdtContentRun sdtContentRun1 = new SdtContentRun();

            Run run1 = new Run();
            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize3 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "28" };

            runProperties2.Append(runFonts3);
            runProperties2.Append(fontSize3);
            runProperties2.Append(fontSizeComplexScript3);

            Text text1 = new Text();
            text1.Text = Name;

            run1.Append(runProperties2);
            run1.Append(text1);

            sdtContentRun1.Append(run1);

            sdtRun1.Append(sdtProperties1);
            sdtRun1.Append(sdtEndCharProperties1);
            sdtRun1.Append(sdtContentRun1);

            return sdtRun1;
        }


        public static SdtBlock CreateTable(List<ColumnTable> columns,string tableName)
        {
            SdtBlock sdtBlock1 = new SdtBlock();

            SdtProperties sdtProperties1 = new SdtProperties();

            RunProperties runProperties1 = new RunProperties();
            Bold bold1 = new Bold() { Val = false };
            BoldComplexScript boldComplexScript1 = new BoldComplexScript() { Val = false };
            Color color1 = new Color() { Val = "auto" };
            Languages languages1 = new Languages() { Val = "en-US" };

            runProperties1.Append(bold1);
            runProperties1.Append(boldComplexScript1);
            runProperties1.Append(color1);
            runProperties1.Append(languages1);
            SdtAlias sdtAlias1 = new SdtAlias() { Val = tableName };
            Tag tag1 = new Tag() { Val = tableName };
            SdtId sdtId1 = new SdtId() { Val = -1702077049 };

            SdtPlaceholder sdtPlaceholder1 = new SdtPlaceholder();
            DocPartReference docPartReference1 = new DocPartReference() { Val = "DefaultPlaceholder_1081868574" };

            sdtPlaceholder1.Append(docPartReference1);

            sdtProperties1.Append(runProperties1);
            sdtProperties1.Append(sdtAlias1);
            sdtProperties1.Append(tag1);
            sdtProperties1.Append(sdtId1);
            sdtProperties1.Append(sdtPlaceholder1);
            SdtEndCharProperties sdtEndCharProperties1 = new SdtEndCharProperties();

            SdtContentBlock sdtContentBlock1 = new SdtContentBlock();

            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();

            TableStyle tableStyle1 = new TableStyle() { Val = "GridTable4-Accent1" };
            TableWidth tableWidth1 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            
            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 10, Type = TableWidthValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 10, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            TableLook tableLook1 = new TableLook() { Val = "04A0", FirstRow = true, LastRow = false, FirstColumn = true, LastColumn = false, NoHorizontalBand = false, NoVerticalBand = true };

            tableProperties1.Append(tableCellMarginDefault1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableStyle1);
            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            foreach (ColumnTable column in columns)
            {
                GridColumn gridColumn1 = new GridColumn() { };
                tableGrid1.Append(gridColumn1);
            }
            TableRow tableRow1 = CreateHeaderRow(columns);
            TableRow tableRow2 = CreateCellRow(columns);
            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);
            table1.Append(tableRow2);

            sdtContentBlock1.Append(table1);

            sdtBlock1.Append(sdtProperties1);
            sdtBlock1.Append(sdtEndCharProperties1);
            sdtBlock1.Append(sdtContentBlock1);
            return sdtBlock1;

        }
        public static TableRow CreateCellRow(List<ColumnTable> columns)
        {
            TableRow tableRow1 = new TableRow() { RsidTableRowAddition = "00D149A8", RsidTableRowProperties = "00AD5D8A" };
            TableRowProperties tableRowProperties1 = new TableRowProperties();
            ConditionalFormatStyle conditionalFormatStyle1 = new ConditionalFormatStyle() { Val = "100000000000", FirstRow = true, LastRow = false, FirstColumn = false, LastColumn = false, OddVerticalBand = false, EvenVerticalBand = false, OddHorizontalBand = false, EvenHorizontalBand = false, FirstRowFirstColumn = false, FirstRowLastColumn = false, LastRowFirstColumn = false, LastRowLastColumn = false };

            tableRowProperties1.Append(conditionalFormatStyle1);
            foreach (ColumnTable column in columns)
            {
                TableCell tableCell = CreateColumnCell(column);
                tableRow1.Append(tableCell);
            }
            return tableRow1;
        }

        public static TableRow CreateHeaderRow(List<ColumnTable> columns)
        {
            TableRow tableRow1 = new TableRow() { RsidTableRowAddition = "00D149A8", RsidTableRowProperties = "00AD5D8A" };
            TableRowProperties tableRowProperties1 = new TableRowProperties();
            ConditionalFormatStyle conditionalFormatStyle1 = new ConditionalFormatStyle() { Val = "100000000000", FirstRow = true, LastRow = false, FirstColumn = false, LastColumn = false, OddVerticalBand = false, EvenVerticalBand = false, OddHorizontalBand = false, EvenHorizontalBand = false, FirstRowFirstColumn = false, FirstRowLastColumn = false, LastRowFirstColumn = false, LastRowLastColumn = false };

            tableRowProperties1.Append(conditionalFormatStyle1);
            foreach (ColumnTable column in columns)
            {
                TableCell tableCell = CreateColumnHeader(column);
                tableRow1.Append(tableCell);
            }
            return tableRow1;
        }


        public static TableCell CreateColumnCell(ColumnTable column)
        {
            TableCell tableCell = new TableCell();

            TableCellProperties tableCellProperties = new TableCellProperties();
            DocumentFormat.OpenXml.Wordprocessing.ConditionalFormatStyle conditionalFormatStyleCell1 = new ConditionalFormatStyle() { Val = "001000000000", FirstRow = false, LastRow = false, FirstColumn = true, LastColumn = false, OddVerticalBand = false, EvenVerticalBand = false, OddHorizontalBand = false, EvenHorizontalBand = false, FirstRowFirstColumn = false, FirstRowLastColumn = false, LastRowFirstColumn = false, LastRowLastColumn = false };
            DocumentFormat.OpenXml.Wordprocessing.TableCellWidth tableCellWidth1 = new TableCellWidth() { Type = TableWidthUnitValues.Dxa };

            tableCellProperties.Append(conditionalFormatStyleCell1);
            tableCellProperties.Append(tableCellWidth1);

            SdtBlock sdtBlockSub = new SdtBlock();

            SdtProperties sdtProperties = new SdtProperties();

            RunProperties runProperties = new RunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize1 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "28" };

            runProperties.Append(runFonts1);
            runProperties.Append(fontSize1);
            runProperties.Append(fontSizeComplexScript1);
            SdtAlias sdtAliasSub = new SdtAlias() { Val = column.ColumnField };
            Tag tagCell = new Tag() { Val = column.ColumnField };
            SdtId sdtIdCell = new SdtId() { Val = -2144724967 };

            SdtPlaceholder sdtPlaceholderCell1 = new SdtPlaceholder();
            DocPartReference docPartReferenceCell1 = new DocPartReference() { Val = "941489452D594FF2A513A53EEFA3E58F" };

            sdtPlaceholderCell1.Append(docPartReferenceCell1);

            sdtProperties.Append(runProperties);
            sdtProperties.Append(sdtAliasSub);
            sdtProperties.Append(tagCell);
            sdtProperties.Append(sdtIdCell);
            sdtProperties.Append(sdtPlaceholderCell1);

            SdtContentBlock sdtContentBlockSub = new SdtContentBlock();

            Paragraph paragraphCell = new Paragraph() { RsidParagraphAddition = "00C03259", RsidParagraphProperties = "00BB7EFE", RsidRunAdditionDefault = "00C03259" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunPropertiesCell = new ParagraphMarkRunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunPropertiesCell.Append(runFonts2);
            paragraphMarkRunPropertiesCell.Append(fontSize2);
            paragraphMarkRunPropertiesCell.Append(fontSizeComplexScript2);

            paragraphProperties1.Append(paragraphMarkRunPropertiesCell);

            Run runCell = new Run();

            RunProperties runPropertiesCell = new RunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold1 = new Bold() { Val = false };
            FontSize fontSize3 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "28" };

            runPropertiesCell.Append(runFonts3);
            runPropertiesCell.Append(bold1);
            runPropertiesCell.Append(fontSize3);
            runPropertiesCell.Append(fontSizeComplexScript3);

            Text textCell = new Text();
            textCell.Text = column.ColumnHeader;

            runCell.Append(runPropertiesCell);
            runCell.Append(textCell);

            paragraphCell.Append(paragraphProperties1);
            paragraphCell.Append(runCell);

            sdtContentBlockSub.Append(paragraphCell);

            sdtBlockSub.Append(sdtProperties);
            sdtBlockSub.Append(sdtContentBlockSub);

            tableCell.Append(tableCellProperties);
            tableCell.Append(sdtBlockSub);
            return tableCell;
        }

        public static TableCell CreateColumnHeader(ColumnTable column)
        {
            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            ConditionalFormatStyle conditionalFormatStyle2 = new ConditionalFormatStyle() { Val = "001000000000", FirstRow = false, LastRow = false, FirstColumn = true, LastColumn = false, OddVerticalBand = false, EvenVerticalBand = false, OddHorizontalBand = false, EvenHorizontalBand = false, FirstRowFirstColumn = false, FirstRowLastColumn = false, LastRowFirstColumn = false, LastRowLastColumn = false };
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Type = TableWidthUnitValues.Dxa };

            tableCellProperties1.Append(conditionalFormatStyle2);
            tableCellProperties1.Append(tableCellWidth1);

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00451032", RsidParagraphAddition = "00D149A8", RsidParagraphProperties = "00AD5D8A", RsidRunAdditionDefault = "00D149A8" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize1 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run();

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            runProperties2.Append(runFonts2);
            runProperties2.Append(fontSize2);
            runProperties2.Append(fontSizeComplexScript2);
            Text text1 = new Text();
            text1.Text = column.ColumnHeader;

            run1.Append(runProperties2);
            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph1);
            return tableCell1;
        }


        public static Style GenerateStyle()
        {
            Style style1 = new Style() { Type = StyleValues.Table, StyleId = "GridTable4-Accent1" };
            StyleName styleName1 = new StyleName() { Val = "Grid Table 4 Accent 1" };
            BasedOn basedOn1 = new BasedOn() { Val = "TableNormal" };
            UIPriority uIPriority1 = new UIPriority() { Val = 49 };
            Rsid rsid1 = new Rsid() { Val = "006A27FC" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties1.Append(spacingBetweenLines1);

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableStyleRowBandSize tableStyleRowBandSize1 = new TableStyleRowBandSize() { Val = 1 };
            TableStyleColumnBandSize tableStyleColumnBandSize1 = new TableStyleColumnBandSize() { Val = 1 };
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "9CC2E5", ThemeColor = ThemeColorValues.Accent1, ThemeTint = "99", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder1);
            tableBorders1.Append(leftBorder1);
            tableBorders1.Append(bottomBorder1);
            tableBorders1.Append(rightBorder1);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableStyleRowBandSize1);
            styleTableProperties1.Append(tableStyleColumnBandSize1);
            styleTableProperties1.Append(tableIndentation1);
            styleTableProperties1.Append(tableBorders1);
            styleTableProperties1.Append(tableCellMarginDefault1);

            TableStyleProperties tableStyleProperties1 = new TableStyleProperties() { Type = TableStyleOverrideValues.FirstRow };

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            Bold bold1 = new Bold();
            BoldComplexScript boldComplexScript1 = new BoldComplexScript();
            Color color1 = new Color() { Val = "FFFFFF", ThemeColor = ThemeColorValues.Background1 };

            runPropertiesBaseStyle1.Append(bold1);
            runPropertiesBaseStyle1.Append(boldComplexScript1);
            runPropertiesBaseStyle1.Append(color1);
            TableStyleConditionalFormattingTableProperties tableStyleConditionalFormattingTableProperties1 = new TableStyleConditionalFormattingTableProperties();

            TableStyleConditionalFormattingTableCellProperties tableStyleConditionalFormattingTableCellProperties1 = new TableStyleConditionalFormattingTableCellProperties();

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "5B9BD5", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "5B9BD5", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "5B9BD5", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Single, Color = "5B9BD5", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Nil };
            InsideVerticalBorder insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder2);
            tableCellBorders1.Append(leftBorder2);
            tableCellBorders1.Append(bottomBorder2);
            tableCellBorders1.Append(rightBorder2);
            tableCellBorders1.Append(insideHorizontalBorder2);
            tableCellBorders1.Append(insideVerticalBorder2);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "5B9BD5", ThemeFill = ThemeColorValues.Accent1 };

            tableStyleConditionalFormattingTableCellProperties1.Append(tableCellBorders1);
            tableStyleConditionalFormattingTableCellProperties1.Append(shading1);

            tableStyleProperties1.Append(runPropertiesBaseStyle1);
            tableStyleProperties1.Append(tableStyleConditionalFormattingTableProperties1);
            tableStyleProperties1.Append(tableStyleConditionalFormattingTableCellProperties1);

            TableStyleProperties tableStyleProperties2 = new TableStyleProperties() { Type = TableStyleOverrideValues.LastRow };

            RunPropertiesBaseStyle runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
            Bold bold2 = new Bold();
            BoldComplexScript boldComplexScript2 = new BoldComplexScript();

            runPropertiesBaseStyle2.Append(bold2);
            runPropertiesBaseStyle2.Append(boldComplexScript2);
            TableStyleConditionalFormattingTableProperties tableStyleConditionalFormattingTableProperties2 = new TableStyleConditionalFormattingTableProperties();

            TableStyleConditionalFormattingTableCellProperties tableStyleConditionalFormattingTableCellProperties2 = new TableStyleConditionalFormattingTableCellProperties();

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Double, Color = "5B9BD5", ThemeColor = ThemeColorValues.Accent1, Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders2.Append(topBorder3);

            tableStyleConditionalFormattingTableCellProperties2.Append(tableCellBorders2);

            tableStyleProperties2.Append(runPropertiesBaseStyle2);
            tableStyleProperties2.Append(tableStyleConditionalFormattingTableProperties2);
            tableStyleProperties2.Append(tableStyleConditionalFormattingTableCellProperties2);

            TableStyleProperties tableStyleProperties3 = new TableStyleProperties() { Type = TableStyleOverrideValues.FirstColumn };

            RunPropertiesBaseStyle runPropertiesBaseStyle3 = new RunPropertiesBaseStyle();
            Bold bold3 = new Bold();
            BoldComplexScript boldComplexScript3 = new BoldComplexScript();

            runPropertiesBaseStyle3.Append(bold3);
            runPropertiesBaseStyle3.Append(boldComplexScript3);

            tableStyleProperties3.Append(runPropertiesBaseStyle3);

            TableStyleProperties tableStyleProperties4 = new TableStyleProperties() { Type = TableStyleOverrideValues.LastColumn };

            RunPropertiesBaseStyle runPropertiesBaseStyle4 = new RunPropertiesBaseStyle();
            Bold bold4 = new Bold();
            BoldComplexScript boldComplexScript4 = new BoldComplexScript();

            runPropertiesBaseStyle4.Append(bold4);
            runPropertiesBaseStyle4.Append(boldComplexScript4);

            tableStyleProperties4.Append(runPropertiesBaseStyle4);

            TableStyleProperties tableStyleProperties5 = new TableStyleProperties() { Type = TableStyleOverrideValues.Band1Vertical };
            TableStyleConditionalFormattingTableProperties tableStyleConditionalFormattingTableProperties3 = new TableStyleConditionalFormattingTableProperties();

            TableStyleConditionalFormattingTableCellProperties tableStyleConditionalFormattingTableCellProperties3 = new TableStyleConditionalFormattingTableCellProperties();
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6", ThemeFill = ThemeColorValues.Accent1, ThemeFillTint = "33" };

            tableStyleConditionalFormattingTableCellProperties3.Append(shading2);

            tableStyleProperties5.Append(tableStyleConditionalFormattingTableProperties3);
            tableStyleProperties5.Append(tableStyleConditionalFormattingTableCellProperties3);

            TableStyleProperties tableStyleProperties6 = new TableStyleProperties() { Type = TableStyleOverrideValues.Band1Horizontal };
            TableStyleConditionalFormattingTableProperties tableStyleConditionalFormattingTableProperties4 = new TableStyleConditionalFormattingTableProperties();

            TableStyleConditionalFormattingTableCellProperties tableStyleConditionalFormattingTableCellProperties4 = new TableStyleConditionalFormattingTableCellProperties();
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "DEEAF6", ThemeFill = ThemeColorValues.Accent1, ThemeFillTint = "33" };

            tableStyleConditionalFormattingTableCellProperties4.Append(shading3);

            tableStyleProperties6.Append(tableStyleConditionalFormattingTableProperties4);
            tableStyleProperties6.Append(tableStyleConditionalFormattingTableCellProperties4);

            style1.Append(styleName1);
            style1.Append(basedOn1);
            style1.Append(uIPriority1);
            style1.Append(rsid1);
            style1.Append(styleParagraphProperties1);
            style1.Append(styleTableProperties1);
            style1.Append(tableStyleProperties1);
            style1.Append(tableStyleProperties2);
            style1.Append(tableStyleProperties3);
            style1.Append(tableStyleProperties4);
            style1.Append(tableStyleProperties5);
            style1.Append(tableStyleProperties6);
            return style1;
        }

    }
}
