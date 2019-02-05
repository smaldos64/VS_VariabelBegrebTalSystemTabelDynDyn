using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows;

namespace VariabelBegreb.Tools
{
    public class ControlTools
    {
        //private static List<KeyToCharConverter> KeyToCharConverterList = new List<KeyToCharConverter>();

        public static void SetComboBoxSelectedItem(ComboBox ThisComboBox, int SelectedValue)
        {
            int ComboBoxItemsCounter = 0;
            bool ComboBoxSelectedItemFound = false;

            do
            {
                if ((int)ThisComboBox.Items[ComboBoxItemsCounter] == SelectedValue)
                {
                    ComboBoxSelectedItemFound = true;
                }
                else
                {
                    ComboBoxItemsCounter++;
                }
            } while ((ComboBoxItemsCounter < ThisComboBox.Items.Count) && (false == ComboBoxSelectedItemFound));

            ThisComboBox.SelectedItem = ThisComboBox.Items.GetItemAt(ComboBoxItemsCounter);
        }

        public static void SetComboBoxSelectedItem(ComboBox ThisComboBox, char SelectedChar)
        {
            int ComboBoxItemsCounter = 0;
            bool ComboBoxSelectedItemFound = false;

            do
            {
                if ((char)ThisComboBox.Items[ComboBoxItemsCounter] == SelectedChar)
                {
                    ComboBoxSelectedItemFound = true;
                }
                else
                {
                    ComboBoxItemsCounter++;
                }
            } while ((ComboBoxItemsCounter < ThisComboBox.Items.Count) && (false == ComboBoxSelectedItemFound));

            ThisComboBox.SelectedItem = ThisComboBox.Items.GetItemAt(ComboBoxItemsCounter);
        }

        public static int CheckTextBoxesForInformation(List<TextBox> TextBoxes)
        {
            int Counter;
            int NumberOfTextBoxesWithInfo = 0;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if (TextBoxes[Counter].Text.Length > 0)
                {
                    NumberOfTextBoxesWithInfo++;
                }
            }

            return (NumberOfTextBoxesWithInfo);
        }

        public static void ClearTextBoxes(List<TextBox> TextBoxes)
        {
            int Counter;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                TextBoxes[Counter].Text = "";
            }
        }

        public static List<string> GetAllLinesInTextBlock(TextBlock ThisTextBlock)
        {
            List<string> LinesInTextBlock = new List<string>();
            string TextBloxkText;
            string SubString;
            int NewLinePosition = -1;

            TextBloxkText = ((System.Windows.Documents.Run)ThisTextBlock.Inlines.FirstInline).Text;
            TextBloxkText.Trim();

            do
            {
                NewLinePosition = TextBloxkText.IndexOf('\n');
                if (NewLinePosition > 0)
                {
                    SubString = TextBloxkText.Substring(0, NewLinePosition - 1);
                    LinesInTextBlock.Add(SubString);
                    TextBloxkText = TextBloxkText.Substring(NewLinePosition + 1);
                }
                else
                {
                    if (0 == NewLinePosition)
                    {
                        TextBloxkText = TextBloxkText.Substring(1);
                    }
                }
            } while (NewLinePosition >= 0);

            LinesInTextBlock.Add(TextBloxkText);

            return (LinesInTextBlock);
        }

        public static void InsertRowInGrid(Grid Grid_Object)
        {
            RowDefinition MyRow = new RowDefinition();
            MyRow.Height = new GridLength(30);
            Grid_Object.RowDefinitions.Add(MyRow);
        }

        public static Label InsertLabelInGrid(Grid Grid_Object, string LabelName, string LabelText,
                                              int RowPosition, int ColumnPosition, int ColumnSpan)
        {
            Label Label_Object = new Label();

            Label_Object.Name = LabelName;
            Label_Object.Content = LabelText;
            Label_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);

            Grid_Object.Children.Add(Label_Object);
            Grid.SetColumn(Label_Object, ColumnPosition);
            Grid.SetRow(Label_Object, RowPosition);

            return (Label_Object);
        }

        public static TextBox InsertTextBoxInGrid(Grid Grid_Object, string TextBoxName, int RowPosition, 
                                                  int ColumnPosition, int ColumnSpan, int Width, int Height,
                                                  KeyEventHandler FunctionKeyDown,
                                                  TextChangedEventHandler FunctionTextChanged)
        {
            TextBox TextBox_Object = new TextBox();

            TextBox_Object.Name = TextBoxName;
            TextBox_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            TextBox_Object.Width = Width;
            TextBox_Object.Height = Height;

            TextBox_Object.TextChanged += FunctionTextChanged;
            TextBox_Object.KeyDown += FunctionKeyDown;

            Grid_Object.Children.Add(TextBox_Object);
            Grid.SetColumn(TextBox_Object, ColumnPosition);
            Grid.SetRow(TextBox_Object, RowPosition);

            return (TextBox_Object);
        }

        //public static void InitializeKeyToCharConverterList(Key[] HighestValidKeyArray)
        //{

        //}

        public static string GetStringFromInt(int KeyValue)
        {
            int KeyValueCounter = 0;

            do
            {
                if (KeyValue == Const.KeyToCharConverterArray[KeyValueCounter].KeyValue)
                {
                    return ((Const.KeyToCharConverterArray[KeyValueCounter].KeyChar).ToString());
                }
                else
                {
                    KeyValueCounter++;
                }
            } while (KeyValueCounter < Const.KeyToCharConverterArray[Const.KeyToCharConverterArray.Length - 1].KeyValue);

            return (' '.ToString());
        }

        public static string GetStringValueFromInt(int KeyValue)
        {
            int KeyValueCounter = 0;
            
            do
            {
                if (KeyValue == Const.KeyToCharConverterArray[KeyValueCounter].KeyValue)
                {
                    return ((Const.KeyToCharConverterArray[KeyValueCounter].Value).ToString());
                }
                else
                {
                    KeyValueCounter++;
                }
            } while (KeyValueCounter < Const.KeyToCharConverterArray.Length - 1);

            return (' '.ToString());
        }

    }
}
