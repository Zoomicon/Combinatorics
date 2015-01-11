'Version: 20140921
'Author: George Birbilis (birbilis@kagi.com)

Public Class MergeEnumerable
  Implements IEnumerable(Of String)

#Region "--- Properties ---"

  Public Property Data As IEnumerable(Of IList(Of String))
  Public Property Separator As String

#End Region

#Region "--- Methods ---"

  Public Sub New(ByVal Data As IEnumerable(Of IList(Of String)), ByVal Separator As String)
    With Me
      .Data = Data
      .Separator = Separator
    End With
  End Sub

  Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of String) Implements System.Collections.Generic.IEnumerable(Of String).GetEnumerator
    Return New MergeEnumerator(Data.GetEnumerator, Separator)
  End Function

  Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
    Return GetEnumerator()
  End Function

#End Region

End Class
