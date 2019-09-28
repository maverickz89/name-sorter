Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Web.Mvc
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Name_Sorter
Imports System.IO

<TestClass()> Public Class HomeControllerTest

  <TestMethod()> Public Sub Index()
    '' Arrange
    Dim controller As HomeController = New HomeController()

    ' Act
    Dim result As ViewResult = CType(controller.Index(), ActionResult)

    ' Assert
    Dim viewData As ViewDataDictionary = result.ViewData
    Assert.AreEqual("Welcome to ASP.NET MVC!", viewData("Message"))
  End Sub

  <TestMethod()> Public Sub convertNameStringToPeopleNameObject()
    ' Arrange
    Dim controller As HomeController = New HomeController()
    Dim nameList As List(Of String) = New List(Of String)
    nameList.AddRange({"a b c", "c b a", "b c a"})

    ' Act
    Dim result As List(Of PeopleName) = controller.convertNameStringToPeopleNameObject(nameList)

    ' Assert
    Assert.AreEqual(result(0).getName(), "a b c")
    Assert.AreEqual(result(1).getName(), "c b a")
    Assert.AreEqual(result(2).getName(), "b c a")
  End Sub
End Class
