Imports System.IO


Public Class PeopleName
  Private name As String
  Private lastName As String
  Private givenName As String

  Public Sub New(ByVal name As String)
    Me.name = name

    Dim splitName As List(Of String) = New List(Of String)(name.Split(" "))

    'Get last name by getting last value of the array
    Dim lastIndex As Integer = splitName.Count - 1
    Me.lastName = splitName(lastIndex)

    'Get given name by remove last name and join the rest of the name
    splitName.RemoveAt(lastIndex)
    Me.givenName = String.Join(" ", splitName)
  End Sub

  Public Function getName() As String
    Return Me.name
  End Function

  Public Function getLastName() As String
    Return Me.lastName
  End Function

  Public Function getGivenName() As String
    Return Me.givenName
  End Function
End Class
