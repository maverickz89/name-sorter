Imports System.IO

Public Class HomeController
  Inherits System.Web.Mvc.Controller

  Function Index() As ActionResult
    ViewData("Message") = "Welcome to ASP.NET MVC!"

    'Get get the data file
    Dim unsortedNames As List(Of String) = getListOfTextFromFile()

    'Convert from list of string to 
    Dim unsortedNameObjects As List(Of PeopleName) = convertNameStringToPeopleNameObject(unsortedNames)

    'Sort name by last name, then by given name
    Dim sortedName = unsortedNameObjects. _
      OrderBy(Function(x) x.getLastName()). _
      ThenBy(Function(x) x.getGivenName())

    ViewData("sortedName") = sortedName

    'Write to file
    writeSortedNameToFile(sortedName)

    Return View()
  End Function

  Function getListOfTextFromFile(Optional ByVal fileName As String = "unsorted-names-list.txt") As List(Of String)
    Dim dataFile As String = ""
    Try
      dataFile = Server.MapPath("~/App_Data/" & fileName)

      'Read the datafile and convert from array to list of string
      Dim result As List(Of String) = New List(Of String)(System.IO.File.ReadAllLines(dataFile))

      Return result
    Catch ex As Exception
      Return New List(Of String)
    End Try
  End Function

  Function convertNameStringToPeopleNameObject(ByVal names As List(Of String))
    Dim result As List(Of PeopleName) = New List(Of PeopleName)
    For Each name In names
      'Just need to add new object and let the constructor work
      result.Add(New PeopleName(name))
    Next
    Return result
  End Function

  Sub writeSortedNameToFile(ByVal sortedName, Optional ByVal fileName = "sorted-names-list.txt")
    Dim fp As StreamWriter
    Try
      fp = System.IO.File.CreateText(Server.MapPath("~/App_Data/" & fileName))
      For Each pplName In sortedName
        fp.WriteLine(pplName.getName())
      Next
      fp.Close()
    Catch err As Exception
    End Try
  End Sub
End Class
