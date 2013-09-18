using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using Umbraco.Web.Models;
using umbraco.interfaces;
using umbraco.NodeFactory;
using UmbCodeGen.TypeLib;

using MoviesRazor.Models;

namespace MoviesRazor.Controllers
{
    public class TestModelController : BaseController
    {
        //
        // GET: /Movies/

        public override ActionResult Index(RenderModel model)
        {
            INode currentNode = Node.GetCurrent();
            var testModel = ModelFactory.CreateModel<TestModel>(currentNode);
            testModel.Title = "Model Test Page";
            testModel.TimeStamp = DateTime.Now;

            ValidateModel(testModel);
            return CurrentTemplate(testModel);
        }

        private void ValidateModel(TestModel model)
        {
            // Value types
            AssertPropertyType(typeof(string), model.GetType().GetProperties().First(p => p.Name.Equals("Testfieldstring1")));
            AssertPropertyType(typeof(string), model.GetType().GetProperties().First(p => p.Name.Equals("Testfieldstring2")));
            AssertPropertyType(typeof(string), model.GetType().GetProperties().First(p => p.Name.Equals("Testfieldstring3")));

            AssertPropertyType(typeof(int), model.GetType().GetProperties().First(p => p.Name.Equals("IntegerWithPrefix")));
            AssertPropertyType(typeof(int), model.GetType().GetProperties().First(p => p.Name.Equals("IntegerWithPostfix")));

            AssertPropertyType(typeof(double), model.GetType().GetProperties().First(p => p.Name.Equals("DoubleWithPrefix")));
            AssertPropertyType(typeof(double), model.GetType().GetProperties().First(p => p.Name.Equals("DoubleWithPostfix")));

            AssertPropertyType(typeof(bool), model.GetType().GetProperties().First(p => p.Name.Equals("BooleanWithPrefix")));
            AssertPropertyType(typeof(bool), model.GetType().GetProperties().First(p => p.Name.Equals("BooleanWithPostfix")));

            AssertPropertyType(typeof(DateTime), model.GetType().GetProperties().First(p => p.Name.Equals("DateTimeWithPrefix")));
            AssertPropertyType(typeof(DateTime), model.GetType().GetProperties().First(p => p.Name.Equals("DateTimeWithPostfix")));

            AssertDateTime(new DateTime(2013, 5, 12, 22, 30, 0), model.DateTimeWithPrefix, model.GetType().GetProperties().First(p => p.Name.Equals("DateTimeWithPrefix")));
            AssertDateTime(new DateTime(2013, 5, 12, 10, 30, 0), model.DateTimeWithPostfix, model.GetType().GetProperties().First(p => p.Name.Equals("DateTimeWithPostfix")));

            // Standard fields
            AssertPropertyType(typeof(bool), model.GetType().GetProperties().First(p => p.Name.Equals("Booleantrue")));
            AssertPropertyType(typeof(bool), model.GetType().GetProperties().First(p => p.Name.Equals("Booleanfalse")));
            AssertPropertyType(typeof(List<CheckboxListCinemaFeatures>), model.GetType().GetProperties().First(p => p.Name.Equals("CinemaFeatures")));

            AssertPropertyType(typeof(int), model.GetType().GetProperties().First(p => p.Name.Equals("ContentPicker")));
            AssertPropertyType(typeof(Movie), model.GetType().GetProperties().First(p => p.Name.Equals("ContentPickerMovie")));

            AssertPropertyType(typeof(DateTime), model.GetType().GetProperties().First(p => p.Name.Equals("DatePickerWithTime")));
            AssertDateTime(new DateTime(2013, 5, 12, 22, 30, 0), model.DatePickerWithTime, model.GetType().GetProperties().First(p => p.Name.Equals("DatePickerWithTime")));
            AssertPropertyType(typeof(DateTime), model.GetType().GetProperties().First(p => p.Name.Equals("DatePicker")));
            AssertDateTime(new DateTime(2013, 5, 12, 0, 0, 0), model.DatePicker, model.GetType().GetProperties().First(p => p.Name.Equals("DatePicker")));

            AssertPropertyType(typeof(DropDownColors), model.GetType().GetProperties().First(p => p.Name.Equals("DropDownColors")));
            AssertPropertyType(typeof(List<DropDownMultipleFruit>), model.GetType().GetProperties().First(p => p.Name.Equals("DropDownMultipleFruit")));
            AssertPropertyType(typeof(DropDownListPkColors), model.GetType().GetProperties().First(p => p.Name.Equals("DropdownPublishingKeysField")));

            AssertPropertyType(typeof(int), model.GetType().GetProperties().First(p => p.Name.Equals("NumericField")));
            AssertPropertyType(typeof(MediaInfo), model.GetType().GetProperties().First(p => p.Name.Equals("MediaPickerField")));
            AssertPropertyType(typeof(List<int>), model.GetType().GetProperties().First(p => p.Name.Equals("MultiNodeTreePickerField")));
            AssertPropertyType(typeof(RadioButtonListSizes), model.GetType().GetProperties().First(p => p.Name.Equals("RadioButtonListField")));
            AssertPropertyType(typeof(string), model.GetType().GetProperties().First(p => p.Name.Equals("RichTextField")));

            // uComponents
            AssertPropertyType(typeof(MoviesRazor.Models.Hyperlink), model.GetType().GetProperties().First(p => p.Name.Equals("UrlPickerField")));
            AssertPropertyType(typeof(List<MoviesRazor.Models.Hyperlink>), model.GetType().GetProperties().First(p => p.Name.Equals("MultiUrlPickerField")));
            AssertPropertyType(typeof(List<DateTime>), model.GetType().GetProperties().First(p => p.Name.Equals("MultipleDatesField")));
            AssertPropertyType(typeof(MovieDataGrid), model.GetType().GetProperties().First(p => p.Name.Equals("MoviesGrid")));

            // MoviesGrid item fields
            AssertPropertyType(typeof(string), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("TextField")));
            AssertPropertyType(typeof(bool), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("CheckboxField")));
            AssertPropertyType(typeof(int), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("IntegerField")));
            //It seems there is a bug in uComponents when using an Url Picker data type for a grid column in combination with MVC. 
            //AssertPropertyType(typeof(MoviesRazor.Models.Hyperlink), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("UrlPickerField")));
            AssertPropertyType(typeof(DropDownColors), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("ColorField")));
            AssertPropertyType(typeof(DateTime), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("DateTimePickerField")));
            AssertPropertyType(typeof(DateTime), model.MoviesGrid.Items[0].GetType().GetProperties().First(p => p.Name.Equals("DateTimeValueField")));

            AssertPropertyType(typeof(List<string>), model.GetType().GetProperties().First(p => p.Name.Equals("SQLCheckboxListField")));
            AssertPropertyType(typeof(string), model.GetType().GetProperties().First(p => p.Name.Equals("SQLDropdownField")));
        }

        private void AssertPropertyType(Type expected, PropertyInfo property)
        {
            AssertType(expected, property.PropertyType, "Property " + property.Name + " is not of expected type " + expected.Name + " but of type " + property.PropertyType.Name);
        }

        private void AssertType(Type expected, Type actual, string message)
        {
            if (expected.Equals(actual) == false)
                throw new Exception(message);
        }

        private void AssertDateTime(DateTime expected, DateTime actual, PropertyInfo property)
        {
            if (expected.Equals(actual) == false)
                throw new Exception("Property " + property.Name + " expected value " + expected.ToString() + " is not equal to " + actual.ToString());
        }

    }
}
