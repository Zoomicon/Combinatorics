'Version: 20140921
'Author: George Birbilis (birbilis@kagi.com)

Imports System.Text

Public NotInheritable Class TextUtils

  Public Shared Function GetChars(ByVal s As String) As List(Of String)
    Dim result As New List(Of String)
    For Each c As Char In s
      result.Add(c)
    Next
    Return result
  End Function

  Public Shared Function Merge(ByVal items As IList(Of String), ByVal separator As String) As String
    Dim result As New StringBuilder
    Dim AfterFirst As Boolean = False
    For Each item As String In items
      If AfterFirst Then result.Append(separator) Else AfterFirst = True
      result.Append(item)
    Next
    Return result.ToString
  End Function

  Public Shared Function Split(ByVal s As String, ByVal Separator As String) As IList(Of String)
    Return If(Separator.Length = 0, GetChars(s), s.Split(New String() {Separator}, StringSplitOptions.RemoveEmptyEntries).ToList)
  End Function

End Class
